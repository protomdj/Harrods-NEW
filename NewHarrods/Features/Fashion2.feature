Feature: Fashion2 PDP
    As a user 
	I want to see all details for Fashion2 products
	So that I can make an informed decision

Scenario: Buying Controls Section
  Given I am on a Fashion2 PDP with colour and size 
  Then the buying controls section contains the following
  | Brand                   |
  | Title                   |
  | Price                   |
  | ID                      |
  | Colour                  |
  | Size                    |
  | Quanity                 |
  | Delivery & Returns link |

Scenario Outline: Multiple variants available
  Given I am on a Fashion2 PDP with multiple <variants> 
  Then all <variants> are displayed

  Examples: of variants
  | variants |
  | colours  |
  | sizes    |

Scenario: Add in-stock product to bag 
  Given I am on a Fashion2 PDP
  And the product is in stock
  When I add the product to my bag
  Then a confirmation pane is displayed on screen
  And the following options are available
  | go to shopping bag |
  | go to checkout     |

Scenario: All variants are OOS
  Given I am on a Fashion2 PDP with colour and size variants
  And all variants of the product are out of stock
  Then the out of stock message is displayed
  And there is no option to add the product to the bag
	
Scenario Outline: One variant of the product is OOS
  Given I am on a Fashion2 PDP with colour and size variants
  And one <variant> of the product is out of stock
  Then the out of stock <variant> is not displayed as an option
  And other variants can be added to bag

  Examples: of variants
  | variant |
  | colour  |
  | size    |

@desktop
Scenario: Confirmation pane persists
  Given I am on a Fashion2 PDP
  And I have added the product to my bag
  And the cursor has remained over the buying controls
  Then the confirmation pane remains displayed

Scenario Outline: Social sharing
  Given I am on a Fashion2 PDP with colour and size variants
  When I share via <platform>
  Then the product link is shared on <platform>

  Examples: of platforms
  | platform  |
  | Facebook  |
  | Twitter   |
  | Pinterest |

Scenario Outline: Shop More
  Given I am on a Fashion2 PDP
  When I select to shop more <option>
  Then I am taken to the <option> PLP

  Examples: of options
  | option   |
  | brand    |
  | category |
  
Scenario: Overview
  Given I am on a Fashion2 PDP
  Then the product overview is displayed

Scenario: Breadcrumb
  Given I am on a Fashion2 PDP
  Then the breadcrumb is present
  And each part of the breadcrumb links to the correct page

Scenario: Product associations
  Given I am on a Fashion2 PDP which has product associations
  Then each assocation displays the following
  | main image   |
  | brand        |
  | product name |
  | price        |  

@desktop
Scenario: Product association quickshop panel
  Given I am on a Fashion2 PDP which has product associations
  When I open the quickshop panel for an assocation
  Then the following is displayed
  | image carousel    |
  | brand             |
  | product name      |
  | price             |
  | ID                |
  | size              |
  | colour            |
  | full details link |
  
  @desktop
Scenario: Product association add to bag (in stock)
  Given I am on a Fashion2 PDP which has product associations
  When I add an associated product to bag
  Then the product is added to my bag

  @desktop
Scenario Outline: Product association add to bag (one variant OOS)
  Given I am on a Fashion2 PDP which has product associations
  And one <variant> of the associated product is out of stock
  Then the out of stock <variant> is not displayed as an option
  And other variants can be added to bag

  Examples: of variants
  | variant |
  | colour  |
  | size    |

  #need to check if this is correct - or whether QS panel should not be displayed at all
@desktop
Scenario: Product association add to bag (all variants OOS)
  Given I am on a Fashion2 PDP which has product associations
  And all variants of the associated product are out of stock
  Then the out of stock message is not displayed on the quickshop panel
  And there is no option to add the assocaited product to the bag

Scenario: Size guide 
  Given I am on a Fashion2 PDP with a size guide
  When I open the size guide module
  Then the relevant size guide information is displayed for the product

  Scenario: Size guide with fit notes
  Given I am on a Fashion2 PDP which has fit notes
  When I open the size guide module
  Then the relevant fit notes information is displayed for the product 
  And the model image is displayed as the background

Scenario: Delivery & Returns 
  Given I am on a Fashion2 PDP with delivery & returns
  When I open the delivery & returns module
  Then delivery and returns information is displayed
  
Scenario Outline: Image carousel
  Given I am on a Fashion2 PDP
  Then image thumbnails are displayed 
  When I navigate <direction> through the image carousel
  Then the <position> image is displayed

  Examples: of directions and positions
  | direction | position |
  | right     | next     |
  | left      | previous |

Scenario: Image pagination
  Given I am on a Fashion2 PDP
  Then image thumbnails are displayed 
  When I navigate through the image pagination
  Then the correct image is displayed

Scenario: Zoom image
  Given I am on a Fashion2 PDP
  When I select to zoom the image
  Then the image is displayed as zoomed in
