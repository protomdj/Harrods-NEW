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
    public class PDP : BaseTestClass
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

        #region controls
        private By _harrodsbrand = By.XPath("//*[@class='buying-controls_brand']");
        private By _title = By.XPath("//*[@class='buying-controls_name']");
        private By _price = By.XPath("//*[@class='price_amount']");
        private By _id = By.XPath("//*[@class='buying-controls_prodID js-buying-control-prodID']");
        private By _colour = By.XPath("//*[@class='buying-controls_value js-buying-controls_value--colour']");
        private By _size = By.XPath("//*[@name='productSize']");
        private By _quantity = By.XPath("//*[@id='ProductQuantity']");
        private By _ukonlydelivery = By.XPath("//*[@class='product-attribute-list_item-text']");
        private By _deliveriesandreturns = By.XPath("//*[@id='controls_delivery']");
        private By _addtobag = By.XPath("//*[@value='Add to Bag']");
        #endregion

        #region sections
        private By _breadcrumbs = By.XPath("//*[@class='breadcrumb_list']");
        private By _overview = By.XPath("//*[@class='product-info_overview js-accordion-product-details']");
        private By _details = By.XPath("//*[@class='product-info_details js-accordion-product-details']");
        private By _shopmore = By.XPath("//*[@class='product-info_shop-more']");
        private By _share = By.XPath("//*[@class='product-info_social']");
        private By _sizeguide = By.XPath("//*[@id='size-guide']");
        private By _deliveryreturns = By.XPath("//*[@id='delivery-and-returns']");
        #endregion

        #region Actions
        public void AddToBag() //This method will work for default values on PDP or used after quantity/size method selection
        {
            WaitElementUntil(_addtobagbutton);
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

        public void ValidatePdpControls(string controls)
        {
            WaitElementUntil(_addtobag);

            switch (controls)
            {
                case "Brand":
                    FindElementByElement(_harrodsbrand);
                    break;
                case "Title":
                    FindElementByElement(_title);
                    break;
                case "Price":
                    FindElementByElement(_price);
                    break;
                case "ID":
                    FindElementByElement(_id).Text.Contains(controls);
                    break;
                case "Quantity":
                    FindElementByElement(_quantity);
                    break;
                case "UK Only Delivery Message":
                    Assert.AreEqual("UK Delivery Only", FindElementByElement(_ukonlydelivery).Text);
                    break;
                case "Delivery & Returns":
                    Assert.AreEqual("Delivery & Returns", FindElementByElement(_deliveriesandreturns).Text);
                    break;
                case "Colour":
                    FindElementByElement(_colour);
                    break;
                case "Size":
                    FindElementByElement(_size);
                    break;
                case "Add To Bag":
                    FindElementByElement(_addtobag);
                    break;
            }
        }

        public void ValidatePdpSection()
        {
            FindElementByElement(_breadcrumbs);
            FindElementByElement(_overview);
            FindElementByElement(_details);
            FindElementByElement(_shopmore);
            FindElementByElement(_share);
            //Fashion1, Pairs
            FindElementByElement(_sizeguide);
            FindElementByElement(_deliveryreturns);
        }

        #endregion
    }
}
