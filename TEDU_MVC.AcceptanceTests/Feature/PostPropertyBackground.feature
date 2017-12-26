@automated
Feature: PostPropertyBackground
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
	Given the following property
	| PropertyName                   | Content                                                 | Price| PropertyType	| District   | UserID   | StatusID |
	| Gojko Adzic                    | Specification By Example                                | 1200 | 1				| 2		     | 1		| 3 |
	| Eckhart Tolle                  | The Power of Now                                        | 1200 | 2				| 3          | 12       | 3 |
	| Jeff Sutherland                | Scrum: The Art of Doing Twice the Work in Half the Time | 1600 | 3				| 4          | 1		| 3 |
	| Mitch Lacey                    | The Scrum Field Guide                                   | 1500 | 4				| 3          | 12       | 3 |
	| Martin Fowler                  | Analysis Patterns                                       | 5000 | 1				| 2          | 1	    | 3 |
	| Eric Evans                     | Domain Driven Design                                    | 4600 | 2				| 4          | 12       | 3 |
	| Ted Pattison                   | Inside Windows SharePoint Services                      | 3100 | 3				| 3          | 1		| 3 |
	| Lisa Crispin and Janet Gregory | Agile Testing                                           | 2000 | 4				| 2          | 12       | 3 |
    | Esther Derby and Diana Larsen  | Agile Retrospectives                                    | 1600 | 1				| 4          | 1	    | 3 |


Scenario: Successfull Creating New Property
	When I input the following information
	| PropertyName        | Content | Price | PropertyType | District | UserID | StatusID |
	| New Create Property | Example | 1200  | 1            | 2        | 1      | 3        |
	Then the list of books should update
	| PropertyName                   | Content                                                 | Price| PropertyType	| District   | UserID   | StatusID |
	| Gojko Adzic                    | Specification By Example                                | 1200 | 1				| 2		     | 1		| 3 |
	| Eckhart Tolle                  | The Power of Now                                        | 1200 | 2				| 3          | 12       | 3 |
	| Jeff Sutherland                | Scrum: The Art of Doing Twice the Work in Half the Time | 1600 | 3				| 4          | 1		| 3 |
	| Mitch Lacey                    | The Scrum Field Guide                                   | 1500 | 4				| 3          | 12       | 3 |
	| Martin Fowler                  | Analysis Patterns                                       | 5000 | 1				| 2          | 1	    | 3 |
	| Eric Evans                     | Domain Driven Design                                    | 4600 | 2				| 4          | 12       | 3 |
	| Ted Pattison                   | Inside Windows SharePoint Services                      | 3100 | 3				| 3          | 1		| 3 |
	| Lisa Crispin and Janet Gregory | Agile Testing                                           | 2000 | 4				| 2          | 12       | 3 |
    | Esther Derby and Diana Larsen  | Agile Retrospectives                                    | 1600 | 1				| 4          | 1	    | 3 |
	| New Create Property			 | Example                                                 | 1200 | 1               | 2          | 1        | 3 |