using TextHelper.Interface;

namespace TextHelper.Format
{
    /// <summary>
    /// 格式轉換物件
    /// </summary>
    public abstract class TextFormat : ITextFormat
    {
        /// <summary>
        /// 轉換格式
        /// </summary>
        protected readonly string _format;

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="format">轉換格式</param>
        protected TextFormat(string format)
        {
            _format = format;
        }

        /// <summary>
        /// 格式轉換
        /// </summary>
        /// <param name="text">原格式物件</param>
        /// <returns></returns>
        public abstract string Format(object text);
    }
}