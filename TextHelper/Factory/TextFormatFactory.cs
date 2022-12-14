using System;
using TextHelper.Configuration;
using TextHelper.Interface;

namespace TextHelper.Factory
{
    /// <summary>
    /// 格式轉換工廠
    /// </summary>
    public static class TextFormatFactory
    {
        /// <summary>
        /// 格式轉換物件取得
        /// </summary>
        /// <param name="text">格式設定</param>
        /// <returns></returns>
        public static ITextFormat CreateInstance(string text)
        {
            var config = text.Split(':');
            var formatType = config[0].Trim();
            var format = config.Length == 2 ? config[1].Trim() : "";

            var type = TextParserSettingFactory.GetTextFormat(formatType);

            if (type == null)
                throw new Exception("轉換格式輸入錯誤");

            return (ITextFormat)Activator.CreateInstance(type, format);
        }
    }
}