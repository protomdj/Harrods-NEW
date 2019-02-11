using NewHarrods.Classes;
using NewHarrods.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class GiftCardBalance :BaseTestClass
    {
        ScreenShot scTool = new ScreenShot();

        //Calling out the WebElements on the page
        #region WebElement 
        private By _giftcardnumber = By.XPath("//*[@name='CardNumber']");
        private By _giftcardnumbererror = By.XPath("//*[@id='CardNumber-error']");
        private By _giftpinerror = By.XPath("//*[@id='Pin-error']");
        private By _giftcardpin = By.XPath("//*[@name='Pin']");
        private By _checkbalancebutton = By.XPath("//*[@value='Check Balance']");
        private By _overview = By.XPath("//*[@class='product-info_overview js-accordion-product-details']");
        private By _details = By.XPath("//*[@class='product-info_details js-accordion-product-details']");
        #endregion

        #region Data        
        public string giftCardNumber { get; set; }
        public string giftCardPin { get; set; }
        #endregion

        #region Action
        public void EnterGiftCardBalance()
        {
            FindElementByElement(_giftcardnumber).SendKeys("7777087282549046");
            FindElementByElement(_giftcardpin).SendKeys("6880");
            FindElementByElement(_checkbalancebutton).Click();
            ExplicitWait(2000);
        }

        public void EnterInvalidGiftCardNumber(string type)
        {
            switch (type)
            {
                case "Empty":
                    giftCardNumber = "";
                    break;
                case "15 digits":
                    giftCardNumber = "777708728254904";
                    break;
                case "17 digits":
                    giftCardNumber = "77770872825490468";
                    break;
                case "invalid characters":
                    giftCardNumber = "A777708728254904";
                    break;                   
            }
            FindElementByElement(_giftcardnumber).SendKeys(giftCardNumber);
            FindElementByElement(_giftcardpin).SendKeys("6880");
            WaitElementUntil(_checkbalancebutton);
            FindElementByElement(_checkbalancebutton).Click();
        }

        public void ValidateGiftCardNumberError(string message)
        {
            WaitElementUntil(_giftcardnumbererror);
            Assert.AreEqual(message, FindElementByElement(_giftcardnumbererror).Text);
        }

        public void EnterInvalidGiftCardPin(string type)
        {
            switch (type)
            {
                case "Empty":
                    giftCardPin = "";
                    break;
                case "3 digits":
                    giftCardPin = "688";
                    break;
                case "5 digits":
                    giftCardPin = "68800";
                    break;
                case "invalid characters":
                    giftCardPin = "A688";
                    break;
            }
            FindElementByElement(_giftcardpin).SendKeys(giftCardPin);
            FindElementByElement(_giftcardnumber).SendKeys("7777087282549046");
            WaitElementUntil(_checkbalancebutton);
            FindElementByElement(_checkbalancebutton).Click();
        }

        public void ValidateGiftCardPinError(string message)
        {
            WaitElementUntil(_giftpinerror);
            Assert.AreEqual(message, FindElementByElement(_giftpinerror).Text);
        }

        public void ValidateGiftBalancePage()
        {
            WaitElementUntil(By.XPath("//*[@class='panel panel--success']"));

            try
            {
                Driver.FindElement(By.XPath("//*[@class='panel panel--success']"));
                Driver.FindElement(By.XPath("//*[@class='price']"));
                Driver.FindElement(By.XPath("//*[@class='panel_icon']"));
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("Gift Card");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        public void ValidateGiftCardPDP(string controls)
        {
            WaitElementUntil(By.XPath("//*[@id='controls_delivery']"));

            switch (controls)
            {
                case "Harrods Brand":
                    Driver.FindElement(By.XPath("//*[@class='buying-controls_brand']")).Text.Contains("Harrods");                
                    break;
                case "Title":
                    Driver.FindElement(By.XPath("//*[@class='buying-controls_name']")).Text.Contains("Gift Card");
                    break;
                case "Price":
                    Driver.FindElement(By.XPath("//*[@class='price_amount']"));                  
                    break;
                case "ID":
                    Driver.FindElement(By.XPath("//*[@class='buying-controls_prodID js-buying-control-prodID']")).Text.Contains(controls);                 
                    break;
                case "Quantity":
                    Assert.AreEqual("Quantity", Driver.FindElement(By.XPath("//*[@class='field_label buying-controls_label buying-controls_label--quantity']")).Text);
                    break;
                case "UK Only Delivery Message":
                    Assert.AreEqual("UK Delivery Only", Driver.FindElement(By.XPath("//*[@class='product-attribute-list_item-text']")).Text);
                    break;
                case "Delivery & Returns link":
                    Assert.AreEqual("Delivery & Returns", Driver.FindElement(By.XPath("//*[@id='controls_delivery']")).Text);
                    break;
            }
        }

        public void ValidateSection(string section)
        {
            switch (section)
            {
                case "details":
                    WaitElementUntil(_details);
                    break;
                case "overwiew":
                    WaitElementUntil(_overview);
                    break;
            }
        }
        #endregion

    }
}
