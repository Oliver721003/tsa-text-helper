namespace TextHelper.Text
{
    /// <summary>
    /// 文字解析服務
    /// </summary>
    public static class TextParseService
    {
        /// <summary>
        /// 文字解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">文字內容</param>
        /// <param name="data">資料實體</param>
        public static string Parse<T>(string context, T data)
            where T : class
        {
            return context;
        }
    }
}