Feature: ViewListProject
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@web
Scenario: ViewListProject
	Given Toi dang o trang HomePage
	And Toi bam vao nutt Login
	When Toi dang o trang Login
	And Toi dien username va password
	And Toi bam vao nut Login
	And Toi vao trang Home
	And Toi bam nut Dashboard
	And Toi vao trang cua Admin
	And Toi bam nut Sale
	And Toi bam nut List of Project
	Then Toi thay list project: 'san pham cua toi 1,PIS Serviced Apartment – Style 3,Bigroom with Riverview,chay dum con,ICON 56 – Modern Style Apartment'
