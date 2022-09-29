using System;
using System.Collections.Generic;
using TextHelper.Interface;

namespace TextHelper.Text
{
    /// <summary>
    /// 現在日期
    /// </summary>
    public class NowTextParse : TextParse
    {
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="formats">格式轉換</param>
        public NowTextParse(IEnumerable<ITextFormat> formats)
            : base(formats)
        {
            ReplaceText = Format(DateTime.Now).ToString();
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="formats">格式轉換</param>
        /// <param name="datetimeManager"></param>
        internal NowTextParse(IEnumerable<ITextFormat> formats, IDateTimeManager datetimeManager)
            : base(formats)
        {
            ReplaceText = Format(datetimeManager.Now).ToString();
        }
    }
}