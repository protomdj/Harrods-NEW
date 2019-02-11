using NewHarrods.Classes;
using NewHarrods.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NewHarrods.Definitions
{
    [Binding]
    public sealed class UserDetailsDefinitions : BaseTestClass
    {
        SignIn signin = new SignIn();
        CheckoutDelivery checkoutDelivTest = new CheckoutDelivery();

        [When(@"I Navigate to the Manage Delivery Addresses page")]
        public void WhenINavigateToTheManageDeliveryAddressesPage()
        {
            signin.ManageAddress();
        }

        [When(@"I choose to Add a new address")]
        public void WhenIChooseToAddANewAddress()
        {
            signin.AddAddress();
        }

        [Then(@"I Validate new address is added")]
        public void ThenIValidateNewAddressIsAdded()
        {
            signin.ValidateAddress();
        }


        [When(@"I enter valid address '(.*)' details")]
        public void WhenIEnterValidAddressDetails(string deliveryType)
        {
            signin.City = "City";
            signin.Street = "Street";
            signin.Zipcode = "112233";
            signin.DeliveryMethodIndex = 0;

            switch (deliveryType)
            {
                case "UK":
                    signin.Country = "United Kingdom";
                    signin.UKPostcode = "W14 8YW";
                    break;
                case "Borderfree EU":
                    signin.Street = "Avda. de Concha Espina 1";
                    signin.Country = "Spain";
                    signin.Zipcode = "28036";
                    signin.City = "Madrid";
                    //signin.State = "Madrid";
                    break;
                case "Borderfree US":
                    signin.Street = "292 Maddison Ave";
                    signin.Country = "United States";
                    signin.City = "New York";
                    signin.Zipcode = "10017";
                    signin.State = "New York";
                    break;
                case "Borderfree ROW":
                    signin.City = "Dubai";
                    signin.Street = "Downtown Dubai";
                    signin.Zipcode = "31166";
                    signin.Country = "United Arab Emirates";
                    break;
                case "Borderfree China":
                    signin.Street = "1 Nanjing East Road";
                    signin.City = "Huangpu District";
                    signin.Country = "China";
                    signin.Zipcode = "200000";
                    signin.State = "Shanghai";
                    break;
            }

            signin.DeliveryInfo(deliveryType);

        }

        [When(@"I Navigate to Manage Cards and Billing Addresses")]
        public void WhenINavigateToManageCardsAndBillingAddresses()
        {
            signin.ManageCard();
        }


        [When(@"I choose to Add a new card")]
        public void WhenIChooseToAddANewCard()
        {
            signin.AddCard();
        }

        [When(@"I enter valid card '(.*)' details")]
        public void WhenIEnterValidCardDetails(string paymentType)
        {
            string cvv = null;
            string cardno = null;

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
            signin.CompleteCardInfo(paymentType, cardno, "AutoName", "1", "2022", cvv);
        }

        [Then(@"I Validate new Card is added")]
        public void ThenIValidateNewCardIsAdded()
        {
            signin.ValidateCard();
        }


    }
}
