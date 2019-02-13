Feature: PDP

Background: Homepgage
	Given user is on the homepage

Scenario: Add to bag from PDP
	Given I am on a product PDP
	And I choose to add the product to  the bag
	Then The product is placed in users bag

Scenario Outline: PDP templates check
	Given I want to check '<PDP template>' is displaying correctly
	Then When I navigate there I am served correct infomation
	Examples:
	| PDP template |
	| Fashion 1    |
	| Fashion 2    |
	| Buggies      |
	| Pairs        |
	| Bedding      |
	| Towels       |
	| Tableware    |
	| Gift Card    |

Scenario Outline: Validate Buying Controls and Section
  Given I want to check '<PDP template>' is displaying correctly 
  When I validate Section on PDP
  Then I validate '<PDP template>' buying controls
  Examples:
	| PDP template |
	| Fashion 1    |
	| Fashion 2    |
	| Buggies      |
	| Pairs        |
 	| Bedding      |
	| Towels       |
	| Tableware    |
	| Gift Card    |