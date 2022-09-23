using System;
using System.Linq;
using TextHelper.Factory;
using TsaBackEndInfrastructure.Utils;

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
        /// <typeparam name="T"></typeparam>
        /// <param name="context">文字內容</param>
        /// <param name="data">資料實體</param>
        public string Parse<T>(string context, T data)
            where T : class
        {
            var result = context;

            while (result.IndexOf("#[", StringComparison.Ordinal) != -1)
            {
                var start = result.IndexOf("#[", StringComparison.Ordinal);
                var end = result.IndexOf("]#", StringComparison.Ordinal);
                var content = result.Substring(start + 2, end - start - 2);
                var filter = content.Split('|').ToList();
                var formats = filter.Skip(1).Select(TextFormatFactory.CreateInstance);

                var textParse = TextParseFactory.CreateInstance(filter[0].Trim(), formats, data, _datetimeManager);
                result = textParse.Replace(result, content);
            }

            return result;
        }
    }
}