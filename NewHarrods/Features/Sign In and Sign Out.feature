Feature: Sign In and Sign Out
As a user
I want to sign in 
So that I can access my account  

Background: 
	Given user is on the homepage

Scenario Outline: Sign In - Invalid email address
  Given I am on the Sign In page
  When I enter an email address <format> 
  Then I am informed that the email address is invalid 
    
	Examples: of formats
  | format           |
  | without @ symbol |
  | without . symbol |

Scenario: Sign In - Invalid password 
  Given I am on the Sign In page
  When I enter a wrong password 
  Then I am informed that the login attempt is not successful

Scenario Outline:Sign In 
	Given I am a '<user type>'
	And I choose to sign in with my valid credentials
	Then I am taken into my accounts landing page
	Examples: 
	| user type  |
	| Rewards    |
	| Nonrewards |
 
Scenario: Sign In - Forgotten Password link
  Given I am on the Sign In page
  When I select forgotten password link
  Then I am taken to the reset your password page
  
Scenario: Sign In - Option to register for new account
  Given I am on the Sign In page
  Then there is an option to register for new account 

Scenario:Smoke Test - Sign Out
	Given I am a logged in user
	And I choose to log out
	Then I am no longer able to see my account name in the header or access account info

Scenario Outline:Smoke Test - Rewards landing page
	Given I am a '<user type>'
	When I choose to navigate to rewards landing page
	Then I am served the appropriate version of the page
    Examples: 
	| user type  |
	| Rewards    |
	| Guest      |
   #| Nonrewards |