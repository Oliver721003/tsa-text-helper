using System;
using System.Collections.Generic;
using TextHelper.Interface;

namespace TextHelper.Text
{
    /// <summary>
    /// 實體資料文字解析
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityTextParse<T> : TextParse
    {
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="formats">格式轉換</param>
        /// <param name="property">屬性名稱</param>
        /// <param name="data">資料實體</param>
        public EntityTextParse(IEnumerable<ITextFormat> formats, string property, T data)
            : base(formats)
        {
            var text = Format(GetValue(0, property, data));
            ReplaceText = text?.ToString() ?? "";
        }

        /// <summary>
        /// 實體屬性值取得
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="name">屬性名稱</param>
        /// <param name="data">實體資料</param>
        /// <returns></returns>
        private static object GetValue(int index, string name, object data)
        {
            while (true)
            {
                var property = data.GetType().GetProperty(name.Split('.')[index]);

                if (property == null) throw new Exception($"實體類型找不到{name}屬性");

                if (name.Split('.').Length == index + 1)
                    return property.GetValue(data);
                else
                {
                    index = index + 1;
                    data = property.GetValue(data);
                }
            }
        }
    }
}