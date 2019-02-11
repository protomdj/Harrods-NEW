using NewHarrods.Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class CheckoutDetails : BaseTestClass
    {
        #region WebElement 
        private By _titledropdown = By.XPath("//*[@name='Title']");
        private By _firstnamefield = By.XPath("//*[@name='FirstName']");
        private By _lastnamefield = By.XPath("//*[@name='LastName']");
        private By _contactnodropdown = By.XPath("//*[@name='DiallingCode']");
        private By _contactnofield = By.XPath("//*[@name='ContactNumber']");
        private By _emailfield = By.XPath("//*[@name='EmailAddress']");
        private By _createpasscheckbox = By.XPath("//*[@name='CreateAccount']");
        private By _harrodsrewardscheckbox = By.XPath("//*[@name='EarnRewards']");
        private By _genericpassfield = By.XPath("//*[@name='Password']");
        private By _genericpassconfirmfield = By.XPath("//*[@name='ConfirmedPassword']");
        private By _continuedeliverybutton = By.XPath("//*[@class='button button--action button--arrow-after']");
        private By _existingmembercombobox = By.XPath("//*[@for='existingRewards']");
        private By _joinrewardscombobox = By.XPath("//*[@for='newRewards']");
        private By _rewardsnofield = By.XPath("//*[@name='RewardsNumber']");
        private By _rewardspassfield = By.XPath("//*[@name='RewardsPassword']");
        private By _confirmrewardspassfield = By.XPath("//*[@name='ConfirmedRewardsPassword']");
        private By _continuepayementbutton = By.XPath("//*[@name='btnContinueToPayment']");
        #endregion

        #region Actions
        public void CompleteMandatoryDetails(string title, string firstName, string lastName, string number, string email)
        {//Method to complete mandatory details page fields
            DropDownSelectValue(_titledropdown, title);
            FindElementByElement(_firstnamefield).Clear();
            FindElementByElement(_firstnamefield).SendKeys(firstName);
            FindElementByElement(_lastnamefield).Clear();
            FindElementByElement(_lastnamefield).SendKeys(lastName);
            FindElementByElement(_emailfield).Clear();
            FindElementByElement(_emailfield).SendKeys(email);
            FindElementByElement(_contactnofield).Clear();
            FindElementByElement(_contactnofield).SendKeys(number);
        }
        public void DetailsSignUp(string password)
        { //Method to be called to create account from details page          
            FindElementByElement(_createpasscheckbox).Click();
            WaitElementUntil(_genericpassfield);
            FindElementByElement(_genericpassfield).SendKeys(password);
            FindElementByElement(_genericpassconfirmfield).SendKeys(password);
        }
        public void DetailsExistingRewardsRedeem(string existingRewardsNo)
        { //Method to be called to claim rewards points using existing rewards card
            FindElementByElement(_harrodsrewardscheckbox).Click();
            WaitElementUntil(_existingmembercombobox);
            FindElementByElement(_existingmembercombobox).Click();
            WaitElementUntil(_rewardsnofield);
            FindElementByElement(_rewardsnofield).SendKeys(existingRewardsNo);
        }

        public void JoinRewards(string password)
        { //Method to be called to create account and claim rewards points
            FindElementByElement(_harrodsrewardscheckbox).Click();
            WaitElementUntil(_joinrewardscombobox);
            FindElementByElement(_joinrewardscombobox).Click();
            WaitElementUntil(_rewardspassfield);
            FindElementByElement(_rewardspassfield).SendKeys(password);
            FindElementByElement(_confirmrewardspassfield).SendKeys(password);
        }
        #endregion

        #region Navigation
        public void GoDeliveryPage()
        {//This needs to be used after the field completion method is called to navigate to the next page.
            FindElementByElement(_continuedeliverybutton).Click();
            WaitElementUntil(_continuepayementbutton);
        }
        #endregion
    }
}
