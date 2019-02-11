using NewHarrods.Classes;
using NewHarrods.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class PLP : BaseTestClass
    {
        #region WebElement
        private By _firstproduct = By.XPath("//*[@id=\"main\"]/div/section[2]/section[2]/div/div/section[2]/ul/li[1]/div/div/a");
        private By _allproducts = By.XPath("//*[@class='product-card_link js-product-card_link']");
        private By _quickshopicon = By.XPath("//*[@class='product-card_quick-shop js-button_quick-shop']");
        private By _quickshopquantity = By.XPath("//*[@class='field_dropdown field_dropdown--quantity']");
        private By _quickshopaddtobagbutton = By.XPath("//*[@value='Add to Bag']");
        private By _quickshopfulldetailscta = By.XPath("//*[@id='main']/div/section[2]/section[2]/div/div/section[2]/ul/li[3]/div[2]/div[2]/a");
        private By _quickshopcloseicon = By.XPath("//*[@class='inline-panel_close-icon']");
        private By _loadingpanel = By.XPath("//*[@class='loading-panel']");
        private By _loadingpanelfade = By.XPath("//*[@class='loading-panel fade']");
        private By _view60cta = By.ClassName("plp-view-all");
        private By _sortbydropdown = By.ClassName("sort-controls_dropdown");
        private By _filteroption = By.XPath("//*[@class='filter_item ']");
        private By _lhn = By.XPath("filter-group_list");
        #endregion

        #region Action 
        DynamicElementWait plpObjectWait = new DynamicElementWait();
        public void GoToFirstProduct() // This navigates user to the first product listed on the PLP
        {
            IJavaScriptExecutor jsexecuter = (IJavaScriptExecutor)Driver;
            IWebElement firstproductadjust = FindElementByElement(_firstproduct);
            int firstproducty = firstproductadjust.Location.Y - 300;
            jsexecuter.ExecuteScript("window.scrollTo(0," + firstproducty + ")");
            firstproductadjust.Click();
            plpObjectWait.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
        }
        public void GoToSelectedProduct(int productIndex) //This allows user to pick the item they wish to navigate to by supplying a integer to the method
        {
            IList<IWebElement> productTile = Driver.FindElements(_allproducts);
            var selectedproducttile = productTile.ElementAt(productIndex);
            selectedproducttile.Click();
            plpObjectWait.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanel));
        }
        public void AccessQuickShop(int productIndex)
        {// Method will allow user to access the quick shop of a PLP item
            IList<IWebElement> productTile = Driver.FindElements(_quickshopicon);
            var selectedproducttile = productTile.ElementAt(productIndex);
            ExplicitWait(4000);
            selectedproducttile.Click();
            WaitElementUntil(_quickshopaddtobagbutton);
            ExplicitWait(4000);
        }
        public void QuickShopAddtoBag()
        {//Method that adds item to bag via quickshop with default values
            FindElementByElement(_quickshopaddtobagbutton).Click();
            ExplicitWait(2000);
        }
        public void QuickShopAddtoBag(string quantityValue)
        {//Method that adds item to bag via quickshop with quantity adjustment
            DropDownSelectValue(_quickshopquantity, quantityValue);
        }
        public void CloseQuickShop()
        {
            FindElementByElement(_quickshopcloseicon).Click();
        }
        public bool ClickViewAll()
        {  //Method that clicks the view all functionality, it also checks the number of products displayed matches and returns true if it's correct                           
            string viewallstring = FindElementByElement(_view60cta).Text;
            string viewallcount = Regex.Match(viewallstring, @"\d+").Value;
            FindElementByElement(_view60cta).Click();
            plpObjectWait.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanelfade));
            ExplicitWait(1000);
            int productcard = Driver.FindElements(By.XPath("//*[@class='product-grid_item']")).Count;
            if (int.Parse(viewallcount) == productcard)
            {
                Console.WriteLine("true");
                return true;
            }
            else
            {
                Console.WriteLine("false");
                return false;
            }
        }
        public void SelectSortType(string sortValue)
        {//Method to adjust PLP sort value which is user defined
            DropDownSelectText(_sortbydropdown, sortValue);
            plpObjectWait.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanelfade));
            ExplicitWait(1500);
        }
        public void ApplyFilter(string filterTitle, int filterOptionIndex)
        {
            IJavaScriptExecutor jsexecuter = (IJavaScriptExecutor)Driver;
            jsexecuter.ExecuteScript("var a = " +
            "$('.filter-group_item--" + filterTitle + "'.toLowerCase())" +
            ".find('.js-plp-control').eq(" + filterOptionIndex + ");" +
            "a.is(':visible') ? a.click(): undefined.click();");
            plpObjectWait.InitiateWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_loadingpanelfade));
            ExplicitWait(1000);
        }

        #endregion
    }
}
