Feature: edittest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: I want edit project 
	Given I stay homepage
	And I want login 
	And I stay login page
	And i write username And Password
	And i click login button
	When I stay home page
	And I click dashboard
	And I STAY adminpage
	And I Click agency Project
	And I See List Project 
	And I click edit  a project
	And I stay Edit PAge
	And I Editing Project
	And I Click Save
	Then I stay List Project Page
