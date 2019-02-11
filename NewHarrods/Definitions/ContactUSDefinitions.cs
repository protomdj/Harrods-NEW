using NewHarrods.Classes;
using NewHarrods.Settings;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NewHarrods.PageObjects;
using NewHarrods.Configuration;

namespace NewHarrods.Definitions
{
    [Binding]
    public class ContactUSDefinitions : BaseTestClass
    {
        ContactUs contact = new ContactUs();

        [Given(@"I am on the Contact Us page")]
        public void GivenIAmOnTheContactUsPage()
        {
            contact.AccessPage();         
        }

        [When(@"I Validate an invalid email '(.*)'")]
        public void WhenIValidateAnInvalidEmailWithoutSymbol(string EmailIssue)
        {
            contact.validateEmail(EmailIssue);
        }
        
        [When(@"I submit the form with a empty '(.*)'")]
        public void WhenISubmitTheFormWithAEmpty(string field)
        {
            contact.validateFields(field);
        }


        [When(@"I submit the form without entering any values")]
        public void WhenISubmitTheFormWithoutEnteringAnyValues()
        {
            contact.validateForm();
        }

        [When(@"I submit the form with valid details")]
        public void WhenISubmitTheFormWithValidDetails()
        {
            contact.validDetails();
        }

        [Then(@"I am informed that the message has been sent")]
        public void ThenIAmInformedThatTheMessageHasBeenSent()
        {
            contact.messageSentNotification();
        }

        [Then(@"there is an option to send another message")]
        public void ThenThereIsAnOptionToSendAnotherMessage()
        {
            contact.SendAnotherMessage();
        }

        [Then(@"there is a link to view FAQs page")]
        public void ThenThereIsALinkToViewFAQsPage()
        {
            contact.FAQlink();
        }

        [Then(@"the header contains the following '(.*)'")]
        public void ThenTheHeaderContainsTheFollowing(string headers)
        {
            contact.ValidateHeaders(headers);
        }

        [Then(@"I am informed that a value should be selected")]
        public void ThenIAmInformedThatAValueShouldBeSelected()
        {
           
        }

        [Then(@"I am informed that the fields must be completed")]
        public void ThenIAmInformedThatTheFieldsMustBeCompleted()
        {
         
        }

       














    }
}
