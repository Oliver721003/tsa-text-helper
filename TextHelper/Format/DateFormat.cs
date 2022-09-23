using System;

namespace TextHelper.Format
{
    /// <summary>
    /// 日期格式
    /// </summary>
    public class DateFormat : TextFormat
    {
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="format">轉換格式</param>
        public DateFormat(string format)
            : base(format)
        {
        }

        /// <summary>
        /// 格式設定
        /// </summary>
        /// <param name="text">原格式物件</param>
        /// <returns></returns>
        public override string Format(object text) => Convert.ToDateTime(text).ToString(_format);
    }
}