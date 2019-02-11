using NewHarrods.Classes;
using NewHarrods.Configuration;
using NewHarrods.Settings;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class CheckoutPayment : BaseTestClass
    {
        #region WebElements
        private By _paynowbutton = By.XPath("//*[@class='button button--pay button--secure button--action']");
        private By _cardtypedropdown = By.XPath("//*[@name='PaymentCardViewModel.SelectedPaymentCardType']");
        private By _cardnumberfield = By.XPath("//*[@id='PaymentCardViewModel_CardNumber']");
        private By _cardnamefield = By.XPath("//*[@name='PaymentCardViewModel.NameOnCard']");
        private By _expirymonthdropdown = By.XPath("//*[@name='PaymentCardViewModel.SelectedExpiryMonth']");
        private By _expiryyeardropdown = By.XPath("//*[@name='PaymentCardViewModel.SelectedExpiryYear']");
        private By _cardcvvfield = By.XPath("//*[@name='PaymentCardViewModel.SecurityCode']");
        private By _savecardcheckbox = By.XPath("//*[@name='PaymentViewModel.SaveCard']");
        private By _giftcardcheckbox = By.XPath("//*[@id='giftCard']");
        private By _giftcardnofield = By.XPath("//*[@name='CardNumber']");
        private By _giftcardpinfield = By.XPath("//*[@name='Pin']");
        private By _giftcardcheckbalance = By.XPath("//*[@name='GiftCardAction']");
        private By _addnewaddresscombo = By.XPath("//*[@for='addNewBillingAddress']");
        private By _countryselectordropdown = By.XPath("//*[@name='BillingAddress.CountryCode']");
        private By _addresslineonefield = By.XPath("//*[@name='BillingAddress.AddressLine1']");
        private By _cityfield = By.XPath("//*[@name='BillingAddress.City']");
        private By _postcodefield = By.XPath("//*[@name='BillingAddress.Postcode']");
        private By _paypaliconcta = By.XPath("//*[@value='Paypal']");
        private By _paypalloginbutton = By.XPath("//*[@id='btnLogin']");
        private By _paypallogoutbutton = By.XPath("//*[@id='header-logout']");
        private By _paypalemailfield = By.XPath("//*[@id='email']");
        private By _paypalpasswordfield = By.XPath("//*[@id='password']");
        private By _paypalpaynowbutton = By.XPath("//*[@id='confirmButtonTop']");
        private By _currencyDropDown = By.XPath("//*[@id='CurrencyDropdown']");
        private By _alipayiconcta = By.XPath("//*[@class='button button--secondary external-payment_button js-button-alipay']");
        private By _alipayauthbutton = By.XPath("//*[@value='authorised']");
        private By _alipayContinue = By.XPath("//*[@value='Continue']");
        private By _NextBtn = By.XPath("//*[@id='btnNext']");
        private By _ContinueBtn = By.XPath("//*[@class='btn full confirmButton continueButton']");
        private By _homelogo = By.XPath("//*[@class='harrods-logo_img']");
        #endregion

        #region Actions   
        DynamicElementWait elementNotPresent = new DynamicElementWait();
        public void CompleteCardPaymentInfo(string cardType, string cardNumber, string cardName, string expiryMonth, string expiryYear, string cVV)
        {//MEthod to complete payment form with user defined values
            //try
            //{
            //    DropDownSelectText(_cardtypedropdown, cardType);
            //}
            //catch (Exception)
            //{
            //    WaitElementUntil(_cardtypedropdown);
            //    DropDownSelectText(_cardtypedropdown, cardType);
            //}
            WaitElementUntil(_cardnumberfield);
            FindElementByElement(_cardnumberfield).SendKeys(cardNumber);
            FindElementByElement(_cardnamefield).SendKeys(cardName);

            DropDownSelectText(_expirymonthdropdown, expiryMonth);
            DropDownSelectText(_expiryyeardropdown, expiryYear);

            FindElementByElement(_cardcvvfield).SendKeys(cVV);
        }

        public void NewBillingAdress(string country, string street, string city, string postcode)
        {//Method to complete a new billing address with user defined values
            FindElementByElement(_addnewaddresscombo).Click();
            WaitElementUntil(_countryselectordropdown);
            DropDownSelectText(_countryselectordropdown, country);
            FindElementByElement(_addresslineonefield).SendKeys(street);
            FindElementByElement(_cityfield).SendKeys(city);
            FindElementByElement(_postcodefield).SendKeys(postcode);
        }
        public void RedeemGiftCard(string GiftCardNo, string GiftCardPin)
        {//Method to redeem gift card with user defined values
            FindElementByElement(_giftcardcheckbox).Click();
            WaitElementUntil(_giftcardnofield);
            FindElementByElement(_giftcardnofield).SendKeys(GiftCardNo);
            FindElementByElement(_giftcardpinfield).SendKeys(GiftCardPin);
            FindElementByElement(_giftcardcheckbalance).Click();
        }
        public void GuestPaypPalPayment(string paypalUser = "boltuat4.harrods@harrods.com", string paypalPassword = "Today2013")
        {

            IJavaScriptExecutor jsexecuter = (IJavaScriptExecutor)ObjectRepository.Driver;
            try
            {
                WaitElementUntil(_paypaliconcta);
                FindElementByElement(_paypaliconcta).Click();
            }
            catch
            {
                Console.WriteLine("Click TimeOut");
            }

            ExplicitWait(5000);
            
            WaitElementUntil(_paypalemailfield);
            FindElementByElement(_paypalemailfield).Clear();
            FindElementByElement(_paypalemailfield).SendKeys(paypalUser);
            FindElementByElement(_NextBtn).Click();
            WaitElementUntil(_paypalpasswordfield);
            FindElementByElement(_paypalpasswordfield).SendKeys(paypalPassword);
                
            FindElementByElement(_paypalloginbutton).Click();

            ExplicitWait(10000);
            try
            {
                WaitElementClickable(_ContinueBtn);
                FindElementByElement(_ContinueBtn).Click();
                WaitElementClickable(_paypalpaynowbutton);
                ExplicitWait(3000);

                FindElementByElement(_paypalpaynowbutton).Click();
                WaitElementUntil(By.ClassName("secure_header-title"));
            }
            catch (Exception e)
            {
                Driver.Url = "https://www.sandbox.paypal.com";
                FindElementByElement(_paypallogoutbutton).Click();
                Driver.Manage().Cookies.DeleteAllCookies();
                Assert.Fail("Acceptance Failed At: " + e);
            }

            Driver.Url = "https://www.sandbox.paypal.com";
            FindElementByElement(_paypallogoutbutton).Click();
            Driver.Manage().Cookies.DeleteAllCookies();


        }
        public void PayWithAliPayGuest()
        {
            elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loading-panel ")));

            try
            {
                FindElementByElement(_alipayiconcta).Click();
            }
            catch
            {
                Console.WriteLine("Click TimeOut");
            }

            WaitElementUntil(_alipayContinue);
            FindElementByElement(_alipayContinue).Click();

            WaitElementUntil(_alipayauthbutton);
            FindElementByElement(_alipayauthbutton).Click();
            WaitElementUntil(_homelogo);
            FindElementByElement(_homelogo).Click();
            
        }
        #endregion
        #region Navigation
        public void ClickPayNow()
        {//Method that will click pay now
            FindElementByElement(_paynowbutton).Submit();
            ExplicitWait(10000);
            WaitElementUntil(By.ClassName("secure_header-title"));
        }
        #endregion
    }
}
