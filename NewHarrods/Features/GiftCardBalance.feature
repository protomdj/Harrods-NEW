Feature: GiftCard

As a user
I want to check my gift card balance and also purchase a gift card

Background: Giftcard Balance
Given I am on the Gift Card Balance page


Scenario Outline: Invalid Gift Card Number
  When I a Enter gift card number with '<type>'
  Then a Gift Card Number error message '<result>' is displayed
  Examples: of types and results
 | type          | result                               |
 | Empty         | Please enter your gift card number   |
 | 15 digits     | Gift card number length is incorrect |
 | 17 digits     | Gift card number length is incorrect |
 | invalid characters | Please use numeric digits only when entering your gift card number |

Scenario Outline: Invalid PIN Number
  When I enter a PIN number which contains '<type>'
  Then I am informed that the number is '<result>'
 Examples: of formats and error messages
 | type               | result           |
 | Empty              | Please enter your gift card pin number|
 | 3 digits           | Please enter a valid pin    |
 | 5 digits           | Please enter a valid pin    |
 | invalid characters | Please use numeric digits only when entering your gift card pin |

  Scenario: Check gift card balance
  When I submit the form with a valid gift card number and PIN
  Then the Gift Card balance page is displayed

  Scenario Outline: Check Gift Card purchase options 
  Given I am on a gift card PDP
  When I add gift cards totalling '<Amount>' to my bag
  Then a '<Result>' is displayed on screen
  Examples: of buying maximum and minimum
  |Amount             | Result          |
  |Less than £2500    | Successful      |
  |More than £2500    | Unsuccessful    |

  

