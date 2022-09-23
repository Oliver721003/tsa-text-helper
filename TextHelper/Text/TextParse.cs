using TextHelper.Interface;

namespace TextHelper.Text
{
    /// <summary>
    /// 文字替換物件
    /// </summary>
    internal abstract class TextParse : ITextParse
    {
        /// <summary>
        /// 欲替換文字
        /// </summary>
        protected string ReplaceText;

        /// <summary>
        /// 文字替換
        /// </summary>
        /// <param name="text">原文字內容</param>
        /// <param name="target">替換對象</param>
        /// <returns></returns>
        public virtual string Replace(string text, string target) => text.Replace($"#[{target}]#", ReplaceText);
    }
}