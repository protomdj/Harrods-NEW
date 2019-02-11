using NewHarrods.Interface;
using NewHarrods.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        }

        public EnvironmentType GetEnvironment()
        {
            string environment = ConfigurationManager.AppSettings.Get(AppConfigKeys.Environment);
            return (EnvironmentType)Enum.Parse(typeof(EnvironmentType), environment);
        }
        public ScreenSizeType GetScreenSize()
        {
            string screensize = ConfigurationManager.AppSettings.Get(AppConfigKeys.ScreenSize);
            return (ScreenSizeType)Enum.Parse(typeof(ScreenSizeType), screensize);
        }
        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.CustomerUsername);
        }
        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.CustomerPassword);
        }
    }
}
