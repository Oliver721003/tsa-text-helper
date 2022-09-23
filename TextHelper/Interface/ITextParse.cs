namespace TextHelper.Interface
{
    /// <summary>
    /// 格式轉換介面
    /// </summary>
    internal interface ITextParse
    {
        /// <summary>
        /// 文字替換
        /// </summary>
        /// <param name="text">文字內容</param>
        /// <param name="target">替換對象</param>
        /// <returns></returns>
        string Replace(string text, string target);
    }
}