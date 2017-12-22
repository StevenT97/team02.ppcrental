Feature: ViewListProject
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: View List Project
	Given Toi dang o Home Page
	And Toi bam nut Login
	When Toi dang o trang Login
	And Toi dien username va password
	And Toi bam nut Login
	And Toi bam nut Dashboard
	And Toi vao trang Admin
	And Toi bam nut Agency
	And Toi bam nut List of Agency
	Then Toi vao trang View List of Project 
