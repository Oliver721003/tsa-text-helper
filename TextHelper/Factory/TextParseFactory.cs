using System;
using System.Collections.Generic;
using TextHelper.Configuration;
using TextHelper.Interface;
using TextHelper.Text;
using TsaBackEndInfrastructure.Utils;

namespace TextHelper.Factory
{
    /// <summary>
    /// 文字解析器工廠
    /// </summary>
    internal static class TextParseFactory
    {
        /// <summary>
        /// 文字解析器實體取得
        /// </summary>
        /// <param name="content">文字內容</param>
        /// <param name="formats"></param>
        /// <param name="parameters">非實體資料參數</param>
        /// <param name="dateTimeManager">日期管理器</param>
        /// <returns></returns>
        public static ITextParse CreateInstance(string content, List<ITextFormat> formats,
            Dictionary<string, string> parameters, IDateTimeManager dateTimeManager = null)
        {
            var type = CreateInstance(content, formats, dateTimeManager);

            if (type != null)
                return type;

            if (!parameters.ContainsKey(content))
                throw new Exception($"資料參數內找不到{content}主鍵資訊");

            return new ParameterTextParse(content, parameters, formats);
        }

        /// <summary>
        /// 文字替換物件取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">文字內容</param>
        /// <param name="formats"></param>
        /// <param name="data">實體資料</param>
        /// <param name="parameters">非實體資料參數</param>
        /// <param name="dateTimeManager">日期管理器</param>
        /// <returns></returns>
        public static ITextParse CreateInstance<T>(string content, List<ITextFormat> formats, T data,
            Dictionary<string, string> parameters, IDateTimeManager dateTimeManager = null)
            where T : class
        {
            var type = CreateInstance(content, formats, dateTimeManager);

            if (type != null)
                return type;

            return parameters.ContainsKey(content)
                ? (ITextParse)new ParameterTextParse(content, parameters, formats)
                : new EntityTextParse<T>(content, data, formats);
        }

        /// <summary>
        /// 文字替換物件取得
        /// </summary>
        /// <param name="content">文字內容</param>
        /// <param name="formats"></param>
        /// <param name="dateTimeManager">日期管理器</param>
        /// <returns></returns>
        private static ITextParse CreateInstance(string content, List<ITextFormat> formats,
            IDateTimeManager dateTimeManager = null)
        {
            var type = TextParserSettingFactory.GetTextParser(content);

            if (type == null)
                return null;

            return dateTimeManager == null
                ? (ITextParse)Activator.CreateInstance(type, formats)
                : (ITextParse)Activator.CreateInstance(type, formats, dateTimeManager);
        }
    }
}