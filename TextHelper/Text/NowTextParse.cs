using System;
using System.Globalization;
using TsaBackEndInfrastructure.Utils;

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
        public NowTextParse()
        {
            var text = DateTime.Now;
            ReplaceText = text.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="datetimeManager"></param>
        public NowTextParse(IDateTimeManager datetimeManager)
        {
            var text = datetimeManager.Now;
            ReplaceText = text.ToString(CultureInfo.InvariantCulture);
        }
    }
}