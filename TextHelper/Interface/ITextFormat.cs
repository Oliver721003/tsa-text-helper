namespace TextHelper.Interface
{
    /// <summary>
    /// 格式轉換介面
    /// </summary>
    public interface ITextFormat
    {
        /// <summary>
        /// 格式設定
        /// </summary>
        /// <param name="text">原格式物件</param>
        /// <returns></returns>
        string Format(object text);
    }
}