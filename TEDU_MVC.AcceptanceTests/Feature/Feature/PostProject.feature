Feature: PostProject
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: PostProject
	Given Toi dang o home page
	And toi bam nut login
	And toi dang o trang login
	And toi dien username va password
	And toi bam nut dangnhap
	And toi bam nut dashboard
	When toi vao trang Admin
	And toi bam nut Agency
	And toi bam nut List of Agency
	And toi vao trang View List of Agency Project
	And toi bam vao nut Create
	And toi nhap property name 'new Property by Thuan Nguyen','C:\\Users\\Public\\Pictures\\Sample Pictures\\Chrysanthemum.jpg','Chrysanthemum.jpg'
	And toi bam nut Create
	Then toi dung o trang View List of Agency Project 'new Property by Thuan Nguyen'
