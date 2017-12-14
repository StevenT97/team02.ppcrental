Feature: EditTest2
	In order to avoid silly mistakes
	As a math idiot
	I want edit a project

Background: 
	Given I want Edit follow this Catalog
	| PropertyName                                 | PropertyType | Content                                                                                                      | Street | Ward | District | Price  | Area  | BedRoom | BathRoom | PackingPlace |
	| PIS Top Apartment                            | 1            | The surrounding neighborhood is very much localized with a great number of local shops.                      | 748    | 2    | 2        | 10000  | 120m2 | 3       | 2        | 1            |
	| ViLa Q7                                      | 2            | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.   | 750    | 3    | 2        | 70000  | 120m2 | 3       | 4        | 1            |
	| PIS Serviced Apartment – Style               | 3            | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..          | 749    | 4    | 2        | 30000  | 130m2 | 2       | 3        | 1            |
	| Vinhomes Central Park L2 – Duong’s Apartment | 2            | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. | 755    | 33   | 3        | 110000 | 150m2 | 4       | 2        | 1            |
	| Saigon Pearl Ruby Block                      | 1            | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | 758    | 35   | 3        | 30000  | 130m2 | 3       | 5        | 1            |

@mytag
Scenario: success edit project
	When I editting  follow this data
    | PropertyName | PropertyType | Content            | Street | Ward | District | Price   | Area  | BedRoom | BathRoom | PackingPlace |
	| Căn hộ Saigon Pearl   | 2            | View Đẹp và sang trọng | 750    | 3    | 3        | 50000  | 200m2 | 4       | 3        | 4            |
	Then After Edit I want see the data same this follow
	| PropertyName                                 | PropertyType | Content                                                                                                      | Street | Ward | District | Price  | Area  | BedRoom | BathRoom | PackingPlace |
	| Căn hộ Saigon Pearl                          | 2            | View Đẹp và sang trọng                                                                                       | 750    | 3    | 3        | 50000  | 200m2 | 4       | 3        | 4            |
	| ViLa Q7                                      | 2            | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.   | 750    | 3    | 2        | 70000  | 120m2 | 3       | 4        | 1            |
	| PIS Serviced Apartment – Style               | 3            | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..          | 749    | 4    | 2        | 30000  | 130m2 | 2       | 3        | 1            |
	| Vinhomes Central Park L2 – Duong’s Apartment | 2            | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. | 755    | 33   | 3        | 110000 | 150m2 | 4       | 2        | 1            |
	| Saigon Pearl Ruby Block                      | 1            | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | 758    | 35   | 3        | 30000  | 130m2 | 3       | 5        | 1            |
         
		 