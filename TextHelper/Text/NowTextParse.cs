using System;
using System.Globalization;
using TsaBackEndInfrastructure.Utils;

namespace TextHelper.Text
{
    /// <summary>
    /// 現在日期
    /// </summary>
    internal class NowTextParse : TextParse
    {
        /// <summary>
        /// 建構式
        /// </summary>
        public NowTextParse()
        {
            var text = DateTime.Now;
            ReplaceText = text.ToString();
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="datetimeManager"></param>
        internal NowTextParse(IDateTimeManager datetimeManager)
        {
            var text = datetimeManager.Now;
            ReplaceText = text.ToString(CultureInfo.InvariantCulture);
        }
    }
}