Feature: AdvancedOperation
	Advanced API testing operations

	@smoke
	Scenario: Verify If Product1 Is Always Same
		Given I perform a GET operation of "Product/GetProductById/{id}"
		  | ProductId |
		  | 1         |
		And I perform another GET operation "Product/GetProductById/{id}"
		  | ProductId |
		  | 1         |
		And I should verify if Product is always the same
		
		
	@smoke
	Scenario: Verify If Product1 And Product2 Manufacturers Address Are Same
		Given I perform a GET operation of "Product/GetProductById/{id}"
		  | ProductId |
		  | 1         |
		And I perform another GET operation "Product/GetProductById/{id}"
		  | ProductId |
		  | 5         |
		And I should verify if Product1 and Product2 addresses are the same
		
	
	# Just another example not in our course recording, but gives more idea	
	@smoke
	Scenario: Verify If Product1 And Product2 Manufacturers Are Same
		Given I perform a GET operation of "Product/GetProductById/{id}"
		  | ProductId |
		  | 1         |
		And I perform another GET operation "Product/GetProductById/{id}"
		  | ProductId |
		  | 1         |
		And I should verify if Product1 and Product2 manufacturers are the same
