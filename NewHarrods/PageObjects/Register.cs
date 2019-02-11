using NewHarrods.Classes;
using NewHarrods.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class Register1 : BaseTestClass
    {
        //Calling out the WebElements on the page
        #region WebElement 
        private By _emailfield = By.XPath("//*[@name='EmailAddress']");
        private By _rewardscomboboxes = By.XPath("//*[@class='field_label field_label--2 field_label--inline field_label--inline-2']");
        private By _continuebutton = By.XPath("//*[@class='button button--action button--arrow-after']");
        private By _titledropdown = By.XPath("//*[@name='Title']");
        #endregion

        #region Actions
        IJavaScriptExecutor jsexecuter = (IJavaScriptExecutor)ObjectRepository.Driver;
        public void EnterEmailContinue(int rewardTypeIndex)
        {//Method to create unique email addresses every time user wishes to create an account, user must specify rewards index (0, 1 or 2)
            FindElementByElement(_emailfield).SendKeys("AutoSignUp" + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss")+"@harrodstest.com");
            IList<IWebElement> comboBoxElements = Driver.FindElements(_rewardscomboboxes);
            var userrewardstype = comboBoxElements.ElementAt(rewardTypeIndex);
            userrewardstype.Click();
            Driver.FindElement(_continuebutton);
            try
            {
                jsexecuter.ExecuteScript("var a = $('.button--action');" +
                    "a.is(':visible') ? a.click(): undefined.click();");
                WaitElementUntil(_titledropdown);
            }
            catch
            {
                Console.WriteLine("Click TimeOut");                
            }                   
        }
    }
    #endregion

    public class Register2 :BaseTestClass 
    {
        #region WebElement 
        private By _titledropdown = By.XPath("//*[@name='Title']");
        private By _firstnamefield = By.XPath("//*[@name='FirstName']");
        private By _lastnamefield = By.XPath("//*[@name='LastName']");
        private By _contactnodropdown = By.XPath("//*[@name='DiallingCode']");
        private By _contactnofield = By.XPath("//*[@name='TelephoneNumber']");
        private By _createpasswordfield = By.XPath("//*[@name='NewPassword']");
        private By _confirmpasswordfield = By.XPath("//*[@name='ConfirmNewPassword']");
        private By _completeregbutton = By.XPath("//*[@class='button button--action button--arrow-after js-form-submit']");
        private By _emailused = By.XPath("//*[@class='field_copy-long field_copy-long--force-break']");
        private By _countryselectordropdown = By.XPath("//*[@name='Address.CountryCode']");
        private By _addresslineonefield = By.XPath("//*[@name='Address.AddressLine1']");
        private By _cityfield = By.XPath("//*[@name='Address.City']");
        private By _postcodefield = By.XPath("//*[@name='Address.Postcode']");
        private By _birthdaydaydropdown = By.XPath("//*[@name='BirthdayDay']");
        private By _birthdaymonthdropdown = By.XPath("//*[@name='BirthdayMonth']");
        #endregion

        #region Actions
        IJavaScriptExecutor jsexecuter = (IJavaScriptExecutor)ObjectRepository.Driver;
        public void CompleteNonRewardsRegistration(string title, string firstName, string lastName, string number, string password)
        {//Non-rewards form completion, method writes email used to Log of test.
            string accountemail = FindElementByElement(_emailused).Text;
            Console.WriteLine("Email Account Registered: "+accountemail);
            DropDownSelectValue(_titledropdown, title);
            FindElementByElement(_firstnamefield).SendKeys(firstName);
            FindElementByElement(_lastnamefield).SendKeys(lastName);
            FindElementByElement(_contactnofield).SendKeys(number);

            FindElementByElement(_createpasswordfield).SendKeys(password);
            FindElementByElement(_confirmpasswordfield).SendKeys(password);
            FindElementByElement(_completeregbutton);
            try
            { 
            jsexecuter.ExecuteScript("var a = $('.js-form-submit');" +
            "a.is(':visible') ? a.click(): undefined.click();");

            }
            catch
            {
                Console.WriteLine("Click TimeOut");
            }

            WaitElementClickable(By.XPath("//a[contains(text(),'Continue to account')]"));
            ExplicitWait(6000);
            FindElementCustom("a", "Continue to account").Click();
            WaitElementUntil(By.XPath("//*[@class='portal-dashboard_content']"));

            ExplicitWait(2000);
        }
        public void CompleteRewardsRegistration(string title, string firstName, string lastName, string number, string password, string country, string street, string city, string postcode, string birthdayMonth, string birthdayDay)
        {//Rewards form completion, method writes email used to Log of test.
            string accountemail = FindElementByElement(_emailused).Text;
            Console.WriteLine("Email Account Registered: " + accountemail);
            DropDownSelectValue(_titledropdown, title);
            FindElementByElement(_firstnamefield).SendKeys(firstName);
            FindElementByElement(_lastnamefield).SendKeys(lastName);
            FindElementByElement(_contactnofield).SendKeys(number);
            DropDownSelectValue(_birthdaydaydropdown, birthdayDay);
            DropDownSelectText(_birthdaymonthdropdown, birthdayMonth);

            DropDownSelectText(_countryselectordropdown, country);
            FindElementByElement(_addresslineonefield).SendKeys(street);
            FindElementByElement(_cityfield).SendKeys(city);
            FindElementByElement(_postcodefield).SendKeys(postcode);
            FindElementByElement(_createpasswordfield).SendKeys(password);
            FindElementByElement(_confirmpasswordfield).SendKeys(password);
            FindElementByElement(_completeregbutton);
            try
            {
                jsexecuter.ExecuteScript("var a = $('.js-form-submit');"+
                "a.is(':visible') ? a.click(): undefined.click();");
                
            }
            catch
            {
                Console.WriteLine("Click TimeOut");
            }

            WaitElementUntil(By.XPath("//a[contains(text(),'Continue to account')]"));
            ExplicitWait(6000);
            FindElementCustom("a", "Continue to account").Click();
            WaitElementUntil(By.XPath("//*[@class='portal-dashboard_content']"));

            ExplicitWait(2000); 
        }
        #endregion
    }
}
