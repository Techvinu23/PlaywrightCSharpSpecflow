Feature: Login to the web application

@mytag
Scenario: User login into the EAAPP web site
	Given I navigate to the application
	And I click on login link
	And Enter following user details
	    | UserName | Password |
	    | VTest123 | Test@123 |
	Then User should login 