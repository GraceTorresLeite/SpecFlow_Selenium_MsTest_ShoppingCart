Feature: ShoppingCart
![Your Logo](http://automationpractice.com/img/logo.jpg)
	As a person
	I want to complete a purchase in the online store
	To receive the product

@important
Scenario: Successful purchase - customer without registration
	Given I added the product to the cart
	When I finish adding my data
	Then the purchase order will be generated