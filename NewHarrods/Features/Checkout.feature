Feature: Checkout
Verify users are able to checkout as both a registered user and a guest user
Verify all features relating to checkout works as intended

Background: Products in the bag
	Given I have an item in my bag

Scenario Outline: Checkout as a registered user with saved delivery and card information.
Given I am logged in and I progress to checkout
When I select a '<DeliveryType>' address
And I select a '<PaymentType>' payment card
Then I am able to complete checkout successfully
Examples: 
	   | PaymentType      | DeliveryType     |
	   | Visa             | UK               |
	   | Paypal           | UK               |
	   | American Express | UK               |
	   | Mastercard       | UK               |
	   | New Card         | UK               |
	   | Visa             | Borderfree EU    |
	   | Paypal           | Borderfree EU    |
	   | American Express | Borderfree EU    |
	   | Mastercard       | Borderfree EU    |
	   | New Card         | Borderfree EU    |
	   | Visa             | Borderfree US    |
	   | Paypal           | Borderfree US    |
	   | American Express | Borderfree US    |
	   | Mastercard       | Borderfree US    |
	   | New Card         | Borderfree US    |
	   | Visa             | Borderfree ROW   |
	   | Paypal           | Borderfree ROW   |
	   | American Express | Borderfree ROW   |
	   | Mastercard       | Borderfree ROW   |
	   | New Card         | Borderfree ROW   |
	   | AliPay           | Borderfree China |

Scenario Outline: SmokeTest - Checkout out as a guest user.
	Given I am not logged in and I progress to checkout
	When I enter valid delivery '<DeliveryType>' details	
	And I enter valid '<PaymentType>' details		   
	Then I am able to complete checkout successfully
	Examples: 
	   | PaymentType      | DeliveryType      |
	   | Visa             | UK                |
	   | Paypal           | UK                |
	   | American Express | UK                |
	   | Mastercard       | UK                |
	   | Visa             | Borderfree EU     |
	   | Paypal           | Borderfree EU     |
	   | American Express | Borderfree EU     |
	   | Mastercard       | Borderfree EU     |
	   | Visa             | Borderfree US     |
	   | Paypal           | Borderfree US     |
	   | American Express | Borderfree US     |
	   | Mastercard       | Borderfree US     |
	   | Visa             | Borderfree ROW    |
	   | Paypal           | Borderfree ROW    |
	   | American Express | Borderfree ROW    |
	   | Mastercard       | Borderfree ROW    |
	   | China Union Pay  | Borderfree Dollar |
	   | AliPay           | Borderfree China  |
	   
Scenario: Add a valid gift message
	Given I am logged in and I progress to checkout
	When I select a 'UK' address
	And I have chosen to add a gift message 'Test Message'
	And I select a 'Visa' payment card	
	Then I am able to confirm gift message 'Test Message' after completing checkout

Scenario: Redeem gift card balance as a UK user only
	Given I am logged in and I progress to checkout
	When I select a 'UK' address
    And I have chosen to use a gift card
    Then I am able to redeem the card balance

Scenario Outline: Validate all shipping method as a UK user only
	Given I am logged in and I progress to checkout
	When I select a 'UK' address
	Then Validate '<shipping method>' available for UK user
	Examples: 
	| shipping method          |
	| UK Standard (3 to 5 days)|
	| Pre 9am Next day         |
	| Next Day                 |
	| Saturday                 |
	| Sunday                   |

Scenario Outline: Validate all shipping method as a EU user only
	Given I am logged in and I progress to checkout
	When I select a 'Borderfree EU' address
	Then Validate '<shipping method>' available for UK user
	Examples: 
	| shipping method          |
	| Europe                   |

Scenario Outline: Validate all shipping method as a ROW user only
	Given I am logged in and I progress to checkout
	When I select a 'Borderfree ROW' address
	Then Validate '<shipping method>' available for UK user
	Examples: 
	| shipping method          |
	| Worldwide                |