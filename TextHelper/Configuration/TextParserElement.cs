using System.Configuration;

namespace TextHelper.Configuration
{
    /// <summary>
    /// 文字解析組態元素
    /// </summary>
    public class TextParserElement : ConfigurationElement
    {
        /// <summary>
        /// 解析器類型
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = true)]
        public string Type => base["type"].ToString();

        /// <summary>
        /// 解析器類別
        /// </summary>
        [ConfigurationProperty("library", IsRequired = true)]
        public string Library => base["library"].ToString();
    }
}