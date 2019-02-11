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
   public class SignIn :BaseTestClass
    {
        //Calling out the WebElements on the page
        #region WebElement 
        private By _signinlink = By.XPath("//*[@class='header-account_link header-account_link--sign-in']");
        private By _emailfield = By.XPath("//*[@name='EmailAddress']");
        private By _passwordfield = By.XPath("//*[@name='Password']");
        private By _signinbutton = By.XPath("//*[@class='button button--action button--arrow-after']");
        private By _addaddressbutton = By.XPath("//*[@class='account-manage-item_add-button button button--action button--arrow-after']");
        private By _addcardbutton = By.XPath("//*[@class='account-manage-item_add-button button button--action button--arrow-after']");
        private By _addcardbtn = By.XPath("//*[@value='Add Card']");

        private By _countryselectordropdown = By.XPath("//*[@name='Address.CountryCode']");
        private By _countryselectorinput = By.XPath("//*[@class='select2-search__field']");
        private By _addresslineonefield = By.XPath("//*[@name='Address.AddressLine1']");
        private By _cityfield = By.XPath("//*[@name='Address.City']");
        private By _postcodefield = By.XPath("//*[@name='Address.Postcode']");
        private By _regiondropdown = By.XPath("//*[@name='Address.RegionCode']");

        private By _cardtypedropdown = By.XPath("//*[@name='PaymentCardViewModel.SelectedPaymentCardType']");
        private By _cardnumberfield = By.XPath("//*[@id='PaymentCardViewModel_CardNumber']");
        private By _cardnamefield = By.XPath("//*[@name='PaymentCardViewModel.NameOnCard']");
        private By _expirymonthdropdown = By.XPath("//*[@name='PaymentCardViewModel.SelectedExpiryMonth']");
        private By _expiryyeardropdown = By.XPath("//*[@name='PaymentCardViewModel.SelectedExpiryYear']");
        private By _cardcvvfield = By.XPath("//*[@name='PaymentCardViewModel.SecurityCode']");


        private By _manageaddress = By.XPath("//*[@class='account-manage_set-preferred']");
        

        private By _deliverymethodcomboboxes = By.XPath("//*[@name='ShippingMethodsList.SelectedShippingMethod']");
        private By _remove = By.XPath("//*[@value='Remove']");
        private By _yes = By.XPath("//*[@class='modal_button modal_button--warning modal_button--submit button button--action js-modal-warning-yes']");
        

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

        //This is a log in method where user can specifiy credentials to be used throughtout testing in config file
        public void Login()
        {
            IConfig ConfigCredentials = new AppConfigReader();            
            FindElementByElement(_emailfield).SendKeys(ConfigCredentials.GetUsername());
            FindElementByElement(_passwordfield).SendKeys(ConfigCredentials.GetPassword());
            FindElementByElement(_signinbutton).Submit();
            WaitElementUntil(By.XPath("//*[@class='portal-dashboard_content']"));
        }
        //This is a log in method where user can use default hardcoded values if they do not care besides specifiying rewards or not.
        public void Login(string defaultAccount)
        {
                WaitElementUntil(_emailfield);
                FindElementByElement(_emailfield).SendKeys("Test"+ defaultAccount + "account"+ "@harrodstest.com");//These need setting up across all env!!
                FindElementByElement(_passwordfield).SendKeys("Welcome123");
            try
            {
                FindElementByElement(_signinbutton).Submit();
                WaitElementUntil(By.XPath("//*[@class='portal-dashboard_content']"));
            }
            catch
            {
                Console.WriteLine("Click TimeOut");
                WaitElementUntil(By.XPath("//*[@class='portal-dashboard_content']"));
            }
            
            WaitElementUntil(By.XPath("//h1[contains(text(),'Welcome')]"));
        }

        //This is a log in method for hard coded logins, for more specific tests like negative scenarios etc.
        public void Login(string email, string password)
        {
            WaitElementUntil(_emailfield);
            FindElementByElement(_emailfield).SendKeys(email);
            FindElementByElement(_passwordfield).SendKeys(password);
            FindElementByElement(_signinbutton).Submit();
            if (password != "InvalidPword") {
                WaitElementUntil(By.XPath("//*[@class='portal-dashboard_content']"));
            }
            }

        public void Login(string email, string password, string desc)
        {
            WaitElementUntil(_emailfield);
            FindElementByElement(_emailfield).SendKeys(email);
            FindElementByElement(_passwordfield).SendKeys(password);
            FindElementByElement(_signinbutton).Submit();
         }
        #endregion

        #region Navigation

        public void ManageAddress()
        {
            FindElementCustom("a", "Manage Delivery Addresses").Click();
        }

        public void ManageCard()
        {
            FindElementCustom("a", "Manage Cards and Billing Addresses").Click();
        }

        public void AddAddress()
        {
            WaitElementUntil(_addaddressbutton);
            FindElementByElement(_addaddressbutton).Click();
        }

        public void AddCard()
        {
            WaitElementUntil(_addcardbutton);
            FindElementByElement(_addcardbutton).Click();
        }

        public void ValidateAddress()
        {
            FindElementCustom("button", "Add Address").Click();
           
            WaitElementUntil(_manageaddress);
            FindElementCustom("h1", "Manage Delivery Addresses");
            ExplicitWait(4000);
            WaitElementUntil(_remove);
            FindElementByElement(_remove).Click();
            WaitElementUntil(_yes);
            FindElementByElement(_yes).Click();
        }

        public void ValidateCard()
        {
            FindElementByElement(_addcardbtn).Click();

            WaitElementUntil(_manageaddress);
            FindElementCustom("h1", "Manage Cards and Billing Addresses");
            ExplicitWait(4000);
            FindElementCustom("button", "Remove").Click();
            //FindElementByElement(_remove).Click();
            WaitElementUntil(_yes);
            FindElementByElement(_yes).Click();
        }

        public void DeliveryInfo(string deliveryType)
        {
            ExplicitWait(3000);

            Driver.FindElement(By.XPath("//*[@id='select2-Address_CountryCode-container']")).Click();
            Driver.FindElement(_countryselectorinput).SendKeys(Country);
            //Driver.FindElement(_countryselectorinput).SendKeys(Keys.Enter);
            FindElementCustom("li", Country).Click();


            ExplicitWait(1500);
            FindElementByElement(_addresslineonefield).SendKeys(Street);
            FindElementByElement(_cityfield).SendKeys(City);
           

            if (deliveryType == "Borderfree US")
            {
                DropDownSelectText(_regiondropdown, State);

            }

            if (deliveryType == "UK")
            {
                FindElementByElement(_postcodefield).SendKeys(UKPostcode);
            }
            else
            {
                FindElementByElement(_postcodefield).SendKeys(Zipcode);
            }

            ExplicitWait(5000);           
        }

        public void CompleteCardInfo(string cardType, string cardNumber, string cardName, string expiryMonth, string expiryYear, string cVV)
        {
            try
            {
                DropDownSelectText(_cardtypedropdown, cardType);
            }
            catch (Exception)
            {
                WaitElementUntil(_cardtypedropdown);
                DropDownSelectText(_cardtypedropdown, cardType);
            }
            WaitElementUntil(_cardnumberfield);
            FindElementByElement(_cardnumberfield).SendKeys(cardNumber);
            FindElementByElement(_cardnamefield).SendKeys(cardName);

            DropDownSelectText(_expirymonthdropdown, expiryMonth);
            DropDownSelectText(_expiryyeardropdown, expiryYear);

            FindElementByElement(_cardcvvfield).SendKeys(cVV);
        }

        #endregion
    }
}
