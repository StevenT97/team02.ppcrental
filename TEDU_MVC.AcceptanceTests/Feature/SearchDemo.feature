@automated
Feature: SearchDemoz
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
	Given the following property Agency
         | Email                    | Password | FullName  | Phone      | Address | Role | Status | GroupID |
         | lythihuyenchau@gmail.com | 123456   | LyChau    | 0123456789 | Quan 1  | 1    | True	  | SALE    |
         | buibao1997@gmail.com     | 123456   | ShayneBui | 0123456789 | Quan 1  | 2    | False  | AGENCY  |
	Given the following property and list feature 'Ban công'
	| PropertyName                   | Content                                                 | Price | PropertyType | District  | Ward_ID  | Street_ID | UserID                   | StatusID |  Feature|
	| Gojko Adzic                    | Specification By Example                                | 1200  | Apartment    | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt |Ban công	     |
	| Eckhart Tolle                  | The Power of Now                                        | 1200  | Villa        | Chương Mỹ | Đại Yên  | Tân Bình  | buibao1997@gmail.com     | Đã duyệt |Chỗ đậu xe         |
	| Jeff Sutherland                | Scrum: The Art of Doing Twice the Work in Half the Time | 1600  | Office       | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt |Thang máy         |
	| Mitch Lacey                    | The Scrum Field Guide                                   | 1500  | House        | Chương Mỹ | Đại Yên  | Tân Bình  | buibao1997@gmail.com     | Đã duyệt |Vườn         |
	| Martin Fowler                  | Analysis Patterns                                       | 5000  | Apartment    | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt |Phòng tập Gym         |
	| Eric Evans                     | Domain Driven Design                                    | 4600  | Villa        | Chương Mỹ | Đại Yên  | Tân Bình  | buibao1997@gmail.com     | Đã duyệt |Nhà bếp         |
	| Ted Pattison                   | Inside Windows SharePoint Services                      | 1300  | Office       | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt |Phòng giặc ủi         |
	| Lisa Crispin and Janet Gregory | Agile Testing                                           | 2000  | House        | Chương Mỹ | Đại Yên  | Tân Bình  | buibao1997@gmail.com     | Đã duyệt |Cho nuôi thú cưng         |
	| Esther Derby and Diana Larsen  | Agile Retrospectives                                    | 1600  | Apartment    | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt |Hồ bơi         |


Scenario: Mot trong cac truong duoc chon
	When Tim property cac cum tu lll Name Quan Type '','','','',''
	Then Danh sach property hien ra chi nen co PropertyName chua ki tu: 'Esther Derby and Diana Larsen,Martin Fowler,Gojko Adzic'
Scenario: Khong co truong nao duoc chon
	When Khong co truong du lieu nao duoc nhap
	Then Danh sanh tat ca duoc hien thi
	| PropertyName                   | Content                                                 | Price| PropertyType	| District   | UserID						| StatusID |
	| Gojko Adzic                    | Specification By Example                                | 1200 | Apartment		| Ba Vì		 | lythihuyenchau@gmail.com		| Đã duyệt |
	| Eckhart Tolle                  | The Power of Now                                        | 1200 | Villa			| Chương Mỹ  | buibao1997@gmail.com			| Đã duyệt |
	| Jeff Sutherland                | Scrum: The Art of Doing Twice the Work in Half the Time | 1600 | Office			| Ba Vì      | lythihuyenchau@gmail.com		| Đã duyệt |
	| Mitch Lacey                    | The Scrum Field Guide                                   | 1500 | House			| Chương Mỹ  | buibao1997@gmail.com			| Đã duyệt |
	| Martin Fowler                  | Analysis Patterns                                       | 5000 | Apartment		| Ba Vì      | lythihuyenchau@gmail.com	    | Đã duyệt |
	| Eric Evans                     | Domain Driven Design                                    | 4600 | Villa			| Chương Mỹ  | buibao1997@gmail.com			| Đã duyệt |
	| Ted Pattison                   | Inside Windows SharePoint Services                      | 1300 | Office			| Ba Vì      | lythihuyenchau@gmail.com		| Đã duyệt |
	| Lisa Crispin and Janet Gregory | Agile Testing                                           | 2000 | House			| Chương Mỹ  | buibao1997@gmail.com			| Đã duyệt |
    | Esther Derby and Diana Larsen  | Agile Retrospectives                                    | 1600 | Apartment		| Ba Vì      | lythihuyenchau@gmail.com	    | Đã duyệt |
