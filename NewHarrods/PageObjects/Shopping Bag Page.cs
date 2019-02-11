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
    public class ShoppingBagPage : BaseTestClass
    {
        #region WebElement
        private By _securecheckoutbutton = By.XPath("//*[@class='button button--primary button--action button--arrow-after js-button-loading']");
        private By _shoppingbagitems = By.XPath("//*[@class='sbag_item']");
        private By _quantitydropdown = By.XPath("//*[@class='field_dropdown field_dropdown--quantity']");
        private By _removeitemcta = By.XPath("//*[@class='sbag_item-edit-link sbag_item-edit-link--remove button-text-link']");
        private By _countrydropdown = By.XPath("//*[@name='CountryCode']");
        private By _shippingdropdown = By.XPath("//*[@name='SelectedShippingMethodId']");
        private By _mybagicon = By.XPath("//*[@class='minibag_link']");
        #endregion

        #region Action 
        
        public void UpdateQuantity() //Here I'm accessing the first item in the shopping bag and then amending the quantity to the value below default
        {
            IList <IWebElement> shoppingBagElements = Driver.FindElements(_shoppingbagitems);
            var firstitem = shoppingBagElements.ElementAt(0);
            DropDownSelectIndex(_quantitydropdown, 1);
        }
        public void UpdateQuantity(string quantityIndex, int itemLineIndex) //Here I'm accessing the first item in the shopping bag and then amending the quantity to the value below default
        {
            IList<IWebElement> shoppingBagElements = Driver.FindElements(_shoppingbagitems);
            var firstitem = shoppingBagElements.ElementAt(itemLineIndex);
            DropDownSelectValue(_quantitydropdown, quantityIndex);
        }
        public void RemoveItem() //Here I'm accessing user defined item line in the shopping bag and then removing the product
        {
            IList<IWebElement> shoppingBagElements = Driver.FindElements(_shoppingbagitems);
            var firstItem = shoppingBagElements.ElementAt(0);
            IWebElement bagremoveitem = firstItem.FindElement(_removeitemcta);
            bagremoveitem.Click();
        }
        public void RemoveItem(int itemLineIndex) //Here I'm accessing user defined item line in the shopping bag and then removing the product
        {
            IList<IWebElement> shoppingBagElements = Driver.FindElements(_shoppingbagitems);
            var firstitem = shoppingBagElements.ElementAt(itemLineIndex);
            IWebElement bagremoveitem = firstitem.FindElement(_removeitemcta);
            bagremoveitem.Click();
        }
        public void UpdateDeliveryCountry(string country) //This a user can enter a country string value in the method to change delivery country on bag page (Don't use this method to leave UK default)
        {
            DropDownSelectText(_countrydropdown, country);
        }
        public void UpdateShippingMethod(int methodIndex) //This a user can enter integer value in the method to change delivery method(for UK) on bag page (Don't use this method to leave UK default)
        {
            DropDownSelectIndex(_shippingdropdown, methodIndex);
        }
        #endregion

        #region Navigation
        public void GoShoppingBagPage()
        {
            ExplicitWait(1000);
            FindElementByElement(_mybagicon).Click();
        }
        public void GoToCheckout() // This navigates user to checkout
        {
            IJavaScriptExecutor jsexecuter = (IJavaScriptExecutor)ObjectRepository.Driver;
            IWebElement buttonlocation = FindElementByElement(_securecheckoutbutton);
            int buttonlocationadjusted = buttonlocation.Location.Y - 300;
            jsexecuter.ExecuteScript("window.scrollTo(0," + buttonlocationadjusted + ")");
            buttonlocation.Click();
        }
        #endregion
    }
}
