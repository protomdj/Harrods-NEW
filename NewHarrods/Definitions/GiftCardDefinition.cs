using NewHarrods.Classes;
using NewHarrods.Settings;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NewHarrods.PageObjects;
using NewHarrods.Configuration;

namespace NewHarrods.Definitions
{
    [Binding]
    public class GiftCardDefinition : BaseTestClass
    {
        BasePage baseMethod = new BasePage();
        GiftCardBalance gcbTest = new GiftCardBalance();
        Fashion1PDP pdpTest = new Fashion1PDP();
        private By _addtobagbutton = By.XPath("//*[@value='Add to Bag']");


        [Given(@"I am on the Gift Card Balance page")]
        public void GivenIAmOnTheGiftCardBalancePage()
        {
            baseMethod.GoToGiftCardBalancePage();
        }

        [When(@"I a Enter gift card number with '(.*)'")]
        public void WhenIAEnterGiftCardNumberWith(string type)
        {
            gcbTest.EnterInvalidGiftCardNumber(type);
        }

        [Then(@"a Gift Card Number error message '(.*)' is displayed")]
        public void ThenAGiftCardNumberErrorMessageIsDisplayed(string message)
        {
            gcbTest.ValidateGiftCardNumberError(message);
        }

        [When(@"I enter a PIN number which contains '(.*)'")]
        public void WhenIEnterAPINNumberWhichContains(string type)
        {
            gcbTest.EnterInvalidGiftCardPin(type);
        }

        [Then(@"I am informed that the number is '(.*)'")]
        public void ThenIAmInformedThatTheNumberIs(string message)
        {
            gcbTest.ValidateGiftCardPinError(message);
        }


        [When(@"I submit the form with a valid gift card number and PIN")]
        public void WhenISubmitTheFormWithAValidGiftCardNumberAndPIN()
        {
            gcbTest.EnterGiftCardBalance();          
        }

        [Then(@"the Gift Card balance page is displayed")]
        public void ThenTheGiftCardBalancePageIsDisplayed()
        {
            gcbTest.ValidateGiftBalancePage();
        }

        [Given(@"I am on a gift card PDP")]
        public void GivenIAmOnAGiftCardPDP()
        {
            Driver.Navigate().GoToUrl(MainBaseClass.EnvURL + "/harrods/gift-card-500-p000000009999991010?bcid=1486033001292");
        }

        [Then(@"the '(.*)' section contains the following")]
        public void ThenTheSectionContainsTheFollowing(string controls)
        {
            gcbTest.ValidateGiftCardPDP(controls);
        }

        [When(@"I add gift cards totalling '(.*)' to my bag")]
        public void WhenIAddGiftCardsTotallingToMyBag(string amount)
        {
            Driver.Navigate().GoToUrl(MainBaseClass.EnvURL + "/harrods/gift-card-500-p000000009999991010?bcid=1486033001292");

            switch (amount)
            {
                case "Less than £2500":
                    pdpTest.SelectQuantityValue("1");
                    break;
                case "More than £2500":
                    pdpTest.SelectQuantityValue("6");
                    break; 
            }

            FindElementByElement(_addtobagbutton).Click();
        }

        [Then(@"a '(.*)' is displayed on screen")]
        public void ThenAIsDisplayedOnScreen(string result)
        {    
            switch (result)
            {
                case "Successful":
                    WaitElementUntil(By.XPath("//*[@class='button button--primary button--arrow-after minibag_checkout']"));
                    break;
                case "Unsuccessful":
                    WaitElementUntil(By.XPath("//*[@class='buying-controls_errors validation-summary-errors js-validation-errors']"));
                    Driver.FindElement(By.XPath("//*[@class='buying-controls_errors validation-summary-errors js-validation-errors']")).Text.Contains("Apologies but the maximum order value for gift cards is £2,500");
                    break;
            }

        }

        [Then(@"I am given the shop more '(.*)'")]
        public void ThenIAmGivenTheShopMore(string options)
        {

            WaitElementUntil(By.XPath("//*[@id=' product_shop-more_gift-cards']"));

            switch (options)
            {
                case "Harrods":
                    Assert.AreEqual(Driver.FindElement(By.XPath("//*[@id=' product_shop-more_harrods']")).Text, options);
                    break;
                case "Gift Cards":
                    Assert.AreEqual(Driver.FindElement(By.XPath("//*[@id=' product_shop-more_gift-cards']")).Text, options);
                    break;
            }         
        }

        [Then(@"the product '(.*)' are displayed")]
        public void ThenTheProductAreDisplayed(string section)
        {
            gcbTest.ValidateSection(section);
        }












    }
}
