Feature: Sanity Check

Background: Homepgage
	Given user is on the homepage

Scenario: Homepage displays as expected
	Given I have navigated to the harrods site homepage
	Then I am served a header, footer and site content

Scenario: Link Checker - HomePage
	Given I want to check all links on the homepage return a 200 response code
	When I run my link checker
	Then all links on the page return 200 response code

	
	
