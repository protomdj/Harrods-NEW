using NewHarrods.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Configuration
{
    public class DynamicElementWait
    {
        public WebDriverWait InitiateWait()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(1);

            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(30));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            return wait;
        }
        public WebDriverWait InitiateWait(int waitLength)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(waitLength));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            return wait;
        }
        public Func<IWebDriver, bool> WaitForElement(By XPath)
        {
            return ((x) =>
             {
                 Console.WriteLine("Waiting for element");
                 return x.FindElements(XPath).Count == 1;
             });
        }

    }
}
