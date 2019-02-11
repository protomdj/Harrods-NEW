Feature: Contact Us
As a user
I want to know how to contact Harrods
So that I can get answers to any questions I have

Background: 
Given I am on the Contact Us page

Scenario: Sent a message via Contact Us page
  When I submit the form with valid details 
  Then I am informed that the message has been sent 
  And there is an option to send another message 
  And there is a link to view FAQs page


Scenario: Contact Us - Empty form fields
  When I submit the form without entering any values
  Then I am informed that the fields must be completed
  

  Scenario Outline: Contact Us - Invalid email address Format
  When I Validate an invalid email '<format>'
  Then I am informed that the email address is invalid  
  Examples:
  |format|
  | without @ symbol |
  | without . symbol |

 
Scenario Outline: Contact Us - Header
  Then the header contains the following '<headers>'
  Examples:
  |headers|
  | store enquiries  |
  | online enquiries |
  | email            |
  | store address    |
  | plan your visit  |

  Scenario Outline: Contact Us - Validate Invalid fields
  When I submit the form with a empty '<fields>'
  Then I am informed that a value should be selected
  Examples:
  |fields| 
  | Title         | 
  | Last Name     | 
  | Email Address | 
  | Enquiry Topic |
  | Your Message  | 

# Scenario Outline: Contact Us - Empty fields selection
#  When I submit the form without selecting a value for <fields>
#  Then I am informed that a value should be selected 
#
#   Examples: of values
#  |  fields        | 
#  | Title         | 
#  | Last Name     | 
#  | Email Address | 
#  | Enquiry Topic |
#  | Your Message  | 