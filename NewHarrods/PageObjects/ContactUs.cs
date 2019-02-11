using NewHarrods.Classes;
using NewHarrods.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace NewHarrods.PageObjects
{
    public class ContactUs : BaseTestClass
    {
        #region WebElements
        private By _contactuslnk = By.XPath("//*[@class='footer-links_link']");
        private By _title = By.XPath("//*[@id='Title']");
        private By _lastName = By.XPath("//*[@id='LastName']");
        private By _email = By.XPath("//*[@id='EmailAddress']");
        private By _enquiryTopic = By.XPath("//*[@id='EnquiryTopic']");
        private By _yourMessage = By.XPath("//*[@id='YourMessage']");
        private By _titleError = By.XPath("//*[@id='Title-error']");
        private By _lastNameError = By.XPath("//*[@id='LastName-error']");
        private By _emailError = By.XPath("//*[@id='EmailAddress-error']");          
        private By _enquiryTopicError = By.XPath("//*[@id='EnquiryTopic-error']");
        private By _yourMessageError = By.XPath("//*[@id='YourMessage-error']");
        private By _sendMessage = By.XPath("//*[@class='button button--primary button--arrow-after']");
        private By _messageSent = By.XPath("//*[@class='secure_content-title secure_content-title--success']");
        private By _sendAnotherMessage = By.XPath("//*[@class='button button--secondary button--arrow-after']");
        private By _faqLink = By.XPath("//*[@class='button button--text button--arrow-after']");
        private By _enquiryOptions = By.XPath("//*[@class='contact-us_sections']");
        private By _storeVisit = By.XPath("//*[@class='contact-us_footnote']");
        

        #endregion
        public void AccessPage()
        {
            FindElementCustom("a","Contact Us").Click();
            //FindElementByElement(_contactuslnk).Click();
        }

        public void validateEmail(string EmailIssue)
        {
            WaitElementUntil(_email);

            if (EmailIssue == "without @ symbol")
            {
                FindElementByElement(_email).SendKeys("test-test.com");            
            }
            else if (EmailIssue == "without . symbol")
            {
                FindElementByElement(_email).SendKeys("test@testcom");
            }

            FindElementByElement(_email).SendKeys(Keys.Tab);
            //FindElementByElement(_sendMessage).Submit();

            WaitElementUntil(_emailError);

            try
                {
                   FindElementByElement(_emailError).Text.Contains("Please enter a valid email address");
                }
                catch (ErrorMessageNotDisplayed)
                {
                    Assert.Fail("The Error Message Was Not Displayed");
                }
        }

        public void validateFields(string field)
        {
            WaitElementUntil(_sendMessage);

            if (field == "Title")
            {
                DropDownSelectValue(_title, "");
                FindElementByElement(_lastName).SendKeys("Tester");
                FindElementByElement(_email).SendKeys("Tester@test.com");
                DropDownSelectValue(_enquiryTopic, "1");
                FindElementByElement(_yourMessage).SendKeys("Test question");

                FindElementByElement(_sendMessage).Submit();
                WaitElementUntil(_titleError);
                FindElementByElement(_titleError);
            }
            else if(field == "Last Name")
            {
                DropDownSelectValue(_title, "Mr");
                FindElementByElement(_lastName).SendKeys("");
                FindElementByElement(_email).SendKeys("Tester@test.com");
                DropDownSelectValue(_enquiryTopic,"1");
                FindElementByElement(_yourMessage).SendKeys("Test question");

                FindElementByElement(_sendMessage).Submit();
                WaitElementUntil(_lastNameError);
                FindElementByElement(_lastNameError);
            }
            else if (field == "Email Address")
            {
                DropDownSelectValue(_title, "Mr");
                FindElementByElement(_lastName).SendKeys("Tester");
                FindElementByElement(_email).SendKeys("");
                DropDownSelectValue(_enquiryTopic, "1");
                FindElementByElement(_yourMessage).SendKeys("Test question");

                FindElementByElement(_sendMessage).Submit();
                WaitElementUntil(_emailError);
                FindElementByElement(_emailError);
            }
            else if (field == "Enquiry Topic")
            {
                DropDownSelectValue(_title, "Mr");
                FindElementByElement(_lastName).SendKeys("Tester");
                FindElementByElement(_email).SendKeys("Tester@test.com");
                DropDownSelectValue(_enquiryTopic, "");
                FindElementByElement(_yourMessage).SendKeys("Test question");

                FindElementByElement(_sendMessage).Submit();
                WaitElementUntil(_enquiryTopicError);
                FindElementByElement(_enquiryTopicError);
            }
            else if (field == "Your Message")
            {
                DropDownSelectValue(_title, "Mr");
                FindElementByElement(_lastName).SendKeys("Tester");
                FindElementByElement(_email).SendKeys("Tester@test.com");
                DropDownSelectValue(_enquiryTopic, "1");
                FindElementByElement(_yourMessage).SendKeys("");

                FindElementByElement(_sendMessage).Submit();
                WaitElementUntil(_yourMessageError);
                FindElementByElement(_yourMessageError);
            }
           
        }
        public void validateForm()
        {
            FindElementByElement(_sendMessage).Submit();
            WaitElementUntil(_yourMessageError);

            try
            {
                FindElementByElement(_titleError);
                FindElementByElement(_lastNameError);
                FindElementByElement(_emailError);
                FindElementByElement(_enquiryTopicError);
                FindElementByElement(_yourMessageError);
            }
            catch (ErrorMessageNotDisplayed)
            {
                Assert.Fail("The Error Message Was Not Displayed");
            }
        }

        public void validDetails()
        {
            DropDownSelectValue(_title, "Mr");
            FindElementByElement(_lastName).SendKeys("Tester");
            FindElementByElement(_email).SendKeys("Tester@test.com");
            DropDownSelectValue(_enquiryTopic, "1");
            FindElementByElement(_yourMessage).SendKeys("test message");

            FindElementByElement(_sendMessage).Submit();
        }

        public void messageSentNotification()
        {
            WaitElementUntil(_messageSent);

            try
            {
                Assert.AreEqual(FindElementByElement(_messageSent).Text, "MESSAGE SENT");
            }
            catch (ErrorMessageNotDisplayed)
            {
                Assert.Fail("Message not sent");
            }
        }

        public void SendAnotherMessage()
        {
            try
            {
                Assert.AreEqual(FindElementByElement(_sendAnotherMessage).Text, "SEND ANOTHER MESSAGE");
            }
            catch (ErrorMessageNotDisplayed)
            {
                Assert.Fail("Send another message option not found");
            }
        }

        public void FAQlink()
        {
            try
            {
                Assert.AreEqual(FindElementByElement(_faqLink).Text, "VIEW OUR FAQS");
            }
            catch (ErrorMessageNotDisplayed)
            {
                Assert.Fail("View our FAQS option not found");
            }
        }

        public void ValidateHeaders(string headers)
        {
            if (headers == "store enquiries")
            {
                FindElementByElement(_enquiryOptions).Text.Contains("Store Enquiries");
            }
            else if (headers == "online enquiries")
            {
                FindElementByElement(_enquiryOptions).Text.Contains("Online Enquiries");
            }
            else if (headers == "email")
            {
                FindElementByElement(_enquiryOptions).Text.Contains("Email");
            }
            else if (headers == "store address")
            {
                FindElementByElement(_storeVisit).Text.Contains("87-135 Brompton Road Knightsbridge, London SW1X 7XL, United Kingdom");
            }
            else if (headers == "plan your visit")
            {
                FindElementByElement(_storeVisit).Text.Contains("Plan your visit");
            }          
        }
    }
}
