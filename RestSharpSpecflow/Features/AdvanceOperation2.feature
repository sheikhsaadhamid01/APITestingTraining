Feature: AdvanceOperation2
	

Advanced API testing Operations

@smoke
Scenario: Verify if Product1 is always Same
	Given user perform a GET Operation of "Product/GetProductById/{id}"
		| ProductId |
		|      1     |
	And user perform another GET operation of "Product/GetProductById/{id}"
		| ProductId |
		|      1     |
	Then user should get a product name as "Keyboard"



Scenario: Verify if Product1 and Product2 Manufacturers are same
	Given user perform a GET Operation of "Product/GetProductById/{id}"
		| ProductId |
		|      1     |
	And user perform another GET operation of "Product/GetProductById/{id}"
		| ProductId |
		|      2     |

	Then user should verify if Product1 and Product2 Address are same