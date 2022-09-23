using System;
using System.Globalization;

namespace TextHelper.Format
{
    /// <summary>
    /// 貨幣格式
    /// </summary>
    public class CurrencyFormat : TextFormat
    {
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="format">轉換格式</param>
        public CurrencyFormat(string format)
            : base(format)
        {
        }

        /// <summary>
        /// 格式設定
        /// </summary>
        /// <param name="text">原格式物件</param>
        /// <returns></returns>
        public override string Format(object text)
            => Convert.ToDecimal(text).ToString("C2", CultureInfo.CreateSpecificCulture(_format));
    }
}