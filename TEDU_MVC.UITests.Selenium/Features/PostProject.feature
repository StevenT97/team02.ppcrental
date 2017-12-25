Feature: PostProject
	I want to post a property to the website


@mytag
Scenario: Post one project
	Given I am at Home page
	And I click Login button
	And I am at Login page
	And I entered email and password are 'buibao1997@gmail.com','123456' and click login
	And I click Dashboard
	When I am at Admin Page
	And I click Agency button
	And I click List Of Agency
	And I am at View List Project page
	And I click Create button
	And I input new property with these info 'new Property by Thuan Nguyen','D:\testimage1.jpg'
	And I click Create button
	Then I am at View List Project have new property
