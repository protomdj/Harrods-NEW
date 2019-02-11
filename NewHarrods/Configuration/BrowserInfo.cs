using NewHarrods.Settings;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Configuration
{
    public class BrowserInfo
    {
        public void GetBrowserDetails()
        {
            ICapabilities getBrowserInfo = ((RemoteWebDriver)ObjectRepository.Driver).Capabilities;
            try
            {
                string browserversion = getBrowserInfo.GetCapability("Version").ToString();
                string browsertype = getBrowserInfo.GetCapability("BrowserName").ToString();
                // string browserversion = getBrowserInfo.Version;
                //string browsertype = getBrowserInfo.BrowserName;
                Console.WriteLine("Browser Name: " + browsertype.ToString());
                Console.WriteLine("Browser Version: " + browserversion.ToString());
            }

            catch { }
        }
    }
}
