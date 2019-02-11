using NewHarrods.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NewHarrods.Classes
{
    public class BaseTestClass 
    {
        public static IWebDriver _driver = null;

        public BaseTestClass()
        {
            _driver = ObjectRepository.Driver;
        }

        public IWebDriver Driver
        {
            get
            {
                return _driver;
            }
        }

        public IWebElement FindElementByXpath(string xpath)
        {
            return _driver.FindElement(By.XPath(xpath));
        }

        public IWebElement FindElementCustom(string objectType, string text)
        {
            return _driver.FindElement(By.XPath($"//{objectType}[contains(text(),'{text}')]"));            
        }

        public IWebElement FindElementByClassName(string className)
        {
            return _driver.FindElement(By.ClassName(className));
        }
        public IWebElement FindElementByLinkText(string linkText)
        {
            return _driver.FindElement(By.LinkText(linkText));
        }
        public IWebElement FindElementByElement(By element)
        {
            return _driver.FindElement(element);
        }
        public IWebElement FindElementByCss(string cssSelector)
        {
            return _driver.FindElement(By.CssSelector(cssSelector));
        }
        public void DropDownSelectValue(By element, string value)
        {
            IWebElement selecteddropdown = _driver.FindElement(element);
            SelectElement selectvalue = new SelectElement(selecteddropdown);
            selectvalue.SelectByValue(value);
        }
        public void DropDownSelectText(By element, string text)
        {
            IWebElement selecteddropdown = _driver.FindElement(element);
            SelectElement selecttext = new SelectElement(selecteddropdown);
            ExplicitWait(7000);
            selecttext.SelectByText(text);
            
        }

        
        public void DropDownSelectIndex(By element, int index)
        {
            IWebElement selecteddropdown = _driver.FindElement(element);
            SelectElement selectindex = new SelectElement(selecteddropdown);
            selectindex.SelectByIndex(index);
        }
        public void WaitElementUntil(By element)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitElementClickable(By element)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        //public void WaitElementClickable(By element)
        //{
        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(14));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        //}

        public void ExplicitWait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
       
    }
}
