Feature: PDP
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

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

Scenario Outline: Fashion Buying Controls and Section
  Given I want to check 'Fashion 1' is displaying correctly 
  When I validate Section on PDP
  Then the '<buying controls>' section contains the following
  Examples: of buying controls
  | buying controls         |
  | Brand                   |
  | Title                   |
  | Price                   |
  | ID                      |
  | Colour                  |
  | Size                    |
  | Quantity                |
  | Delivery & Returns      |
  | Add To Bag              |

Scenario Outline: GiftCard Buying Controls Section
  Given I want to check 'Gift Card' is displaying correctly
  Then the '<buying controls>' section contains the following 
  Examples: of buying controls
  | buying controls          |
  | Brand                    |
  | Title                    |
  | Price                    |
  | ID                       |
  | Quantity                 |
  | UK Only Delivery Message |
  | Delivery & Returns       |

Scenario Outline: Accessories Buying Controls and Section
  Given I want to check 'Fashion 2' is displaying correctly 
  When I validate Section on PDP
  Then the '<buying controls>' section contains the following
  Examples: of buying controls
  | buying controls         |
  | Brand                   |
  | Title                   |
  | Price                   |
  | ID                      |
  | Colour                  |
  | Quantity                |
  | Delivery & Returns      |
  | Add To Bag              |

Scenario Outline: Buggies Buying Controls and Section
  Given I want to check 'Buggies' is displaying correctly 
  When I validate Section on PDP
  Then the '<buying controls>' section contains the following
  Examples: of buying controls
  | buying controls         |
  | Brand                   |
  | Title                   |
  | Price                   |
  | ID                      |
  | Colour                  |
  | Quantity                |
  | Delivery & Returns      |
  | Add To Bag              |

Scenario Outline: Pairs Buying Controls and Section
  Given I want to check 'Pairs' is displaying correctly 
  When I validate Section on PDP
  Then the '<buying controls>' section contains the following
  Examples: of buying controls
  | buying controls         |
  | Brand                   |
  | Title                   |
  | Price                   |
  | ID                      |
  | Colour                  |
  | Size                    |
  | Quantity                |
  | Delivery & Returns      |
  | Add To Bag              |




