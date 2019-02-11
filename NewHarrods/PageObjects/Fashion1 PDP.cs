using NewHarrods.Classes;
using NewHarrods.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class Fashion1PDP : BaseTestClass
    {
        //Calling out the WebElements on the page
        #region WebElement 
        private By _addtobagbutton = By.XPath("//*[@value='Add to Bag']");
        private By _sizedropdown = By.ClassName("buying-controls_select--size");
        private By _quantitydropdown = By.ClassName("field_dropdown--quantity");
        private By _signinbutton = By.XPath("//*[@id=\"main\"]/div/section[1]/form/button");
        private By _checkoutbutton = By.XPath("//*[@class='button button--primary button--arrow-after minibag_checkout']");
        private By _loadingpanel = By.XPath("//*[@class='loading-panel']");
        #endregion

        #region Actions
        public void AddToBag() //This method will work for default values on PDP or used after quantity/size method selection
        {
            DynamicElementWait pdpWaits = new DynamicElementWait();

            WaitElementClickable(_addtobagbutton);

            FindElementByElement(_addtobagbutton).Click();
            
            
            WaitElementUntil(_checkoutbutton);
            ExplicitWait(1000);
        }
        public void SelectSizeValue() //Selects first value below default
        {
            DropDownSelectIndex(_sizedropdown, 1);
        }
        public void SelectSizeValue(string sizeValue) //Selects user inputted value
        {
            DropDownSelectText(_sizedropdown, sizeValue);
        }
        public void SelectQuantityValue() //Selects first value below default
        {
            DropDownSelectIndex(_quantitydropdown, 1);
        }
        public void SelectQuantityValue(string quantityInt) //Selects user inputted value
        {
            DropDownSelectValue(_quantitydropdown, quantityInt);
        }
        #endregion
    }
}
