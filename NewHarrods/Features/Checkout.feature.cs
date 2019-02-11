﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace NewHarrods.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Checkout")]
    public partial class CheckoutFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Checkout.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Checkout", "Verify users are able to checkout as both a registered user and a guest user\r\nVer" +
                    "ify all features relating to checkout works as intended", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line 6
 testRunner.Given("I have an item in my bag", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Checkout as a registered user with saved delivery and card information.")]
        [NUnit.Framework.TestCaseAttribute("Visa", "UK", null)]
        [NUnit.Framework.TestCaseAttribute("Paypal", "UK", null)]
        [NUnit.Framework.TestCaseAttribute("American Express", "UK", null)]
        [NUnit.Framework.TestCaseAttribute("Mastercard", "UK", null)]
        [NUnit.Framework.TestCaseAttribute("New Card", "UK", null)]
        [NUnit.Framework.TestCaseAttribute("Visa", "Borderfree EU", null)]
        [NUnit.Framework.TestCaseAttribute("Paypal", "Borderfree EU", null)]
        [NUnit.Framework.TestCaseAttribute("American Express", "Borderfree EU", null)]
        [NUnit.Framework.TestCaseAttribute("Mastercard", "Borderfree EU", null)]
        [NUnit.Framework.TestCaseAttribute("New Card", "Borderfree EU", null)]
        [NUnit.Framework.TestCaseAttribute("Visa", "Borderfree US", null)]
        [NUnit.Framework.TestCaseAttribute("Paypal", "Borderfree US", null)]
        [NUnit.Framework.TestCaseAttribute("American Express", "Borderfree US", null)]
        [NUnit.Framework.TestCaseAttribute("Mastercard", "Borderfree US", null)]
        [NUnit.Framework.TestCaseAttribute("New Card", "Borderfree US", null)]
        [NUnit.Framework.TestCaseAttribute("Visa", "Borderfree ROW", null)]
        [NUnit.Framework.TestCaseAttribute("Paypal", "Borderfree ROW", null)]
        [NUnit.Framework.TestCaseAttribute("American Express", "Borderfree ROW", null)]
        [NUnit.Framework.TestCaseAttribute("Mastercard", "Borderfree ROW", null)]
        [NUnit.Framework.TestCaseAttribute("New Card", "Borderfree ROW", null)]
        [NUnit.Framework.TestCaseAttribute("AliPay", "Borderfree China", null)]
        public virtual void CheckoutAsARegisteredUserWithSavedDeliveryAndCardInformation_(string paymentType, string deliveryType, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Checkout as a registered user with saved delivery and card information.", null, exampleTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 9
testRunner.Given("I am logged in and I progress to checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
testRunner.When(string.Format("I select a \'{0}\' address", deliveryType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.And(string.Format("I select a \'{0}\' payment card", paymentType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.Then("I am able to complete checkout successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("SmokeTest - Checkout out as a guest user.")]
        [NUnit.Framework.TestCaseAttribute("Visa", "UK", null)]
        [NUnit.Framework.TestCaseAttribute("Paypal", "UK", null)]
        [NUnit.Framework.TestCaseAttribute("American Express", "UK", null)]
        [NUnit.Framework.TestCaseAttribute("Mastercard", "UK", null)]
        [NUnit.Framework.TestCaseAttribute("Visa", "Borderfree EU", null)]
        [NUnit.Framework.TestCaseAttribute("Paypal", "Borderfree EU", null)]
        [NUnit.Framework.TestCaseAttribute("American Express", "Borderfree EU", null)]
        [NUnit.Framework.TestCaseAttribute("Mastercard", "Borderfree EU", null)]
        [NUnit.Framework.TestCaseAttribute("Visa", "Borderfree US", null)]
        [NUnit.Framework.TestCaseAttribute("Paypal", "Borderfree US", null)]
        [NUnit.Framework.TestCaseAttribute("American Express", "Borderfree US", null)]
        [NUnit.Framework.TestCaseAttribute("Mastercard", "Borderfree US", null)]
        [NUnit.Framework.TestCaseAttribute("Visa", "Borderfree ROW", null)]
        [NUnit.Framework.TestCaseAttribute("Paypal", "Borderfree ROW", null)]
        [NUnit.Framework.TestCaseAttribute("American Express", "Borderfree ROW", null)]
        [NUnit.Framework.TestCaseAttribute("Mastercard", "Borderfree ROW", null)]
        [NUnit.Framework.TestCaseAttribute("China Union Pay", "Borderfree Dollar", null)]
        [NUnit.Framework.TestCaseAttribute("AliPay", "Borderfree China", null)]
        public virtual void SmokeTest_CheckoutOutAsAGuestUser_(string paymentType, string deliveryType, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SmokeTest - Checkout out as a guest user.", null, exampleTags);
#line 37
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 38
 testRunner.Given("I am not logged in and I progress to checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.When(string.Format("I enter valid delivery \'{0}\' details", deliveryType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.And(string.Format("I enter valid \'{0}\' details", paymentType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.Then("I am able to complete checkout successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add a valid gift message")]
        public virtual void AddAValidGiftMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a valid gift message", null, ((string[])(null)));
#line 63
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 64
 testRunner.Given("I am logged in and I progress to checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.When("I select a \'UK\' address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.And("I have chosen to add a gift message \'Test Message\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("I select a \'Visa\' payment card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.Then("I am able to confirm gift message \'Test Message\' after completing checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Redeem gift card balance as a UK user only")]
        public virtual void RedeemGiftCardBalanceAsAUKUserOnly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Redeem gift card balance as a UK user only", null, ((string[])(null)));
#line 70
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 71
 testRunner.Given("I am logged in and I progress to checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.When("I select a \'UK\' address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
    testRunner.And("I have chosen to use a gift card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
    testRunner.Then("I am able to redeem the card balance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate all shipping method as a UK user only")]
        [NUnit.Framework.TestCaseAttribute("UK Standard (3 to 5 days)", null)]
        [NUnit.Framework.TestCaseAttribute("Pre 9am Next day", null)]
        [NUnit.Framework.TestCaseAttribute("Next Day", null)]
        [NUnit.Framework.TestCaseAttribute("Saturday", null)]
        [NUnit.Framework.TestCaseAttribute("Sunday", null)]
        public virtual void ValidateAllShippingMethodAsAUKUserOnly(string shippingMethod, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate all shipping method as a UK user only", null, exampleTags);
#line 76
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 77
 testRunner.Given("I am logged in and I progress to checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
 testRunner.When("I select a \'UK\' address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
 testRunner.Then(string.Format("Validate \'{0}\' available for UK user", shippingMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate all shipping method as a EU user only")]
        [NUnit.Framework.TestCaseAttribute("Europe", null)]
        public virtual void ValidateAllShippingMethodAsAEUUserOnly(string shippingMethod, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate all shipping method as a EU user only", null, exampleTags);
#line 88
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 89
 testRunner.Given("I am logged in and I progress to checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.When("I select a \'Borderfree EU\' address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.Then(string.Format("Validate \'{0}\' available for UK user", shippingMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate all shipping method as a ROW user only")]
        [NUnit.Framework.TestCaseAttribute("Worldwide", null)]
        public virtual void ValidateAllShippingMethodAsAROWUserOnly(string shippingMethod, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate all shipping method as a ROW user only", null, exampleTags);
#line 96
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 97
 testRunner.Given("I am logged in and I progress to checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 98
 testRunner.When("I select a \'Borderfree ROW\' address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 99
 testRunner.Then(string.Format("Validate \'{0}\' available for UK user", shippingMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
