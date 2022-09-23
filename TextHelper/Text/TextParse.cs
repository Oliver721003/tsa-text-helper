using System.Collections.Generic;
using System.Linq;
using TextHelper.Interface;

namespace TextHelper.Text
{
    /// <summary>
    /// 文字替換物件
    /// </summary>
    public abstract class TextParse : ITextParse
    {
        // 格式轉換
        private readonly IEnumerable<ITextFormat> _formats;

        /// <summary>
        /// 欲替換文字
        /// </summary>
        protected string ReplaceText;

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="formats">格式轉換</param>
        protected TextParse(IEnumerable<ITextFormat> formats)
        {
            _formats = formats;
        }

        /// <summary>
        /// 文字替換
        /// </summary>
        /// <param name="text">原文字內容</param>
        /// <param name="target">替換對象</param>
        /// <returns></returns>
        public virtual string Replace(string text, string target) => text.Replace($"#[{target}]#", ReplaceText);

        /// <summary>
        /// 內容格式化作業
        /// </summary>
        /// <param name="value">文字內容</param>
        /// <returns></returns>
        protected object Format(object value)
        {
            return _formats.Aggregate<ITextFormat, object>(
                value,
                (current, format) => format.Format(current)
            );
        }
    }
}