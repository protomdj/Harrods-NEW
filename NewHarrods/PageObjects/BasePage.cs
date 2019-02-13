using NewHarrods.Classes;
using NewHarrods.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class BasePage : BaseTestClass
    {
        #region WebElement
        private By _signinlink = By.XPath("//*[@class='header-account_link header-account_link--sign-in']");
        private By _searchfield = By.XPath("//*[@name='searchTerm']");
        private By _searchiconbutton = By.XPath("//*[@class='header-search_submit']");
        private By _homepageheader = By.XPath("//*[@class='header']");
        private By _homepagecontent = By.XPath("//*[@class='hrd-module-group hrd-module-group--content']");
        private By _homepagefooter = By.XPath("//*[@class='footer']");
        private By _rewardspagelink = By.XPath("//*[@class='header-account_link header-account_rewards']");
        private By _registerlink = By.XPath("//*[@class='header-account_link header-account_link--register']");
        private By _giftcardbalance = By.LinkText("Gift Card Balance");
        private By _emailsignupfield = By.XPath("//*[@id='EmailId']");
        private By _emailsignupbutton = By.XPath("//*[@class='button button--primary email-signup_submit']");
        private By _useraccountname = By.XPath("//*[@class='header-account_name']");
        private By _logoutcta = By.XPath("//*[@class='header-account_link header-account_link--sign-out']");
        private By _mmsubcategorylist = By.XPath("//*[@class='nav_sub-menu nav_sub-menu-cols--1 nav_sub-menu-items--1']");
        private By _checkoutbutton = By.XPath("//*[@id='mini-bag_checkout']");
        private By _harrodsLogo = By.ClassName("harrods-logo");
        private By _cookieBar = By.XPath("//*[@id='hrd-cookie-message']");
        private By _cookieBarClose = By.XPath("//*[@class='message_close']");
       // private By _cookieBarClose = By.XPath("//span[contains(text(),'Close')]");
        #endregion

        #region Action
        DynamicElementWait BaseWaits = new DynamicElementWait();
        public void EnterSearchTerm(string Keyword) //User specifies keyword to search
        {
            try
            {
                FindElementByElement(_searchfield).SendKeys(Keyword);
                Driver.FindElement(By.ClassName("header-search_submit")).Click();
               // FindElementByElement(_searchiconbutton).Click();
                WaitElementUntil(By.XPath("//*[@class='product-grid']"));
            }
            catch
            {
                WaitElementUntil(By.XPath("//*[@class='buying-controls_brand']"));
            }
        }
        public void Logout()
        {
            //This checks if the user is sign in- if they are, signs them out
            bool logout = Driver.FindElements(_useraccountname).Count > 0;
            if (logout == true)
            {
                FindElementByElement(_logoutcta).Click();
                ExplicitWait(2000);
            }
            else
            { }
        }
        public void HomepageCheck()
        {
            FindElementByElement(_homepageheader);
            FindElementByElement(_homepagecontent);
            FindElementByElement(_homepagefooter);
            Console.WriteLine("Homepage is OK");
        }
        public void EmailSignUp()
        {
            FindElementByElement(_registerlink).Click();
            WaitElementUntil(_emailsignupfield);
            FindElementByElement(_emailsignupfield).SendKeys("AutoSignUp" + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + "@harrodstest.com");
            try
            {
                FindElementByElement(_emailsignupbutton).Click();
                WaitElementUntil(By.XPath("//*[@class='email-subscription_content']"));
            }
            catch
            {
                Console.WriteLine("TimeOut");
            }
        }
        public void RemoveCookieBar()
        {
            if (Driver.FindElements(_cookieBar).Count > 0)
            {
                try { FindElementByElement(_cookieBarClose).Click(); }
                catch { }                
                ExplicitWait(1000);
            }
        }

        #endregion

        #region Navigation
        public void GoToHompage()
        {
            Driver.Navigate().GoToUrl(MainBaseClass.EnvURL);
        }
        public void GoToRewardsPage()
        {
            WaitElementUntil(_rewardspagelink);
            try
            {
                FindElementByElement(_rewardspagelink).Click();
            }
            catch
            {
                WaitElementUntil(By.ClassName("portal-dashboard_header-title"));
            }
            ExplicitWait(3000);
        }
        public void GoToRegisterPage()
        {
            FindElementByElement(_registerlink).Click();
            ExplicitWait(3000);
        }
        public void GoToGiftCardBalancePage()
        {
           // IJavaScriptExecutor jsexecuter = (IJavaScriptExecutor)Driver;
           //jsexecuter.ExecuteScript("window.scrollTo(0," + _giftcardbalance + ")");

            FindElementByElement(_giftcardbalance).Click();
            ExplicitWait(2000);
        }
        public void GoToParentCategory(string parentCategory)
        {
            FindElementByElement(By.LinkText(parentCategory)).Click();
            ExplicitWait(2000);
        }
        public void GoToChildCategory(string childCategory)
        {
            FindElementByElement(By.XPath("//*[@class='hrd-module hrd-module--footer-nav-links']")).FindElement(By.LinkText(childCategory)).Click();
            ExplicitWait(2000);
        }
        public void GoSignInPage()
        {
            WaitElementUntil(_signinlink);
            FindElementByElement(_signinlink).Click();
        }
        public void GoToMegaMenuLink(string parentCategory, string megaMenuLink)
        {
            Actions openMM = new Actions(Driver);
            openMM.MoveToElement(Driver.FindElement(_harrodsLogo)).Build().Perform();
            openMM.MoveToElement(Driver.FindElement(By.LinkText(parentCategory))).Build().Perform();
            WaitElementUntil(By.LinkText(megaMenuLink));
            FindElementByElement(By.LinkText(megaMenuLink)).Click();
            ExplicitWait(6000);
        }
        public void GoToCheckout()
        {
            WaitElementUntil(_checkoutbutton);
            FindElementByElement(_checkoutbutton).Click();
        }
        #endregion
    }
}
