using System;
using System.Configuration;

namespace Joy.Core
{
    public static class AppSettingConfig
    {
        public static string GetAppSettingOrDefault(string key, string defaultValue)
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        public static string GetAppSettingOrEmpty(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? String.Empty;
        }
    }
}
