using NewHarrods.Definitions;
using NewHarrods.Classes;
using NewHarrods.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using NewHarrods.PageObjects;

namespace NewHarrods.Definitions
{
    [Binding]
    public class SmokePackV1Steps : BaseTestClass
    {
        #region Instantiating
        BasePage baseMethod = new BasePage();
        PLP plpTest = new PLP();
        SignOut soTest = new SignOut();
        HTTPCodeCheck httpTest = new HTTPCodeCheck();
        SignIn siTest = new SignIn();
        Register1 r1Test = new Register1();
        Register2 r2Test = new Register2();
        GiftCardBalance gcbTest = new GiftCardBalance();
        BrandAZ brandAZTest = new BrandAZ();
        Fashion1PDP pdpTest = new Fashion1PDP();
        ScreenShot scTool = new ScreenShot();
        DynamicElementWait scenarioWait = new DynamicElementWait();
        StringToIntConverter stringToIntTest = new StringToIntConverter();
        #endregion
        public string _uniqueElement = null;

        [Given(@"user is on the homepage")]
        public void Scenario1_1()
        {
            Driver.Navigate().GoToUrl(MainBaseClass.EnvURL);
            ExplicitWait(4000);            
        }


        [Given(@"I have navigated to the harrods site homepage")]

        public void Scenario1_2()
        {
            baseMethod.HomepageCheck();
            Console.WriteLine("I have navigated to the harrods site homepage");
        }
        [Given(@"I want to check all links on the homepage return a 200 response code")]
        public void Scenario2_3()
        {
        }

        [When(@"I run my link checker")]
        public void Scenario2_4()
        {
            IList<IWebElement> allATags = Driver.FindElements(By.TagName("a"));
            foreach (var atag in allATags)
            {
                string href = atag.GetAttribute("href");
                if (href.Contains("www"))
                {
                    string statuscode = httpTest.GetStatusCode(href);
                    if (statuscode != "OK")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(href + " : " + statuscode);
                    }
                }
            }
        }

        [Given(@"I am a '(.*)'")]
        public void Scenario2_1(string userType)
        {
            baseMethod.GoSignInPage();

            if (userType == "Rewards")
            {
                siTest.Login("Rewards");
                _uniqueElement = "//*[@class='portal-dashboard_header-rewards-status']";
              //  _uniqueElement = "//*[@class='benefits-section_table-container']";
            }
            else if (userType == "Nonrewards")
            {
                siTest.Login("NonRewards");
                _uniqueElement = "//*[@value='Link Accounts']";
            }
            else
            { Console.WriteLine("Guest User"); }
        }
        [Given(@"I choose to sign in with my valid credentials")]
        public void Scenario2_2()
        {
            try //Find the below elements on the sign 
            {
                FindElementByClassName("portal-dashboard_sections-wrap");
                FindElementByClassName("portal-dashboard_header-title");
                FindElementByClassName("header-account_name");
                FindElementByClassName("portal-dashboard_sections");
                FindElementByXpath(_uniqueElement);
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("Sign In");
                Assert.Fail("Acceptance Failed At: " + e);
            }
            baseMethod.Logout();
        }


        [Given(@"I am a logged in user")]
        public void Scenario3_1()
        {
            baseMethod.GoSignInPage();
            siTest.Login("NonRewards");
        }
        [Given(@"I choose to log out")]
        public void Sceanrio3_2() // finish with statment for each login scenario to check result
        {
            baseMethod.Logout();
            try //Find the below elements on the sign 
            {
                FindElementByXpath("//*[@class='header-account_link header-account_link--sign-in']");
                FindElementByXpath("//*[@class='header-account_link header-account_link--register']");
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("Logout");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }


        [When(@"I choose to navigate to rewards landing page")]
        public void Scenario4_2() // finish with statment for each login scenario to check result
        {
            baseMethod.GoToRewardsPage();
            try //Find the below elements on the sign 
            {
                FindElementByXpath("//*[@class='portal-dashboard_header-rewards-status']");
                FindElementByXpath("//*[@class='join-section_content-wrap']");
                FindElementByXpath("//*[@class='hrd-module hrd-module--contact-us']");
                FindElementByXpath("//*[@class='how-rewards-work']");
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("GuestRewards");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        [Given(@"I choose to register for a nonrewards account")]
        public void Scenario5_2()
        {
            baseMethod.GoToRegisterPage();
            r1Test.EnterEmailContinue(2);
            r2Test.CompleteNonRewardsRegistration("Mrs", "Joanna", "Tester", "07123456789", "Welcome123");

            WaitElementUntil(By.XPath("//*[@value='Link Accounts']"));

            try
            {
                FindElementByClassName("portal-dashboard_sections-wrap");
                FindElementByClassName("portal-dashboard_header-title");
                FindElementByClassName("header-account_name");
                FindElementByClassName("portal-dashboard_sections");
                FindElementByXpath("//*[@value='Link Accounts']");
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("NonRewards");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }


        [Given(@"I choose to register for a rewards account")]
        public void Scenario5_1() // finish with statment for each login scenario to check result
        {
            baseMethod.GoToRegisterPage();
            r1Test.EnterEmailContinue(0);
            r2Test.CompleteRewardsRegistration("Mr", "Jonny", "Tester", "07123456789", "Welcome123", "United Kingdom", "Test Address", "London", "W129ag", "May", "4");
            try
            {
                FindElementByClassName("portal-dashboard_sections-wrap");
                FindElementByClassName("portal-dashboard_header-title");
                FindElementByClassName("header-account_name");
                FindElementByClassName("portal-dashboard_sections");
                FindElementByXpath("//*[@class='benefits-section_table-container']");
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("Rewards");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        [Given(@"I choose to check a valid gift cards balance")]
        public void Scenario6_1() // finish with statment for each login scenario to check result
        {
            baseMethod.GoToGiftCardBalancePage();
            gcbTest.EnterGiftCardBalance();
            try
            {
                Driver.FindElement(By.XPath("//*[@class='panel panel--success']"));
                Driver.FindElement(By.XPath("//*[@class='price']"));
                Driver.FindElement(By.XPath("//*[@class='panel_icon']"));
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("Gift Card");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        [Given(@"I am able to enter valid details")]
        public void Scenario6_2()
        {
        }

        [Given(@"I am searching for a '(.*)'")]
        public void Scenario7_1(string searchTerm)
        {
            baseMethod.GoToMegaMenuLink("Accessories", "Handbags");
            try
            {
                plpTest.GoToFirstProduct();
                if (searchTerm == "Product ID")
                {
                    string IDFullString = FindElementByElement(By.XPath("//*[@class='buying-controls_prodID js-buying-control-prodID']")).Text;
                    string NumericID = Regex.Match(IDFullString, @"\d+").Value;
                    baseMethod.EnterSearchTerm(NumericID);
                }
                else if (searchTerm == "Product Title")
                {
                    string ProductName = FindElementByElement(By.XPath("//*[@class='buying-controls_name']")).Text;
                    baseMethod.EnterSearchTerm(ProductName);
                }
                FindElementByClassName("pdp_buying-controls");
                FindElementByClassName("pdp_images");
                FindElementByClassName("breadcrumb_list");
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("Search Terms");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        [Given(@"I want to check '(.*)' is displaying correctly")]
        public void Scenario8_1(string templateType)
        {
            string parentcategory = null;
            string childcategory = null;
            if (templateType == "Fashion 1")
            {
                parentcategory = "Men";
                childcategory = "Knitwear";
            }
            else if (templateType == "Fashion 2")
            {
                parentcategory = "Accessories";
                childcategory = "Handbags";
            }
            else if (templateType == "Buggies")
            {
                parentcategory = "Children";
                childcategory = "Prams & Travel Systems";
            }
            else if (templateType == "Pairs")
            {
                parentcategory = "Women";
                childcategory = "Lingerie";
            }
            else if (templateType == "Bedding")
            {
                parentcategory = "Homewares";
                childcategory = "Bedding";
            }
            else if (templateType == "Towels")
            {
                parentcategory = "Homewares";
                childcategory = "Towels";
            }
            else if (templateType == "Tableware")
            {
                parentcategory = "Homewares";
                childcategory = "Tableware";
            }
            else if (templateType == "Gift Card")
            {
                parentcategory = "Gifts";
                childcategory = "Gift Cards";
            }
            baseMethod.GoToMegaMenuLink(parentcategory, childcategory);
            plpTest.GoToFirstProduct();
        }


        [Given(@"I am on a PLP")]
        public void Scenario9_1()
        {
            baseMethod.GoToMegaMenuLink("Men", "T-Shirts");      
        }

        [When(@"I opt to apply '(.*)' filter")]
        public void WhenIOptToApplyFilter(string filterType)
        {
            plpTest.ApplyFilter(filterType, 0);

            ExplicitWait(3000);

            try
            {
                FindElementByClassName("filter-group_item--summary");
                string filtertitle = Driver.FindElement(By.ClassName("filter-group_item-title")).Text;
                string filtervalue = Driver.FindElement(By.ClassName("filter_label")).Text;
                string itemnocount = Driver.FindElement(By.ClassName("filter_info-count--actual")).Text;
                itemnocount = itemnocount.Substring(0, itemnocount.IndexOf(" "));
                Assert.IsTrue(filtertitle.ToLower() == filterType.ToLower());
                if (Int32.Parse(itemnocount) >= 60)
                {
                    string viewallstring = Driver.FindElement(By.ClassName("plp-view-all")).Text;
                    string viewallcount = Regex.Match(viewallstring, @"\d+").Value;
                    Assert.IsTrue(viewallcount == Driver.FindElement(By.ClassName("filter_info-count--actual")).Text);
                }
                else
                {
                    Assert.IsTrue(itemnocount == Driver.FindElements(By.ClassName("product-card")).Count.ToString());
                }
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("Filter");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }



        [Given(@"I'm on a PLP with more than 60 products")]
        public void Scenario10_1()
        {
            baseMethod.GoToMegaMenuLink("Accessories", "Handbags");
        }

        [Given(@"I choose to select view all")]
        public void Scenario10_2()
        {
            string viewallcount = Regex.Match(FindElementByClassName("plp-view-all").Text, @"\d+").Value;
            plpTest.ClickViewAll();
            //if (FindElementByXpath("//*[contains(text(), 'WCS Price API is not returning any Prices')]").Displayed) ////put this back in when the data has been cleaned up
            //{
            //    Assert.Inconclusive("Some products on this plp are not configured correctly in WCS");
            //}
            try
            {
                int productcard = Driver.FindElements(By.XPath("//*[@class='product-grid_item']")).Count;

                if (int.Parse(viewallcount) <= 40)
                {
                    Assert.IsTrue(productcard == int.Parse(viewallcount));
                }
                else
                {
                    Assert.IsTrue(productcard >= 34);
                }
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("ViewAll");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        [Given(@"I want to see if the Brand A-Z page is displaying correctly")]
        public void Scenario11_1()
        {
            baseMethod.GoToParentCategory("Designers");
            try
            {
                FindElementByClassName("hero-header_content");
                FindElementByXpath("//*[@id='A']");
                FindElementByXpath("//*[@id='B']");
                FindElementByXpath("//*[@id='C']");
                FindElementByXpath("//*[@id='D']");
                FindElementByXpath("//*[@id='E']");
                FindElementByXpath("//*[@id='F']");
                FindElementByXpath("//*[@id='G']");
                FindElementByXpath("//*[@id='H']");
                FindElementByXpath("//*[@id='I']");
                FindElementByXpath("//*[@id='J']");
                FindElementByXpath("//*[@id='K']");
                FindElementByXpath("//*[@id='L']");
                FindElementByXpath("//*[@id='M']");
                FindElementByXpath("//*[@id='N']");
                FindElementByXpath("//*[@id='O']");
                FindElementByXpath("//*[@id='P']");
                FindElementByXpath("//*[@id='R']");
                FindElementByXpath("//*[@id='S']");
                FindElementByXpath("//*[@id='T']");
                FindElementByXpath("//*[@id='U']");
                FindElementByXpath("//*[@id='V']");
                FindElementByXpath("//*[@id='W']");
                FindElementByXpath("//*[@id='X']");
                FindElementByXpath("//*[@id='Y']");
                FindElementByXpath("//*[@id='Z']");
                FindElementByXpath("//*[@id='09']");
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("BrandAZ");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }
        [Given(@"I navigate there")]
        public void Scenario11_2()
        {
        }


        [Given(@"I want to check brand pages are displaying correctly")]
        public void Scenario12_1()
        {
            baseMethod.GoToParentCategory("Designers");
        }
        [Given(@"I check for a OK reponse code")]
        public void Scenario12_2()
        {
            foreach (var brandInList in brandAZTest.GetBrandhrefs())
            {
                string href = brandInList.GetAttribute("href");
                string statuscode = httpTest.GetStatusCode(href);
                if (statuscode == "OK")
                { }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(href + " : " + statuscode);
                }
            }
        }


        [Given(@"I access the quick shop from a PLP")]
        public void Scenario13_1()
        {
            baseMethod.GoToMegaMenuLink("Men", "T-Shirts");
            plpTest.AccessQuickShop(1);
            try
            {
                FindElementByClassName("quick-shop");
                FindElementByClassName("buying-controls");
                FindElementByXpath("//*[@id='quickshop_panel_close']");
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("QuickShop");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        [Given(@"I am on a product PDP")]
        public void Scenario14_1()
        {
            baseMethod.GoToMegaMenuLink("Accessories", "Handbags");
            plpTest.GoToFirstProduct();
        }

        [Given(@"I choose to add the product to  the bag")]
        public void Scenario14_2()
        {
            string minibagqty = Driver.FindElement(By.ClassName("minibag_quantity")).Text;

            try
            {
                pdpTest.AddToBag();
                WaitElementUntil(By.ClassName("buying-controls_confirmation-title"));
                ExplicitWait(100);
                Assert.IsTrue(Int32.Parse(Driver.FindElement(By.ClassName("minibag_quantity")).Text) == Int32.Parse(minibagqty) + 1);
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("PDP");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        [Given(@"I search a keyword")]
        public void Scenario15_1()
        {
            baseMethod.EnterSearchTerm("Blue");
            plpTest.AccessQuickShop(0);
            try
            {
                FindElementByClassName("quick-shop");
                FindElementByClassName("buying-controls");
                FindElementByXpath("//*[@id='quickshop_panel_close']");
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("SearchAddBag");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }


        [Given(@"I choose to apply a sort option on the PLP")]
        public void Scenario15_2()
        {
            baseMethod.GoToMegaMenuLink("Accessories", "Handbags");
            plpTest.SelectSortType("Price - high to low");
            IList<IWebElement> AllProductPrice = null;
            AllProductPrice = Driver.FindElement(By.ClassName("product-grid_list")).FindElements(By.ClassName("price_amount"));
            try
            {
                Assert.IsTrue(stringToIntTest.GetNumber(AllProductPrice.ElementAt(0).Text) >= stringToIntTest.GetNumber(AllProductPrice.ElementAt(1).Text));
                Assert.IsTrue(stringToIntTest.GetNumber(AllProductPrice.ElementAt(1).Text) >= stringToIntTest.GetNumber(AllProductPrice.ElementAt(2).Text));
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("SortPLP");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        [Given(@"I opt to register for the mailing list")]
        public void Scenario16_1()
        {
            baseMethod.EmailSignUp();
            try
            {
                Assert.IsTrue(Driver.FindElement(By.ClassName("hrd-base-title")).Text.Contains("EMAIL SIGN UP SUCCESSFUL"));
                FindElementByClassName("email-subscription_panel");
            }
            catch (Exception e)
            {
                scTool.TakeScreenShot("MailingList");
                Assert.Fail("Acceptance Failed At: " + e);
            }
        }

        [Given(@"I run the SoapUI Tests")]
        public void Scenario17_1()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(@"cd C:\Program Files (x86)\SmartBear\SoapUI-5.3.0\bin");
            cmd.StandardInput.WriteLine(@"testrunner.bat -r -a -fC:\workspace\Automation\SOAPUI\ResponseReport -I C:\workspace\Automation\SOAPUI\TestDemo-soapui-project.xml");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit(10000);
            string testoutput = cmd.StandardOutput.ReadToEnd().ToString();
            Console.WriteLine(testoutput);
            Assert.IsTrue(testoutput.Contains("Total Failed Assertions: 0"));
        }


        #region Then
        [Then(@"They all pass\.")]
        public void ThenTheyAllPass_()
        {
        }

        [Then(@"I am served a header, footer and site content")]
        public void ThenIAmServedAHeaderFooterAndSiteContent()
        {

        }
        [Then(@"all links on the page return 200 response code")]
        public void ThenAllLinksOnThePageReturnResponseCode()
        {
        }

        [Then(@"I am taken into my accounts landing page")]
        public void ThenIAmTakenIntoMyAccountsLandingPage()
        {

        }

        [Then(@"I am no longer able to see my account name in the header or access account info")]
        public void ThenIAmNoLongerAbleToSeeMyAccountNameInTheHeaderOrAccessAccountInfo()
        {

        }

        [Then(@"I am served the appropriate version of the page")]
        public void ThenIAmServedTheAppropriateVersionOfThePage()
        {

        }

        [Then(@"I am able to complete the form and end up logged in to my new user account")]
        public void ThenIAmAbleToCompleteTheFormAndEndUpLoggedInToMyNewUserAccount()
        {

        }

        [Then(@"I am served an appropriate value as the balance")]
        public void ThenIAmServedAnAppropriateValueAsTheBalance()
        {

        }

        [Then(@"I am taken directly to the PDP of the relevant product")]
        public void ThenIAmTakenDirectlyToThePDPOfTheRelevantProduct()
        {
        }

        [Then(@"When I navigate there I am served correct infomation")]
        public void ThenWhenINavigateThereIAmServedCorrectInfomation()
        {
        }

        [Then(@"i am displayed a PLP of results that reflects my selection")]
        public void ThenIAmDisplayedAPLPOfResultsThatReflectsMySelection()
        {
        }

        [Then(@"I am displayed all the products available for that PLP on one page")]
        public void ThenIAmDisplayedAllTheProductsAvailableForThatPLPOnOnePage()
        {

        }

        [Then(@"i am displayed the page correctly")]
        public void ThenIAmDisplayedThePageCorrectly()
        {

        }

        [Then(@"The page will be up an running")]
        public void ThenThePageWillBeUpAnRunning()
        {

        }

        [Then(@"The product is placed in users bag")]
        public void ThenTheProductIsPlacedInUsersBag()
        {

        }

        [Then(@"The listing order on the page responds with relevant change to user selection\.")]
        public void ThenTheListingOrderOnThePageRespondsWithRelevantChangeToUserSelection_()
        {

        }

        [Then(@"my email is taken and I'm displayed some form of confirmation")]
        public void ThenMyEmailIsTakenAndIMDisplayedSomeFormOfConfirmation()
        {

        }
        #endregion
    }
}
