using System;
using System.Collections.Generic;
using System.Linq;
using TextHelper.Factory;
using TextHelper.Interface;

namespace TextHelper
{
    /// <summary>
    /// 文字解析服務
    /// </summary>
    public class TextParseService
    {
        // 日期管理器
        private readonly IDateTimeManager _datetimeManager;

        /// <summary>
        /// 建構式
        /// </summary>
        public TextParseService()
        {
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="datetimeManager"></param>
        internal TextParseService(IDateTimeManager datetimeManager)
        {
            _datetimeManager = datetimeManager;
        }

        /// <summary>
        /// 文字解析
        /// </summary>
        /// <param name="context">文字內容</param>
        /// <param name="parameters">非實體資料參數</param>
        public string Parse(string context, Dictionary<string, string> parameters)
        {
            return Parse(
                context,
                (content, formats) => TextParseFactory.CreateInstance(content, formats, parameters)
            );
        }

        /// <summary>
        /// 文字解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">文字內容</param>
        /// <param name="data">資料實體</param>
        /// <param name="parameters">非實體資料參數</param>
        public string Parse<T>(string context, T data, Dictionary<string, string> parameters)
            where T : class
        {
            return Parse(
                context,
                (content, formats) => TextParseFactory.CreateInstance(content, formats, data, parameters)
            );
        }

        /// <summary>
        /// 文字解析
        /// </summary>
        /// <param name="context">文字內容</param>
        /// <param name="getTextParse">文字解析取得方法</param>
        private static string Parse(string context, Func<string, List<ITextFormat>, ITextParse> getTextParse)
        {
            var result = context;

            while (result.IndexOf("#[", StringComparison.Ordinal) != -1)
            {
                var start = result.IndexOf("#[", StringComparison.Ordinal);
                var end = result.IndexOf("]#", StringComparison.Ordinal);
                var content = result.Substring(start + 2, end - start - 2);
                var filter = content.Split('|');
                var formats = filter.ToList().Skip(1).Select(TextFormatFactory.CreateInstance).ToList();

                var textParse = getTextParse(filter[0].Trim(), formats);
                result = textParse.Replace(result, content);
            }

            return result;
        }
    }
}