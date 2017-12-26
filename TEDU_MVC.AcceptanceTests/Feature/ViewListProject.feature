@automated
#@web
Feature: UC02_ViewListOfProject
	I want to view list of project

Background: 
	Given the following property Agency
         | Email                    | Password | FullName  | Phone      | Address | Role | Status | GroupID |
         | lythihuyenchau@gmail.com | 123456   | LyChau    | 0123456789 | Quan 1  | 1    | True	  | SALE    |
         | buibao1997@gmail.com     | 123456   | ShayneBui | 0123456789 | Quan 1  | 2    | True  | AGENCY  |
	And the following project
	| PropertyName                                 | Avarta                                           | Images                                                                             | PropertyType | Content                                                                                                      | Street          | Ward        | District | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | UserID       | Create_at  | Create_post | Status   | Note | Update_at  | Sale_ID        |
	| PIS Top Apartment                            | PIS_6656-Edit-stamp.jpg                          | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg  | Apartment    | The surrounding neighborhood is very much localized with a great number of local shops.                      | Cô Bắc          | P.Cô Giang  | Q.1      | 10000  | VND       | 120m2 | 3       | 2        | 1            | LyChau      | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | LyChau         |
	| ViLa Q7                                      | images172300301.jpg                              | images172300301.jpg                                                                | Villa        | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.   | Nguyễn Thị Thập | P.Phú Mỹ    | Q.7      | 70000  | VND       | 120m2 | 3       | 4        | 1            | LyChau      | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | LyChau         |
	| PIS Serviced Apartment – Style               | sunshine-benthanh-cityhome-10-stamp174228283.jpg | a - Copy17095239.jpg,images (1) - Copy17095242.jpg,images17095242.jpg              | Office       | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..          | Bền Văn Đồn     | P.03        | Q.4      | 30000  | VND       | 130m2 | 2       | 3        | 1            | ShayneBui       | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | ShayneBui       |
	| Vinhomes Central Park L2 – Duong’s Apartment | PIS_7389-Edit-stamp.jpg                          | images1702244617042862.jpg                                                         | Villa        | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. | Bà Hạt          | P.02        | Q.10     | 110000 | VND       | 150m2 | 4       | 2        | 1            | LyChau      | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | LyChau       |
	| Saigon Pearl Ruby Block                      | PIS_7319-Edit-stamp.jpg                          | images17423697317334243.jpg,PIS_4622-Edit17463610217334244.jpg                     | Apartment    | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | Chu Văn An      | P.Long Bình | Q.9      | 30000  | VND       | 130m2 | 3       | 5        | 1            | ShayneBui       | 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | ShayneBui	         |  
	And the following property_feature
	| Property                                     | Feature           |
	| PIS Top Apartment                            | Vườn              |
	| PIS Top Apartment                            | Hồ bơi            |
	| ViLa Q7                                      | Chỗ đậu xe        |
	| ViLa Q7                                      | Phòng tập Gym     |
	| ViLa Q7                                      | Hồ bơi            |
	| PIS Serviced Apartment – Style               | Thang máy         |
	| Vinhomes Central Park L2 – Duong’s Apartment | Sàn gỗ            |
	| Vinhomes Central Park L2 – Duong’s Apartment | Cho nuôi thú cưng |
	| Saigon Pearl Ruby Block                      | Vườn              |

Scenario: View List of Project Demo
	When I input 'buibao1997@gmail.com' and '123456' into Login paged
	| Email							| Pass		 | 
	| lythihuyenchau@gmail.com      | 123456     |
	Then I should see my own projects
	| PropertyName                                 |
	| PIS Serviced Apartment – Style               |
	| Saigon Pearl Ruby Block                      |
	
