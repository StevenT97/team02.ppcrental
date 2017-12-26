@web
#@automated
Feature: View Detail Project
	As a potential customer
	I want to see the details of a properties
	So that T can better decide to buy it.
	
Background: 
Given the following property Agency
    | Email                    | Password | FullName  | Phone      | Address | Role | Status | GroupID |
    | lythihuyenchau@gmail.com | 123456   | LyChau    | 0123456789 | Quan 1  | 1    | True	  | SALE    |
    | buibao1997@gmail.com     | 123456   | ShayneBui | 0123456789 | Quan 1  | 2    | False  | AGENCY  |
And the following property and list feature 'Ban công'
	| PropertyName                   | Content                                                 | Price | PropertyType | District  | Ward_ID  | Street_ID | UserID                   | StatusID | Feature           |
	| Gojko Adzic                    | Specification By Example                                | 1200  | Apartment    | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt | Ban công          |
	| Eckhart Tolle                  | The Power of Now                                        | 1200  | Villa        | Chương Mỹ | Đại Yên  | Tân Bình  | buibao1997@gmail.com     | Đã duyệt | Chỗ đậu xe        |
	| Jeff Sutherland                | Scrum: The Art of Doing Twice the Work in Half the Time | 1600  | Office       | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt | Thang máy         |
	| Mitch Lacey                    | The Scrum Field Guide                                   | 1500  | House        | Chương Mỹ | Đại Yên  | Tân Bình  | buibao1997@gmail.com     | Đã duyệt | Vườn              |
	| Martin Fowler                  | Analysis Patterns                                       | 5000  | Apartment    | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt | Phòng tập Gym     |
	| Eric Evans                     | Domain Driven Design                                    | 4600  | Villa        | Chương Mỹ | Đại Yên  | Tân Bình  | buibao1997@gmail.com     | Đã duyệt | Nhà bếp           |
	| Ted Pattison                   | Inside Windows SharePoint Services                      | 1300  | Office       | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt | Phòng giặc ủi     |
	| Lisa Crispin and Janet Gregory | Agile Testing                                           | 2000  | House        | Chương Mỹ | Đại Yên  | Tân Bình  | buibao1997@gmail.com     | Đã duyệt | Cho nuôi thú cưng |
	| Esther Derby and Diana Larsen  | Agile Retrospectives                                    | 1600  | Apartment    | Ba Vì     | Chu Minh | Đảo Ngắn  | lythihuyenchau@gmail.com | Đã duyệt | Hồ bơi            |

Scenario: The PropertyName, the content of it can show
Given I am Home page
When I open the details of 'Eckhart Tolle'
Then The details PropertyName should show
	| PropertyName  | Content | Price | PropertyType | District | Ward_ID | Street_ID | UserID | StatusID | Feature |
	| Eckhart Tolle | The Power of Now| 1200| Villa| Chương Mỹ| Đại Yên| Tân Bình| buibao1997@gmail.com|Đã duyệt|Chỗ đậu xe|


