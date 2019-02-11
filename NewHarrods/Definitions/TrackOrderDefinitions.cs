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
    public sealed class TrackOrderDefinitions : BaseTestClass
    {

        BasePage baseMethod = new BasePage();
        TrackOrder track = new TrackOrder();



        [Given(@"I am on Track Your Order page as a Guest user")]
        public void GivenIAmOnTrackYourOrderPageAsAGuestUser()
        {
            track.AccessPage();
        }

        [When(@"I submit the form with a valid email address and order number")]
        public void WhenISubmitTheFormWithAValidEmailAddressAndOrderNumber()
        {
            track.Track();
        }

        [When(@"I enter a valid email address but mistype the order number")]
        public void WhenIEnterAValidEmailAddressButMistypeTheOrderNumber()
        {
            track.Track("test12343@test.com", "0000000000");
        }

        [When(@"I mistype my email address but enter a valid order number")]
        public void WhenIMistypeMyEmailAddressButEnterAValidOrderNumber()
        {
            track.Track("test12343@tst.com", "1400330677");
        }

        [Then(@"I am informed that the '(.*)' I entered is incorrect")]
        public void ThenIAmInformedThatTheIEnteredIsIncorrect(string info)
        {
            track.ValidateMistypedInfo(info);
        }

        [Then(@"the order details page displays '(.*)'")]
        public void ThenTheOrderDetailsPageDisplays(string information)
        {
            track.ValidateTrackInformation(information);
        }

        [When(@"I access Your Orders page")]
        public void WhenIAccessYourOrdersPage()
        {
            track.AccessYourOrders();
        }

        [When(@"I sign in using Test email account")]
        public void WhenISignInUsingTestEmailAccount()
        {
            track.SignInTrack();
        }



    }
}
