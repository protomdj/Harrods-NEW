Feature: Product Search

Background: Homepgage
	Given user is on the homepage

Scenario Outline: Product search
	Given I am searching for a '<search entry>'
	Then I am taken directly to the PDP of the relevant product
	Examples:
	| search entry  |
	| Product ID    |
	| Product Title |

Scenario: Check brand A-Z
	Given I want to see if the Brand A-Z page is displaying correctly
	And I navigate there
	Then i am displayed the page correctly
	
Scenario: Check brand page
	Given I want to check brand pages are displaying correctly
	And I check for a OK reponse code
	Then The page will be up an running

Scenario: Add to bag from search results
	Given I search a keyword
	And I choose to add the product to  the bag
	Then The product is placed in users bag

	
	#Scenario:Smoke Test - Register for mailing list
	##Given I opt to register for the mailing list
	##Then my email is taken and I'm displayed some form of confirmation

	#@ignore
	#Scenario: Smoke Test - API Tests
	#Given I run the SoapUI Tests
	#Then They all pass.
