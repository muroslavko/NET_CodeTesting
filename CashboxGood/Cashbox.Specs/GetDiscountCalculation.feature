Feature: GetDiscountCalculation

Scenario: Calculate Discount
	Given I have create account whith balance 200
	And I have selected products in the amount of 70
	When I ask what is account balance
	Then the result should be 130
