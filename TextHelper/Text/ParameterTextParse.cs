using System.Collections.Generic;
using TextHelper.Interface;

namespace TextHelper.Text
{
    /// <summary>
    /// 參數資料解析
    /// </summary>
    internal class ParameterTextParse : TextParse
    {
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="keyName">主鍵名稱</param>
        /// <param name="parameters">資料參數</param>
        /// <param name="formats">格式轉換</param>
        public ParameterTextParse(string keyName, Dictionary<string, string> parameters,
            IEnumerable<ITextFormat> formats)
            : base(formats)
        {
            ReplaceText = Format(parameters[keyName]).ToString();
        }
    }
}