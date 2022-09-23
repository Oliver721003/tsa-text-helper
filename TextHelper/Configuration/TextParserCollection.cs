using System;
using System.Configuration;

namespace TextHelper.Configuration
{
    /// <summary>
    /// 文字解析組態集合
    /// </summary>
    public class TextParserCollection : ConfigurationElementCollection
    {
        /// <inheritdoc />
        /// <summary>
        /// 建立元素
        /// </summary>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
            => (element as TextParserElement)?.Type ?? throw new InvalidOperationException();

        /// <inheritdoc />
        /// <summary>
        /// 取得元素Key欄位資料
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
            => new TextParserElement();

        /// <summary>
        /// 依Key值取得特定實體資料
        /// </summary>
        /// <param name="name">實體型別</param>
        /// <returns></returns>
        public new TextParserElement this[string name]
        {
            set
            {
                if (BaseGet(name) != null)
                    BaseRemove(name);
                BaseAdd(value);
            }
            get => BaseGet(name) as TextParserElement;
        }
    }
}