Feature: User Card and Address setting
As a Registered User
	I want to be able to enter my information
	So I can store it in my account

Background: Given I am a registered user
Given I am on the Sign In page
When I sign in using Test email account


Scenario Outline: Add new Delivery address 
	When I Navigate to the Manage Delivery Addresses page
	And I choose to Add a new address
	When I enter valid address '<AddressType>' details
	Then I Validate new address is added
	Examples: 
	  | AddressType       |
	  | UK                |
	  | Borderfree EU     |
	  | Borderfree US     |
	  | Borderfree ROW    |
	  | Borderfree China  |

 
Scenario Outline: Add a new card, new address and save the card
When I Navigate to Manage Cards and Billing Addresses
And I choose to Add a new card
And I enter valid card '<PaymentType>' details		   
Then I Validate new Card is added
	Examples: 
	   | PaymentType      |
	   | Visa             |
	   | China Union Pay  |
	   | American Express | 
	   | Mastercard       |
