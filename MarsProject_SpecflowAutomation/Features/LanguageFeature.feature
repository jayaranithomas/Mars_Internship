Feature: This test suite contains scenarios for Profile Page Language feature

Scenario: A. Delete all the Existing Languages
	
	Given user selects language tab in the profile page
	When user deletes all the existing Language records
	Then Mars portal should not have any Language records

Scenario Outline: B. Add new Language
	
	Given user selects language tab in the profile page
	When user adds a new Language record <Language> <Level>
	Then Mars portal should save the new Language record <Language>

	Examples: 
	| Language	  | Level            |
	| 'Hindi'     | 'Basic'          |
	| 'Tamil'     | 'Conversational' |
	| 'English'   | 'Fluent'         |
	| 'Malayalam' | 'Native'         |

	Scenario Outline: C. Edit an Existing Language

	Given user selects language tab in the profile page
	When user edits an existing Language record <OldLanguage> <OldLevel> <NewLanguage> <NewLevel>
	Then Mars portal should save the updated Language record <NewLanguage> <NewLevel>
	
	Examples: 
	| OldLanguage | OldLevel         | NewLanguage | NewLevel         |
	| 'Hindi'     | 'Basic'          | 'German'    | 'Conversational' |
	| 'Tamil'     | 'Conversational' | 'Tamil'     | 'Basic'          |
	| 'English'   | 'Fluent'         | 'Spanish'   | 'Fluent'         |
	
	
	Scenario: D. Cancel a Language before Updating
	
	Given user selects language tab in the profile page
	When user tries to update a language record but later Cancels it 'Arabic' 'Basic'
	Then Mars portal should not update the changes 'Arabic' 'Basic'

	Scenario: E. Update a Language Record without making any Changes
	
	Given user selects language tab in the profile page
	When user tries to update a language record without making any changes to it
	Then Mars portal should alert the user and should not update the record

	Scenario: F. Update a Language Record with an already existing language but different level
	
	Given user selects language tab in the profile page
	When user tries to update a language record with an already existing language but different level 'Spanish' 'Basic'
	Then Mars portal should alert the user and should not update the record 'Spanish' 'Basic'


	Scenario: G. Cancel a Language before Adding
	
	Given user selects language tab in the profile page
	Given Mars portal should have only less than four languages
	When user tries to add a language record but later Cancels it 'Arabic' 'Basic'
	Then Mars portal should not save the cencelled record

	Scenario: H. Adding an Existing Language
	
	Given user selects language tab in the profile page
	Given Mars portal should have only less than four languages
	When user tries to add an already existing language record 'Malayalam' 'Native'
	Then Mars portal should alert the user and should not save the duplicate record

	Scenario: I. Adding the same Language with different Level
	
	Given user selects language tab in the profile page
	Given Mars portal should have only less than four languages
	When user tries to add an already existing language with different level 'Spanish' 'Basic'
	Then Mars portal should alert the user and should not save the record

	Scenario Outline: J. Add a new Language Record without entering all the data
	
	Given user selects language tab in the profile page
	Given Mars portal should have only less than four languages
	When user Adds a new Language record without entering all the data <Language> <Level>
	Then Mars portal should not save the new Language
	
	Examples: 
	| Language	  | Level      |
	| ''		  | 'Basic'    |
	| 'Tamil'     | ''		   |
	| ''		  | ''         |

	Scenario: K. Adding a new Language with invalid data
	
	Given user selects language tab in the profile page
	Given Mars portal should have only less than four languages
	When user tries to add a new language with invalid data 'BT1*&2345' 'Fluent'
	Then Mars portal should alert the user and should not save the invalid record

	Scenario: L. Adding 5th Language Record
	
	Given user selects language tab in the profile page
	When user tries to add the fifth language record 'Arabic' 'Basic'
	Then Mars portal should not allow the user to add that