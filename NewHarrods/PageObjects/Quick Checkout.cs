using NewHarrods.Classes;
using NewHarrods.Configuration;
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
    #region WebElements
    public class QuickCheckout : BaseTestClass
    {
        private By _paynowbutton = By.XPath("//*[@id='pay-securely-now-button']");
        private By _cardtypedropdown = By.XPath("//*[@name='paymentViewModel.PaymentCardViewModel.SelectedPaymentCardType']");
        private By _cardnumberfield = By.XPath("//*[@id='paymentViewModel_PaymentCardViewModel_CardNumber']");
        private By _cardnamefield = By.XPath("//*[@name='paymentViewModel.PaymentCardViewModel.NameOnCard']");
        private By _expirymonthdropdown = By.XPath("//*[@name='paymentViewModel.PaymentCardViewModel.SelectedExpiryMonth']");
        private By _expiryyeardropdown = By.XPath("//*[@name='paymentViewModel.PaymentCardViewModel.SelectedExpiryYear']");
        private By _cardcvvfield = By.XPath("//*[@name='paymentViewModel.PaymentCardViewModel.SecurityCode']");
        private By _savedcardcombobox = By.XPath("//*[@name='PaymentViewModel.SelectedPaymentCard']");
        private By _antoheraddresscta = By.LinkText("Use Another Address");
        private By _saveddelivaddressradiooption = By.XPath("//*[@name='DeliveryViewModel.SelectedShippingAddress']");
        private By _savedbillingaddressradiooption = By.XPath("//*[@name='PaymentViewModel.SelectedBillingAddress']");
        private By _addnewcardcombo = By.XPath("//*[@id='addNewCard']");
        private By _paypalcombobox = By.XPath("//*[@id='payWithPayPal']");
        private By _paypalbutton1 = By.XPath("//*[@value='Paypal']");
        private By _paypaliconcta = By.ClassName("button--paypal-checkout");
        private By _paypalloginbutton = By.XPath("//*[@id='btnLogin']");
        private By _paypallogoutbutton = By.XPath("//*[@id='header-logout']");
        private By _paypalemailfield = By.XPath("//*[@id='email']");
        private By _paypalpasswordfield = By.XPath("//*[@id='password']");
        private By _paypalpaynowbutton = By.XPath("//*[@id='confirmButtonTop']");
        private By _savedcardcvvfield = By.XPath("//*[@id='PaymentViewModel_SecurityCode']");
        private By _loadingpanel = By.XPath("//*[@class='loading-panel']");
        private By _savedcardcheckbox = By.CssSelector("input[id='PaymentViewModel_SaveCard']");
        private By _currencyDropDown = By.XPath("//*[@id='CurrencyDropdown']");
        private By _alipayiconcta = By.XPath("//*[@class='button button--secondary external-payment_button js-button-alipay']");
        private By _alipayiconcta2 = By.XPath("//*[@class='button button--secondary external-payment_button js-external-payment-button js-external-payment-button--alipay']");      
        private By _alipayauthbutton = By.XPath("//*[@value='authorised']");
        private By _alipayContinue = By.XPath("//*[@value='Continue']");
        private By _countryselectorinput = By.XPath("//*[@class='select2-search__field']");
        private By _giftcardcheck = By.XPath("//*[@id='giftCard']");
        private By _giftcardnumber = By.XPath("//*[@id='PaymentViewModel_GiftCardViewModel_CardNumber']");
        private By _giftcardpin = By.XPath("//*[@id='PaymentViewModel_GiftCardViewModel_Pin']");
        private By _giftcardbutton = By.XPath("//*[@value='CheckGiftCardBalance']");
        private By _validategiftcardbalance = By.XPath("//*[@class='use-gc_apply-balance_detail use-gc_apply-balance_detail--balance']");
        private By _validateShipping = By.XPath("//*[@class='field field--secure field--delivery-methods field--required']");
        private By _alipalcombobox = By.XPath("//*[@id='payWithAliPay']");
        //private By _alipayiconcta = By.ClassName("button--alipay-checkout");
        //private By _alipayauthbutton = By.CssSelector("button[value = 'authorised']");
        private By _NextBtn = By.XPath("//*[@id='btnNext']");
        private By _ContinueBtn = By.XPath("//*[@class='btn full confirmButton continueButton']");
        private By _homelogo = By.XPath("//*[@class='harrods-logo_img']");
        private By _giftMessageTxt = By.XPath("//*[@id='DeliveryViewModel_GiftMessage_Message']");
        private By _validategiftMessage = By.XPath("//*[@class='confirmation_detail-row confirmation_detail-row--giftmessage']");
        private By _confirmation = By.XPath("//*[@class='confirmation_left-container']");
        #endregion

        #region Actions
        DynamicElementWait elementNotPresent = new DynamicElementWait();
        public void NewCardEntry(string cardType, string cardNumber, string cardName, string expiryMonth, string expiryYear, string cVV)
        { //Method for quick checkout with new card filling in form (NO Saved Card)
            try
            {
                FindElementByElement(_addnewcardcombo).Click();
            }
            catch(Exception)
            {
                elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
                FindElementByElement(_addnewcardcombo).Click();
            }
            
            FindElementByElement(_cardnumberfield).SendKeys(cardNumber);
            FindElementByElement(_cardnamefield).SendKeys(cardName);

            DropDownSelectText(_expirymonthdropdown, expiryMonth);

            DropDownSelectText(_expiryyeardropdown, expiryYear);

            FindElementByElement(_cardcvvfield).SendKeys(cVV);
            if (Driver.FindElements(_savedcardcheckbox).Count > 0)
            {
                FindElementByElement(_savedcardcheckbox).Click(); 
            }
        }
        public void ClickUseAnotherAddressCTA()
        {
            try
            {
                FindElementByElement(_antoheraddresscta).Click();
            }
            catch (Exception)
            {
                WaitElementUntil(_antoheraddresscta);
                FindElementByElement(_antoheraddresscta).Click();

            }
            WaitElementUntil(_saveddelivaddressradiooption);
            ExplicitWait(1000);
        }
        public void UseAnotherSavedDeliveryAddressIndex(int savedAddressIndex)
        {
            IList<IWebElement> allcombodelivcombos = Driver.FindElements(_saveddelivaddressradiooption);
            allcombodelivcombos.ElementAt(savedAddressIndex).Click();
            ExplicitWait(1000);
            elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
            ExplicitWait(1000);
        }
        public void UseNamedCountryAddress(string country)
        {
            ExplicitWait(1000);
            //  IList<IWebElement> savedaddresslabels = Driver.FindElement(By.CssSelector("div[class='field field--3 field--delivery field--address-book field--required js-option-hidden-panel']")).FindElements(By.CssSelector("label[class='field_label field_label--3 field_label--inline field_label--delivery-address-option']"));
            IList<IWebElement> savedaddresslabels = Driver.FindElement(By.XPath("//*[@class='field field--secure field--delivery field--address-book field--required js-option-hidden-panel ']")).FindElements(By.XPath("//*[@class='field_label field_label--secure field_label--inline field_label--delivery-address-option']"));
            foreach (var savedaddresslabel in savedaddresslabels)
            {
                if (savedaddresslabel.Text.Contains(country))
                {
                    try
                    {
                        savedaddresslabel.Click();                        
                    }
                    catch (Exception)
                    {
                        elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
                        ExplicitWait(2000);
                        savedaddresslabel.Click();                        
                    }
                    elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
                    ExplicitWait(2000);
                    break;
                }
            }         
        }
        public void UseAnotherSavedBillingAddress(int savedAddressIndex)
        {
            WaitElementUntil(_savedbillingaddressradiooption);
            IList<IWebElement> alldelivcombos = Driver.FindElements(_savedbillingaddressradiooption);
            alldelivcombos.ElementAt(savedAddressIndex).Click();
        }
        public void PayWithPaypal(string deliveryType)
        {
            string paypalUser = "boltuat4.harrods@harrods.com";
            string paypalPassword = "Today2013";

            if (deliveryType == "Borderfree ROW" || deliveryType == "Borderfree China")
            {
                Driver.FindElement(By.XPath("//*[@id='select2-CurrencyDropdown-container']")).Click();
                Driver.FindElement(_countryselectorinput).SendKeys("USD");
                FindElementCustom("li", "USD").Click();
            }
            

            IJavaScriptExecutor jsexecuter = (IJavaScriptExecutor)Settings.ObjectRepository.Driver;
            try
            {
                ExplicitWait(4000);
                WaitElementUntil(_paypalbutton1);
                FindElementByElement(_paypalbutton1).Click();
                ExplicitWait(5000);
                FindElementByElement(_paypalbutton1).Click();
            }
            catch
            { }
            
            ExplicitWait(6000);

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
                WaitElementUntil(_ContinueBtn);
                FindElementByElement(_ContinueBtn).Click();
                ExplicitWait(3000);
                WaitElementUntil(_paypalpaynowbutton);
                ExplicitWait(3000);

                FindElementByElement(_paypalpaynowbutton).Click();              
            }
            catch (Exception e)
            {
                Driver.Url = "https://www.sandbox.paypal.com";
                FindElementByElement(_paypallogoutbutton).Click();
                Assert.Fail("Acceptance Failed At: " + e);
            }

            ExplicitWait(14000);
            WaitElementUntil(By.ClassName("secure_header-title"));

            Driver.Url = "https://www.sandbox.paypal.com";
            FindElementByElement(_paypallogoutbutton).Click();

        }
        public void PayWithAliPay()
        {
            elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loading-panel ")));

            try
            {
                FindElementByElement(_alipayiconcta2).Click();
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

        public void SelectSavedCardArray(int savedCardIndex, string cvv)
        {
            IList<IWebElement> allsavedcardcombos = Driver.FindElements(_savedcardcombobox);
            try
            {
                allsavedcardcombos.ElementAt(savedCardIndex).Click();
            }
            catch(Exception)
            {
                elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
                allsavedcardcombos = Driver.FindElements(_savedcardcombobox);
                allsavedcardcombos.ElementAt(savedCardIndex).Click();
            }
            FindElementByElement(_savedcardcvvfield).SendKeys(cvv);
        }
        public void SelectSpecifiedCard(string userCard, string cvv)
        {
            elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
            ExplicitWait(3000);
            IList<IWebElement> savedcardlabels = Driver.FindElement(By.XPath("//*[@class='field_radio-group field_radio-group--secure js-quick-checkout-payment-methods']")).FindElements(By.XPath("//*[@class='field_label field_label--secure field_label--inline field_label--billing-address-option ']"));
            foreach (var savedcardlabel in savedcardlabels)
            {
                if(savedcardlabel.Text.Contains(userCard))
                {
                    try
                    {
                        elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
                        savedcardlabel.Click();
                    }
                    catch(Exception)
                    {
                        elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
                        ExplicitWait(200);
                        savedcardlabel.Click();
                    }
                    FindElementByElement(_savedcardcvvfield).SendKeys(cvv);
                    break;
                }
            }
            
        }
        #endregion
        #region Navigation
        public void ClickPayNow()
        {//Method clicks pay now button, use after form completion
            FindElementByElement(_paynowbutton).Submit();
            ExplicitWait(12000);
            WaitElementUntil(_confirmation);
        }
        #endregion

        public void GiftMessage(string message)
        {
            FindElementCustom("a", "Add a Gift Message").Click();
            FindElementByElement(_giftMessageTxt).SendKeys(message);
        }

        public void ValidateGiftMessage(string message)
        {
            ExplicitWait(5000);
            WaitElementUntil(_validategiftMessage);
            Assert.AreEqual(FindElementByElement(_validategiftMessage).Text, message);
        }

        public void UseGiftcard()
        {
            FindElementByElement(_giftcardcheck).Click();
            FindElementByElement(_giftcardnumber).SendKeys("7777008277109110");
            FindElementByElement(_giftcardpin).SendKeys("2158");
            FindElementByElement(_giftcardbutton).Click();
        }

        public void ValidateGiftcardBalance()
        {
            WaitElementUntil(_validategiftcardbalance);
            FindElementByElement(_validategiftcardbalance).Text.Contains("Gift Card Balance");
        }

        public void ValidateShipping(string shipping)
        {
            FindElementByElement(_validateShipping).Text.Contains(shipping);
        }

}


}
