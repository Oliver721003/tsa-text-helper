using System;
using TextHelper.Format;
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
            var name = config[0].Trim();
            var type = config[1].Trim();

            switch (name)
            {
                case "date":
                    return new DateFormat(type);
                case "currency":
                    return new CurrencyFormat(type);
                default:
                    throw new Exception("轉換格式輸入錯誤");
            }
        }
    }
}