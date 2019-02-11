using NewHarrods.Classes;
using NewHarrods.Configuration;
using NewHarrods.PageObjects;
using NewHarrods.Settings;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NewHarrods.Definitions
{
    [Binding]
    public class SignInDefinition : BaseTestClass
    {
        SignIn signin = new SignIn();
        BasePage BaseMethod = new BasePage();

        [Given(@"I am on the Sign In page")]
        public void SignInPage()
        {
            BaseMethod.GoSignInPage();            
        }

        [When(@"I enter an email address (.*)")]
        public void MissingEmailAddressSymbol(string EmailIssue)
        {

            if (EmailIssue == "without @ symbol")
            {
                signin.Login("joseph.milneharrods.com", "", "without @ symbol");
                try
                {
                    IWebElement EmailError = ObjectRepository.Driver.FindElement(By.XPath("//*[@id=\"EmailAddress-error\"]"));
                }
                catch (ErrorMessageNotDisplayed)
                {
                    Assert.Fail("The Error Message Was Not Displayed");
                }
            }
            else if (EmailIssue == "without . symbol")
            {
                signin.Login("joseph.milne@harrodscom", "", "without . symbol");
                try
                {
                    IWebElement EmailError = ObjectRepository.Driver.FindElement(By.XPath("//*[@id=\"EmailAddress-error\"]"));
                }
                catch (ErrorMessageNotDisplayed)
                {
                    Assert.Fail("The Error Message Was Not Displayed");
                }
            }
        }
        [Then(@"I am informed that the email address is invalid")]
        public void InformedInvalid1()
        {
            Assert.IsTrue(ObjectRepository.Driver.FindElement(By.XPath("//*[@id=\"EmailAddress-error\"]")).Displayed,"Incorrect email address notification is displayed");

        }

        [When(@"I enter a wrong password")]
        public void WrongPassword()
        {
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            signin.Login("AutoSignUp2019-01-04-05-01@harrodstest.com", "InvalidPword");
            

            try
            {
                WaitElementUntil(By.XPath("//*[@class='validation-summary-errors']"));
            }
            catch (ErrorMessageNotDisplayed)
            {
                Assert.Fail("The Error Message Was Not Displayed");
            }
        }
        [Then(@"I am informed that the login attempt is not successful")]
        public void InformedFailedLogin()
        {
            Assert.IsTrue(ObjectRepository.Driver.FindElement(By.XPath("//*[@class='validation-summary-errors']")).Displayed, "Incorrect password notification is displayed");
        }

        [When(@"I sign in using valid credentials")]
        public void SignInValidCredentials()
        {
            //ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            signin.Login("Rewards");
            //try
            //{
            //     ObjectRepository.Driver.FindElement(By.ClassName("rewards - status rewards - status--green - 0"));
            //    //IWebElement ServerSideError = ObjectRepository.Driver.FindElement(By.XPath("/html/body/div[1]/header/div/div[3]/ul/li[1]/div/a"));
            //}
            //catch(Exception)
            //{
            //    Assert.Fail("User Wasn't Signed In Correctly");
            //}
        }
        [Then(@"I am directed to the account home page")]
        public void AccountHomePage()
        {
          Assert.IsTrue(ObjectRepository.Driver.FindElement(By.XPath("//h1[contains(text(),'Welcome')]")).Displayed,"Login successful");
        }

        //[When(@"I access the Sign In Page")]
        //public void WhenIAccessTheSignInPage()
        //{
        //    signin.AccessSignIn();
        //}

        [When(@"I select forgotten password link")]
        public void WhenISelectForgottenPasswordLink()
        {
            WaitElementUntil(By.XPath("//*[@class='field_helper-link field_helper-link--2 field_helper-link--forgot-password']"));
            ObjectRepository.Driver.FindElement(By.XPath("//*[@class='field_helper-link field_helper-link--2 field_helper-link--forgot-password']")).Click();
        }

        [Then(@"I am taken to the reset your password page")]
        public void ThenIAmTakenToTheResetYourPasswordPage()
        {
            WaitElementUntil(By.XPath("//*[@value='Email password Reset']"));
            Assert.IsTrue(ObjectRepository.Driver.FindElement(By.XPath("//*[@value='Email password Reset']")).Displayed, "Password reset page is displayed");
            //Assert.Pass("Reset Password page is displayed");
        }




        [When(@"I select forgottens password link")]
        public void ForgottenPasswordLink()
        {

            Register1 Reg = new Register1();
            Register2 RegForm = new Register2();
            ObjectRepository.Driver.FindElement(By.LinkText("Register")).Click();
            System.Threading.Thread.Sleep(2000);
            Reg.EnterEmailContinue(0);
            RegForm.CompleteRewardsRegistration("Mr", "Jonny", "Tester", "07123456789", "Welcome123", "United Kingdom", "Test Address", "Test City", "W14 8YW", "May", "4");
            ObjectRepository.Driver.FindElement(By.XPath("//*[@class='nav_link nav_link--men js_nav-link']")).Click();
            ObjectRepository.Driver.FindElement(By.LinkText("Sweatshirts")).Click();
            PLP plp = new PLP();

            plp.AccessQuickShop(2);
            plp.QuickShopAddtoBag();
            plp.CloseQuickShop();
            plp.GoToFirstProduct();
            Fashion1PDP pdp = new Fashion1PDP();
            pdp.AddToBag();
            ShoppingBagPage sbag = new ShoppingBagPage();
            sbag.GoShoppingBagPage();
            sbag.GoToCheckout();

            //IWebElement ForgotPassword = ObjectRepository.Driver.FindElement(By.XPath("//*[@id=\"main\"]/div/section[1]/form/div[2]/a"));
            //ForgotPassword.Click();
            //try
            //{
            //    CheckCurrentPage ResetPassPage = new CheckCurrentPage();
            //    ResetPassPage.MyCurrentPageCheck("/password/forgotpassword");
            //}
            //catch (Exception)
            //{
            //    Assert.Fail("User Wasn't Taken To Reset Password Page");
            //}
        }
        

        [Then(@"there is an option to register for new account")]
        public void RegisterLink()
        {
            try
            {
                WaitElementUntil(By.XPath("//*[@class='button-text-link']"));
                bool RegisterLink = ObjectRepository.Driver.FindElements(By.XPath("//*[@class='button-text-link']")).Count > 0;
                if (RegisterLink == true)
                {
                    //Assert.IsTrue(true, "Register Link Found- Test Passed");
                    Console.WriteLine("Register Link Found- Test Passed");
                }
                else
                {
                    Assert.Fail("Link Not Found");
                }
            }
            catch (Exception)
            {
                Assert.Fail("Register Link Not Present On The Page");
            }

        }   
    }
}

