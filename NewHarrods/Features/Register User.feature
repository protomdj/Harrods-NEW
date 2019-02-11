Feature: Register User
	
	Background: Homepgage
	Given user is on the homepage


	Scenario: Register for rewards account
	Given I choose to register for a rewards account
	Then I am able to complete the form and end up logged in to my new user account

	
	Scenario: Register for nonrewards account
	Given I choose to register for a nonrewards account
	Then I am able to complete the form and end up logged in to my new user account

