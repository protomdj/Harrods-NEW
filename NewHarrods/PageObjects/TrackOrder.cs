using NewHarrods.Classes;
using NewHarrods.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.PageObjects
{
    public class TrackOrder : BaseTestClass
    {
        ScreenShot scTool = new ScreenShot();

        //Calling out the WebElements on the page
        #region WebElement 
        private By _trackOrderLnk = By.XPath("//*[@class='footer-links_link']");
        private By _email = By.XPath("//*[@id='EmailAddress']");
        private By _ordernumber = By.XPath("//*[@id='OrderNumber']");
        private By _continueBtn = By.XPath("//*[@class='button button--primary button--arrow-after']");
        private By _emailError = By.XPath("//*[@id='EmailAddress-error']");
        private By _ordernumberlbl = By.XPath("//*[@class='secure_subhead-title']");
        private By _orderdatelbl = By.XPath("//*[@class='secure_subhead-copy']");
        private By _orderaddresslbl = By.XPath("//*[@class='shipment_label']");
        private By _orderstatuslbl = By.XPath("//*[@class='shipment_status-label']");
        private By _orderitemlbl = By.XPath("//*[@class='shipment_items-label']");
        private By _optionToSigninlbl = By.XPath("//*[@class='secure_subcontent-title']");
        private By _deliverymethodlbl = By.XPath("//*[@class='messages messages--info']");
        private By _selectOrder = By.XPath("//*[@class='table_detail-list order_detail-list']");
        private By _itemColumn = By.XPath("//*[@class='table_title-item oitems_title-item oitems_title-item--item']");
        private By _priceColumn = By.XPath("//*[@class='table_title-item oitems_title-item oitems_title-item--price']");
        private By _qtyColumn = By.XPath("//*[@class='table_title-item oitems_title-item oitems_title-item--quantity']");
        private By _discountColumn = By.XPath("//*[@class='table_title-item oitems_title-item oitems_title-item--discount']");
        private By _subtotalColumn = By.XPath("//*[@class='table_title-item oitems_title-item oitems_title-item--subtotal']");
        private By _statusColumn = By.XPath("//*[@class='table_title-item oitems_title-item oitems_title-item--status']");
        private By _orderdetailsdelivery = By.XPath("//*[@class='order_details-delivery']");
        private By _validationError = By.XPath("//*[@class='validation-summary-errors']");



        #endregion

        #region Data        
        //public string emailAddress{ get; set; }
        //public string ordernumber  { get; set; }
        public static string emailAddress = @ConfigurationManager.AppSettings["CustomerUsername"];
        public static string password = @ConfigurationManager.AppSettings["CustomerPassword"];
        public static string ordernumber = @ConfigurationManager.AppSettings["OrderNumber"];
        public static string devordernumber = @ConfigurationManager.AppSettings["devorderNumber"];
        #endregion

        SignIn signin = new SignIn();

        public void AccessPage()
        {
           // FindElementByElement(_trackOrderLnk).Click();
            FindElementCustom("a", "Track Your Order").Click();           
        }

        public void AccessYourOrders()
        {
            ExplicitWait(4000);
            FindElementCustom("a", "Your Orders").Click();
            WaitElementUntil(_selectOrder);
            FindElementByElement(_selectOrder).Click();
        }

        public void Track()
        {
            FindElementByElement(_email).SendKeys(emailAddress);

            if (MainBaseClass.EnvURL.Contains(".qa."))
            {
                FindElementByElement(_ordernumber).SendKeys(ordernumber);
            }
            else if(MainBaseClass.EnvURL.Contains(".dev."))
            {
                FindElementByElement(_ordernumber).SendKeys(devordernumber);
            }
            FindElementByElement(_continueBtn).Submit();
        }

        public void Track(string emailAddress, string ordernumber)
        {
            FindElementByElement(_email).SendKeys(emailAddress);
            FindElementByElement(_ordernumber).SendKeys(ordernumber);
            FindElementByElement(_continueBtn).Submit();
        }

        public void SignInTrack()
        {
            signin.Login(emailAddress,password);
        }

        public void ValidateMistypedInfo(string info)
        {
            ExplicitWait(3000);
            WaitElementUntil(_validationError);

            switch (info)
            {
                case "email address":
                    FindElementByElement(_validationError).Text.Contains("The email address you have entered does not match the email address for this order");
                    break;
                case "order number":
                    FindElementByElement(_validationError).Text.Contains("The order number you have entered does not match an existing order");
                    break;
            }
        }

        public void ValidateTrackInformation(string information)
        {
            // WaitElementUntil(_ordernumberlbl);

            ExplicitWait(3000);

            switch (information)
            {
                case "order number":
                    FindElementByElement(_ordernumberlbl).Text.Contains("Order Number:");
                    break;
                case "order date":
                    FindElementByElement(_orderdatelbl).Text.Contains("Order date:");
                    break;
                case "delivery address":
                    Assert.AreEqual(FindElementByElement(_orderaddresslbl).Text, "Deliver To:");
                    break;
                case "delivery method":
                    FindElementByElement(_deliverymethodlbl);
                    break;
                case "status":
                    FindElementByElement(_orderstatuslbl).Text.Contains("Status:");
                    break;
                case "items ordered":
                    FindElementByElement(_orderitemlbl);
                    break;
                case "option to sign in":
                    FindElementByElement(_optionToSigninlbl).Text.Contains("Have an online account?");
                    break;
                case "Item":
                    Assert.AreEqual(FindElementByElement(_itemColumn).Text, information);
                    break;
                case "Price":
                    Assert.AreEqual(FindElementByElement(_priceColumn).Text, information);
                    break;
                case "Qty":
                    Assert.AreEqual(FindElementByElement(_qtyColumn).Text, information);
                    break;
                case "Discount":
                    Assert.AreEqual(FindElementByElement(_discountColumn).Text, information);
                    break;
                case "Subtotal":
                    Assert.AreEqual(FindElementByElement(_subtotalColumn).Text, information);
                    break;
                case "Status":
                    Assert.AreEqual(FindElementByElement(_statusColumn).Text, information);
                    break;
                case "delivery details":
                    FindElementByElement(_orderdetailsdelivery);
                    break;

            }
        }


    }
}
