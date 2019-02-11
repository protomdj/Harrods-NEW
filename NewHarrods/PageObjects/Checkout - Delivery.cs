using NewHarrods.Classes;
using NewHarrods.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class CheckoutDelivery : BaseTestClass
    {
        #region WebElements
        
        private By _countryselectorinput = By.XPath("//*[@class='select2-search__field']");

        private By _countryselectordropdown = By.XPath("//*[@name='ShippingAddress.CountryCode']");
        private By _addresslineonefield = By.XPath("//*[@name='ShippingAddress.AddressLine1']");
        private By _cityfield = By.XPath("//*[@name='ShippingAddress.City']");
        private By _postcodefield = By.XPath("//*[@name='ShippingAddress.Postcode']");



        private By _deliverymethodcomboboxes = By.XPath("//*[@name='ShippingMethodsList.SelectedShippingMethod']");
        private By _giftmessagecheckbox = By.XPath("//*[@name='GiftMessage.AddGiftMessage']");
        private By _continuepayementbutton = By.XPath("//*[@name='btnContinueToPayment']");
        private By _regiondropdown = By.XPath("//*[@name='ShippingAddress.RegionCode']");
        private By _loadingpanel = By.XPath("//*[@class='loading-panel']");
        private By _savedadresses = By.XPath("//*[@name='SelectedShippingAddress']");
        private By _currencyDropDown = By.XPath("//*[@id='CurrencyDropdown']");
        #endregion

        #region Data        
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string UKPostcode { get; set; }
        public int DeliveryMethodIndex { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        #endregion

        #region Actions
        DynamicElementWait elementNotPresent = new DynamicElementWait();
        public void CompleteMandatoryUKDeliveryInfo()
        {//Method to complete mandatory delivery page fields           
            if (Driver.FindElements(By.XPath("//*[@id='addNewShippingAddress']")).Count > 0)
            {
                Driver.FindElements(_savedadresses).Last().Click();
            }

            ExplicitWait(3000);

                Driver.FindElement(By.XPath("//*[@id='select2-ShippingAddress_CountryCode-container']")).Click();
                Driver.FindElement(_countryselectorinput).SendKeys(Country);
                Driver.FindElement(_countryselectorinput).SendKeys(Keys.Enter);

                ExplicitWait(1500);
                FindElementByElement(_addresslineonefield).SendKeys(Street);
                FindElementByElement(_cityfield).SendKeys(City);
                FindElementByElement(_postcodefield).SendKeys(UKPostcode);
      
            ExplicitWait(5000);

        }
        public void CompleteMandatoryNADeliveryInfo()
        {
            if (Driver.FindElements(By.XPath("//*[@id='addNewShippingAddress']")).Count > 0)
            {
                Driver.FindElements(_savedadresses).Last().Click();
            }

                ExplicitWait(4000);
                Driver.FindElement(By.XPath("//*[@id='select2-ShippingAddress_CountryCode-container']")).Click();
                Driver.FindElement(_countryselectorinput).SendKeys(Country);
                FindElementCustom("li", Country).Click();

                ExplicitWait(1500);
                FindElementByElement(_addresslineonefield).SendKeys(Street);
                FindElementByElement(_cityfield).SendKeys(City);
                DropDownSelectText(_regiondropdown, State);
                FindElementByElement(_postcodefield).SendKeys(Zipcode);

                DropDownSelectValue(_currencyDropDown, "USD");

            ExplicitWait(5000);
           // elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
        }
        public void CompleteMandatoryROWDeliveryInfo()
        {//Method to complete mandatory delivery page fields
            if (Driver.FindElements(By.XPath("//*[@id='addNewShippingAddress']")).Count > 0)
            {
                Driver.FindElements(_savedadresses).Last().Click();
            }

                ExplicitWait(4000);
                Driver.FindElement(By.XPath("//*[@id='select2-ShippingAddress_CountryCode-container']")).Click();
                Driver.FindElement(_countryselectorinput).SendKeys(Country);
                FindElementCustom("li", Country).Click();

                //DropDownSelectText(_countryselectordropdown, Country);
                ExplicitWait(2000);
                FindElementByElement(_addresslineonefield).SendKeys(Street);
                FindElementByElement(_cityfield).SendKeys(City);
                FindElementByElement(_postcodefield).SendKeys(Zipcode);

                ExplicitWait(2000);
                Driver.FindElement(By.XPath("//*[@id='select2-CurrencyDropdown-container']")).Click();
                Driver.FindElement(_countryselectorinput).SendKeys("USD");
                FindElementCustom("li", "USD").Click();
      

            ExplicitWait(5000);
        }

        public void CompleteROWAddressWithCurrency(string currency)
        {
            if (Driver.FindElements(By.XPath("//*[@id='addNewShippingAddress']")).Count > 0)
            {
                Driver.FindElements(_savedadresses).Last().Click();
            }
            
            //ExplicitWait(3000);
            //Driver.FindElement(By.XPath("//*[@id='select2-ShippingAddress_CountryCode-container']")).Click();
            //Driver.FindElement(_countryselectorinput).SendKeys(Country);
            //Driver.FindElement(_countryselectorinput).SendKeys(Keys.Enter);

            WaitElementUntil(_addresslineonefield);
            Driver.FindElement(By.XPath("//*[@id='select2-ShippingAddress_CountryCode-container']")).Click();
            Driver.FindElement(_countryselectorinput).SendKeys(Country);
            FindElementCustom("li", Country).Click();

            //DropDownSelectText(_countryselectordropdown, Country);
            ExplicitWait(1500);
            FindElementByElement(_addresslineonefield).SendKeys(Street);        
            FindElementByElement(_cityfield).SendKeys(City);
            FindElementByElement(_postcodefield).SendKeys(Zipcode);

            ExplicitWait(2000);
            Driver.FindElement(By.XPath("//*[@id='select2-CurrencyDropdown-container']")).Click();
            Driver.FindElement(_countryselectorinput).SendKeys(currency);
            FindElementCustom("li", currency).Click();

            //DropDownSelectValue(_currencyDropDown, currency);
            //ExplicitWait(5000);
            // elementNotPresent.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
        }

        #endregion

        #region Navigation
        public void GoToPaymentPage()
        { //This needs to be used after the field completion method is called to navigate to the next page.
            try
            {
                FindElementByElement(_continuepayementbutton).Click();
            }
            catch { }


            ExplicitWait(5000);
        }
        #endregion
    }
}
