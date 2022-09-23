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
        /// <param name="data">實體資料</param>
        /// <param name="dateTimeManager">日期管理器</param>
        /// <returns></returns>
        public static ITextParse CreateInstance<T>(string content, T data, IDateTimeManager dateTimeManager = null)
            where T : class
        {
            switch (content)
            {
                case "NOW":
                case "Now":
                    return dateTimeManager == null ? new NowTextParse() : new NowTextParse(dateTimeManager);
                default:
                    return new EntityTextParse<T>(content, data);
            }
        }
    }
}