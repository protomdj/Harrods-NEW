Feature: Track Your Order
As a user
I want to check my order status
So that I know when it will be delivered

Background: 

Scenario Outline: Invalid email address
  Given I am on Track Your Order page as a Guest user
  When I Validate an invalid email '<format>'
  Then I am informed that the email address is invalid  
  Examples: of formats
  | format           |
  | without @ symbol |
  | without . symbol |

Scenario Outline: Guest User - Track Your Order
  Given I am on Track Your Order page as a Guest user
  When I submit the form with a valid email address and order number
  Then the order details page displays '<Information>'
  Examples: of information
   | Information                  |
   | order number                 |
   | order date                   |
   | delivery address             |
   | delivery method              |
   | status                       |
   | items ordered                |
   | option to sign in            | 

Scenario: Guest User - Mistype order number
  Given I am on Track Your Order page as a Guest user
  When I enter a valid email address but mistype the order number
  Then I am informed that the 'order number' I entered is incorrect

Scenario: Guest User - Mistype email address 
  Given I am on Track Your Order page as a Guest user
  When I mistype my email address but enter a valid order number
  Then I am informed that the 'email address' I entered is incorrect

Scenario Outline: Registered User - Track Your Order
  Given I am on the Sign In page
  When I sign in using Test email account 
  And I access Your Orders page 
  Then the order details page displays '<Information>'
  Examples: of information
   | Information                  |
   | ITEM                         |
   | PRICE                        |
   | QTY                          |
   | DISCOUNT                     |
   | SUBTOTAL                     |
   | STATUS                       |
   | DELIVERY DETAILS             |

#Scenario: Track an order with multiple shipments
#  When I submit the form with a valid email address and order number for a multiple shipment order
#  Then the following details are displayed for each shipment
#  | delivery address |
#  | delivery method  |
#  | status           |



#TODO: Potentially add extra scenarios for specific order statuses and check they are displayed correctly