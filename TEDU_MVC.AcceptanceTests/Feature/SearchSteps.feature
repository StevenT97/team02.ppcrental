
@web
Feature:Property Search
	As a potential customer
	I want to search for books by a simple phrase
	So that I can easily allocate books by something I remember from them.

Background:
Given the following propertys

Scenario: PropertyName should be matched
	When Tim project bang cum tu 'PIS'
	Then Danh sach hien ra chi nen co PropertyName chua ki tu: 'PIS Top Apartment,PIS Serviced Ap'
	
Scenario: PropertyType should be matched
	When Tim project bang chon tu combobox Type 'Apartment'
	Then Danh sach hien ra chi nen co PropertyType la: 'PIS Top Apartment,Saigon Pearl Ru,Nguyen Dinh Chi'

Scenario: District should be matched
	When Tim project bang chon tu combobox District 'Ba Vì'
	Then Danh sach hien ra chi nen co: 'PIS Top Apartment,ICON 56 – Moder,chay dum con,Bigroom with Ri'

Scenario: District, PropertyType, PropertyName not macthed TH4
	When Search voi cac gia tri null
	Then District, PropertyType, PropertyName Hien thi tat ca cac du an 'ICON 56 – Moder,chay dum con,PIS Top Apartment,Bigroom with Ri,PIS Serviced Ap,san pham cua toi 1,Sunshine Ben Thanh,Nguyen Dinh Chi,Saigon Pearl Ru'

Scenario: District, PropertyType should matched TH5
	When Gia tri truyen vao District vs PropertyType l: 'Ba Vì','Apartment'
	Then District, PropertyType Danh sach hien thi ra bao gom: 'PIS Top Apartment'

Scenario: District, PropertyName should matched TH6
	When Gia tri truyen vao District vs PropertyName ll: 'Ba Vì','PIS'
	Then District, PropertyName Danh sach hien thi ra bao gom: 'PIS Top Apartment'

Scenario: PropertyType, PropertyName should matched TH7
	When Gia tri truyen vao PropertyName vs PropertyName lll: 'Villa','on'
	Then PropertyType, PropertyName Danh sach hien thi ra bao gom: 'chay dum con,ICON 56 – Moder'

Scenario: District, PropertyType, PropertyName should macthed TH8
	When Gia tri truyen vao District vs PropertyName vs PropertyName llll: 'Ba Vì','Villa','icon'
	Then District, PropertyType, PropertyName Danh sach hien thi ra bao gom: 'ICON 56 – Moder'


