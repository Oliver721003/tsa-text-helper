using System;
using System.Configuration;
using System.Web;

namespace TextHelper.Configuration
{
    /// <summary>
    /// 文字解析組態定義工廠
    /// </summary>
    public class TextParserSettingFactory
    {
        /// <summary>
        /// 文字解析組態取得
        /// </summary>
        /// <param name="type">文字解析類型</param>
        /// <returns></returns>
        public static Type GetTextParser(string type)
        {
            var section = GetSectionFromConfig() ?? GetSectionFromCustom();

            if (section == null)
                throw new Exception("App.config / Web.config / textParser.config 找不到 textParser 定義區塊");

            var setting = section.TextParser[type];
            return setting == null ? null : Type.GetType(setting.Library);
        }

        /// <summary>
        /// 文字格式化組態取得
        /// </summary>
        /// <param name="type">文字解析類型</param>
        /// <returns></returns>
        public static Type GetTextFormat(string type)
        {
            var section = GetSectionFromConfig() ?? GetSectionFromCustom();

            if (section == null)
                throw new Exception("App.config / Web.config / textParser.config 找不到 textParser 定義區塊");

            var setting = section.Format[type];
            return setting == null ? null : Type.GetType(setting.Library);
        }

        /// <summary>
        /// 從 Web.config / App.config 取得組態
        /// </summary>
        /// <returns></returns>
        private static TextParserSection GetSectionFromConfig()
            => (TextParserSection)ConfigurationManager.GetSection("textParsers");

        /// <summary>
        /// 從 textParser.config 取得組態
        /// </summary>
        /// <returns></returns>
        private static TextParserSection GetSectionFromCustom()
        {
            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = HttpContext.Current == null
                    ? "./textParser.config"
                    : HttpContext.Current.Server.MapPath("~/textParser.config")
            };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            return config?.GetSection("textParsers") as TextParserSection;
        }
    }
}