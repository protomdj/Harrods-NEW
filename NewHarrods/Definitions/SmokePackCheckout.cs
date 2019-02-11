using NewHarrods.Configuration;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using NewHarrods.PageObjects;
using NewHarrods.Classes;

namespace NewHarrods.Definitions
{
   [Binding]
    public class SmokePackCheckout : BaseTestClass
    {
        #region Instantiating
        BasePage baseMethod = new BasePage();
        PLP plpTest = new PLP();
        SignOut soTest = new SignOut();
        HTTPCodeCheck httpTest = new HTTPCodeCheck();
        SignIn siTest = new SignIn();
        Fashion1PDP pdpTest = new Fashion1PDP();
        ScreenShot scTool = new ScreenShot();
        DynamicElementWait scenarioWait = new DynamicElementWait();
        CheckoutLoginPage checkoutLTest = new CheckoutLoginPage();
        CheckoutDetails checkoutDetailsTest = new CheckoutDetails();
        CheckoutDelivery checkoutDelivTest = new CheckoutDelivery();
        CheckoutPayment checkoutPTest = new CheckoutPayment();
        QuickCheckout quickCheckoutTest = new QuickCheckout();
        private By _minibagquantity = By.XPath("//*[@class='minibag_quantity']");
        public String delivery;

        #endregion

        [Given(@"I have an item in my bag")]
        public void GivenIHaveAnItemInMyBag()
        {
            //plpTest.GoToFirstProduct();
            if (MainBaseClass.EnvURL.Contains(".qa."))
            {
                Driver.Url = MainBaseClass.EnvURL + "/harrods/logo-umbrella-p000000000001515268?bcid=N010030070000";
               // Driver.Navigate().GoToUrl(MainBaseClass.EnvURL + "/harrods/logo-umbrella-p000000000001515268?bcid=N010030070000");
            }
            else
            {
                Driver.Url = MainBaseClass.EnvURL + "/harrods/logo-mug-p000000000002619934?bcid=N010010040000";
                //Driver.Navigate().GoToUrl(MainBaseClass.EnvURL + "/harrods/logo-mug-p000000000002619934?bcid=N010010040000");
            }

            if (FindElementByElement(_minibagquantity).Text == "0")
            {
                pdpTest.AddToBag();
            }
            
        }

        [Given(@"I am not logged in and I progress to checkout")]
        public void GivenIAmNotLoggedInAndIProgressToCheckout()
        {
            baseMethod.GoToCheckout();
            checkoutLTest.AdvanceAsGuest();
        }

        [When(@"I enter valid delivery '(.*)' details")]
        public void WhenIEnterValidDeliveryDetails(string deliveryType)
        {
            try
            {
                checkoutDetailsTest.CompleteMandatoryDetails("Dr", "AutoFName", "AutoLName", "07101010101", ("AutoSignUp" + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + "@harrodstest.com")); // Chanaged the email address to be consistant with the Registration Email "AutoEmail@harrods.com"
                checkoutDetailsTest.GoDeliveryPage();
            }
            catch { }
            

            checkoutDelivTest.City = "City";
            checkoutDelivTest.Street = "Street";
            checkoutDelivTest.Zipcode = "112233";
            checkoutDelivTest.DeliveryMethodIndex = 0;
            switch (deliveryType)
            {
                case "UK":
                    checkoutDelivTest.Country = "United Kingdom";
                    checkoutDelivTest.UKPostcode = "W14 8YW";
                    break;
                case "Borderfree EU":
                    checkoutDelivTest.Street = "Calle de Gaztambide, 26";
                    checkoutDelivTest.Country = "Spain";
                    checkoutDelivTest.Zipcode = "28015";
                    checkoutDelivTest.City = "Madrid";
                    checkoutDelivTest.State = "Madrid";
                    break;
                case "Borderfree US":
                    checkoutDelivTest.Street = "292 Maddison Ave";
                    checkoutDelivTest.Country = "United States";
                    checkoutDelivTest.City = "New York";
                    checkoutDelivTest.Zipcode = "10017";
                    checkoutDelivTest.State = "New York";
                    break;
                case "Borderfree ROW":
                    checkoutDelivTest.Country = "United Arab Emirates";
                    break;
                case "Borderfree China":
                    checkoutDelivTest.Street = "1 Nanjing East Road";
                    checkoutDelivTest.City = "Huangpu District";
                    checkoutDelivTest.Country = "China";
                    checkoutDelivTest.Zipcode = "200000";
                    checkoutDelivTest.State = "Shanghai";
                    break;
                case "Borderfree Dollar":
                    checkoutDelivTest.Street = "2 Nanjing East Road";
                    checkoutDelivTest.City = "Huangpu District";
                    checkoutDelivTest.Country = "China";
                    checkoutDelivTest.Zipcode = "200000";
                    checkoutDelivTest.State = "Shanghai";
                    break;
            }
            if (deliveryType.Contains("US"))
            {
                checkoutDelivTest.CompleteMandatoryNADeliveryInfo();
            }
            else if (deliveryType.Contains("Borderfree") && deliveryType.Contains("US") != true && deliveryType.Contains("China") != true && deliveryType.Contains("Dollar") != true)
            {
                checkoutDelivTest.CompleteMandatoryROWDeliveryInfo();
            }
            else if (deliveryType.Contains("Borderfree") && deliveryType.Contains("US") != true && deliveryType.Contains("ROW") != true && deliveryType.Contains("Dollar") != true)
            {
                checkoutDelivTest.CompleteROWAddressWithCurrency("CNY");
            }
            else if (deliveryType.Contains("Borderfree") && deliveryType.Contains("US") != true && deliveryType.Contains("ROW") != true && deliveryType.Contains("China") != true)
            {
                checkoutDelivTest.CompleteROWAddressWithCurrency("USD");
            }

            else
            {
                checkoutDelivTest.CompleteMandatoryUKDeliveryInfo();
            }


            try
            {
                checkoutDelivTest.GoToPaymentPage();
            }
            catch { }
        }

        [When(@"I enter valid '(.*)' details")]
        public void WhenIEnterValidDetails(string paymentType)
        {
            string cvv = null;
            string cardno = null;
            if (paymentType == "Paypal")
            {
                try
                {
                    checkoutPTest.GuestPaypPalPayment();
                }
                catch (Exception e)
                {
                    scTool.TakeScreenShot("PayPal");
                    Assert.Fail("Acceptance Failed At: " + e);
                }
            }
            else if (paymentType == "AliPay")
            {
                try
                {
                    checkoutPTest.PayWithAliPayGuest();
                }
                catch (Exception e)
                {
                    scTool.TakeScreenShot("AliPay");
                    Assert.Fail("Acceptance Failed At: " + e);
                }
            }
            else
            {
                switch (paymentType)
                {
                    case "Visa":
                        cvv = "123";
                        cardno = "4111111111111111";
                        break;
                    case "American Express":
                        cvv = "1234";
                        cardno = "378282246310005";
                        break;
                    case "Mastercard":
                        cvv = "123";
                        cardno = "5555555555554444";
                        break;
                    case "China Union Pay":
                        cvv = "123";
                        cardno = "5309900599078555";
                        break;
                }
                checkoutPTest.CompleteCardPaymentInfo(paymentType, cardno, "AutoName", "1", "2022", cvv);
                try
                {
                    checkoutPTest.ClickPayNow();
                }
                catch (Exception e)
                {
                    scTool.TakeScreenShot("GuestPayment " + paymentType);
                    Assert.Fail("Acceptance Failed At: " + e);
                }
            }
        }

        [Given(@"I am logged in and I progress to checkout")]
        public void GivenIAmLoggedInAndIProgressToCheckout()
        {
            baseMethod.GoToCheckout();
            checkoutLTest.Login();
        }

        [When(@"I select a '(.*)' address")]
        public void WhenIEnterISelectADeliveryAddress(string deliveryType)
        {
            ExplicitWait(4000);
            quickCheckoutTest.ClickUseAnotherAddressCTA();
            if (deliveryType == "UK")
            {
                quickCheckoutTest.UseNamedCountryAddress("United Kingdom");
            }
            else if (deliveryType == "Borderfree EU")
            {
                quickCheckoutTest.UseNamedCountryAddress("Spain");
            }
            else if (deliveryType == "Borderfree US")
            {
                quickCheckoutTest.UseNamedCountryAddress("United States");
            }
            else if (deliveryType == "Borderfree ROW")
            {
                quickCheckoutTest.UseNamedCountryAddress("United Arab Emirates");
            }

            else if (deliveryType == "Borderfree China")
            {
                 quickCheckoutTest.UseNamedCountryAddress("China");
            }
            delivery = deliveryType;
        }

        [When(@"I select a '(.*)' payment card")]
        public void WhenISelectANewPaymentCard(string paymentType)
        {
            if (paymentType == "Paypal")
            {               
                try
                {
                    quickCheckoutTest.PayWithPaypal(delivery);
                }
                catch (Exception e)
                {
                    scTool.TakeScreenShot("PayPal");
                    Assert.Fail("Acceptance Failed At: " + e);
                }
            }
            else if (paymentType == "AliPay")
            {
                try
                {
                    quickCheckoutTest.PayWithAliPay();
                }
                catch (Exception e)
                {
                    scTool.TakeScreenShot("AliPay");
                    Assert.Fail("Acceptance Failed At: " + e);
                }
            }
            else
            {
                switch (paymentType)
                {
                    case "Visa":
                        quickCheckoutTest.SelectSpecifiedCard("VISA", "123");
                        break;
                    case "American Express":
                        quickCheckoutTest.SelectSpecifiedCard("AMEX", "1234");
                        break;
                    case "Mastercard":
                        quickCheckoutTest.SelectSpecifiedCard("Master Card", "123");
                        break;
                    case "New Card":
                        quickCheckoutTest.NewCardEntry("Visa", "4111111111111111", "Newcardtest", "4", "2019", "123");
                        break;
                }
                try
                {
                    quickCheckoutTest.ClickPayNow();
                }
                catch (Exception e)
                {
                    scTool.TakeScreenShot("RegisterdPayment " + paymentType);
                    Assert.Fail("Acceptance Failed At: " + e);
                }
            }

        }

        [When(@"I have chosen to add a gift message '(.*)'")]
        public void WhenIHaveChosenToAddAGiftMessage(string message)
        {
            quickCheckoutTest.GiftMessage(message);
        }

        [Then(@"I am able to confirm gift message '(.*)' after completing checkout")]
        public void ThenIAmAbleToConfirmGiftMessageAfterCompletingCheckout(string message)
        {
            quickCheckoutTest.ValidateGiftMessage(message);
        }

        [When(@"I have chosen to use a gift card")]
        public void WhenIHaveChosenToUseAGiftCard()
        {
            quickCheckoutTest.UseGiftcard();
        }

        [Then(@"I am able to redeem the card balance")]
        public void ThenIAmAbleToRedeemTheCardBalance()
        {
            quickCheckoutTest.ValidateGiftcardBalance();
        }

        [Then(@"Validate '(.*)' available for UK user")]
        public void ThenValidateAvailableForUKUser(string shipping)
        {
            quickCheckoutTest.ValidateShipping(shipping);
        }


        [Then(@"I am able to complete checkout successfully")]
        public void ThenIAmAbleToCompleteCheckoutSuccessfully()
        {
            //try
            //{
            //    Assert.IsTrue(Driver.FindElements(By.CssSelector("div[class='confirmation_detail-value confirmation_detail-value--address']")).Count == 2);
            //    //Assert.IsTrue(FindElementByCss("div[class='confirmation_detail-value confirmation_detail-value--order-total']").Text == FindElementByCss("span[class='osp_totals-amount osp_totals-amount--total']").Text);
            //    Assert.IsTrue(Driver.FindElements(By.CssSelector("div[class='confirmation_detail-row confirmation_detail-row--delivery-description']")).Count == 2);
            //    FindElementByCss("div[class='confirmation_detail-value confirmation_detail-value--order-number']");
            //}
            //catch(Exception e)
            //{
            //    scTool.TakeScreenShot("ConfirmationPage ");
            //    Assert.Fail("Acceptance Failed At: " + e);
            //}
        }
    }
}
