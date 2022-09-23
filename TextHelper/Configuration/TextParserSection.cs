using System.Configuration;

namespace TextHelper.Configuration
{
    /// <summary>
    /// 文字解析組態定義
    /// </summary>
    public class TextParserSection : ConfigurationSection
    {
        /// <summary>
        /// 文字解析組態定義
        /// </summary>
        [ConfigurationProperty("parsers", IsRequired = true)]
        [ConfigurationCollection(typeof(TextParserCollection),
            CollectionType = ConfigurationElementCollectionType.BasicMap, AddItemName = "add")]
        public TextParserCollection TextParser => base["parsers"] as TextParserCollection;

        /// <summary>
        /// 文字格式化組態定義
        /// </summary>
        [ConfigurationProperty("formats", IsRequired = true)]
        [ConfigurationCollection(typeof(TextParserCollection),
            CollectionType = ConfigurationElementCollectionType.BasicMap, AddItemName = "add")]
        public TextParserCollection Format => base["formats"] as TextParserCollection;
    }
}