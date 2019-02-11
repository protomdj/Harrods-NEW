Feature: PLP
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: Homepgage
	Given user is on the homepage

Scenario Outline: PLP filters
	Given I am on a PLP
	When I opt to apply '<filter title>' filter
	Then i am displayed a PLP of results that reflects my selection
	Examples: 
	| filter title |
	| Category     |
	| Brand        |
	| Size         |
	| Colour       |
	| Sleeves      |
	| Neckline     |

Scenario: View All
	Given I'm on a PLP with more than 60 products
	And I choose to select view all
	Then I am displayed all the products available for that PLP on one page

Scenario: Add to bag from PLP
	Given I access the quick shop from a PLP
	And I choose to add the product to  the bag
	Then The product is placed in users bag

Scenario: Apply sort options - PLP
	Given I choose to apply a sort option on the PLP
	Then The listing order on the page responds with relevant change to user selection.

