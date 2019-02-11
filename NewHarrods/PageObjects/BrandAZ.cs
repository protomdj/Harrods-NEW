using NewHarrods.Classes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class BrandAZ : BaseTestClass
    {
        #region WebElement
        private By _brandfulllist = By.XPath("//*[@class='brand-az_brand-link']");
        private By _brandlink = By.XPath("//*[@class='brand-az_brand-link']");
        #endregion

        #region Actions
        public IList<IWebElement> GetBrandhrefs()
        {
            IList<IWebElement> brandlinklist = Driver.FindElements(_brandlink);
            return brandlinklist;
        }
        #endregion
    }
}
