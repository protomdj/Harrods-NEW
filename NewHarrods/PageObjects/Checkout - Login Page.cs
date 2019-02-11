using NewHarrods.Classes;
using NewHarrods.Configuration;
using NewHarrods.Interface;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class CheckoutLoginPage : BaseTestClass
    {
        #region WebElements
        private By _emailfield = By.XPath("//*[@name='EmailAddress']");
        private By _passwordfield = By.XPath("//*[@name='Password']");
        private By _signinqcbutton = By.XPath("//*[@value='Sign in to Quick Checkout']");
        private By _newcustomerbutton = By.XPath("//*[@value='New Customer']");
        private By _titledropdown = By.XPath("//*[@name='Title']");
        #endregion
        #region Actions

        public void Login() //Method using config values for login credentials to checkout as registered user
        {
            IConfig ConfigCredentials = new AppConfigReader();
            WaitElementUntil(_emailfield);
            FindElementByElement(_emailfield).SendKeys(ConfigCredentials.GetUsername());
            FindElementByElement(_passwordfield).SendKeys(ConfigCredentials.GetPassword());
            FindElementByElement(_signinqcbutton).Click();
        }
        public void Login(string Default)
        { //Method using default automation values for login credentials to checkout as registered user (User just specifies which account type)
            WaitElementUntil(_emailfield);

            if (Default == "NonRewards")
            {
                FindElementByElement(_emailfield).SendKeys("AutomationNonRewards@gmail.com");
                FindElementByElement(_passwordfield).SendKeys("Welcome123");
                FindElementByElement(_signinqcbutton).Click();
            }
            else if (Default == "Rewards")
            {
                FindElementByElement(_emailfield).SendKeys("AutomationRewards@gmail.com");
                FindElementByElement(_passwordfield).SendKeys("Welcome123");
                FindElementByElement(_signinqcbutton).Click();
            }
            else
            {
                Console.WriteLine("Enter a Valid Input for Account Type or Choose Another Login Method");
            }
        }
        public void Login(string email, string password)
        {//Method for hard coded (controlled) logins
            WaitElementUntil(_emailfield);
            FindElementByElement(_emailfield).SendKeys(email);
            FindElementByElement(_passwordfield).SendKeys(password);
            FindElementByElement(_signinqcbutton).Click();
        }
        #endregion

        #region Navigation
        public void AdvanceAsGuest()
        { //Method to navigate to checkout as guest
            ExplicitWait(5000);
            WaitElementUntil(_newcustomerbutton);
            FindElementByElement(_newcustomerbutton).Click();
            WaitElementUntil(_titledropdown);
        }
        #endregion
    }
}
