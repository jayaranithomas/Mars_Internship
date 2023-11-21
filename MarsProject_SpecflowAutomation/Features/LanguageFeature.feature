Feature: This test suite contains scenarios for Profile Page Language feature



Scenario: A. Delete all the Existing Languages
	
	When user deletes all the existing Language records
	Then Mars portal should not have any Language records



Scenario Outline: B. Add new Language
	
	When user adds a new Language record <Language> <Level>
	Then Mars portal should save the new Language record <Language>

	Examples: 
	| Language	  | Level            |
	| 'Hindi'     | 'Basic'          |
	| 'Tamil'     | 'Conversational' |
	| 'English'   | 'Fluent'         |
	| 'Malayalam' | 'Native'         |


	Scenario: C. Adding an Existing Language
	
	Given Mars portal should have only less than four languages
	When user tries to add an already existing language record 'Malayalam' 'Native'
	Then Mars portal should alert the user and should not save the duplicate record


	Scenario: D. Adding the same Language with different Level
	
	Given Mars portal should have only less than four languages
	When user tries to add an already existing language with different level 'Tamil' 'Basic'
	Then Mars portal should alert the user and should not save the record


	Scenario Outline: E. Add a new Language Record without entering all the data
	
	Given Mars portal should have only less than four languages
	When user Adds a new Language record without entering all the data <Language> <Level>
	Then Mars portal should not save the new Language
	
	Examples: 
	| Language	  | Level      |
	| ''		  | 'Basic'    |
	| 'Spanish'   | ''		   |
	| ''		  | ''         |

	Scenario: F. Adding a new Language with special characters and numbers
	
	Given Mars portal should have only less than four languages
	When user tries to add a new language with special characters and numbers 'B@W%$ERERTRER%$%$##@$#@$%%^%$&^%&^%$^&%$^%$*&^&^^%$#%$$#@@@!!@@$#%^&^*&&*&^&^&%^%$%$#$#@$#@$#@#@%$#$@#@$#@#@!#@@$#@$#$#@@$#%$#@$#%$##################@#!)()(_(^*^%&$^$%##@#$@#@$^%*&^*&(*)(**(&*%$$$%&*^(*)(()&*%%$$$#%$&^^*&*(&*&^&$&^%^%$^########$##@#%$^&%^^&$%^$#%#$%T1*&234572635472634576349534769345973695364598763475873465734657164' 'Fluent'
	Then Mars portal should alert the user and save the record


	Scenario: G. Adding 5th Language Record
	
	When user tries to add the fifth language record 'Arabic' 'Basic'
	Then Mars portal should not allow the user to add that

	
	Scenario Outline: H. Edit an Existing Language

	When user edits an existing Language record <OldLanguage> <OldLevel> <NewLanguage> <NewLevel>
	Then Mars portal should save the updated Language record <NewLanguage> <NewLevel>
	
	Examples: 
	| OldLanguage | OldLevel         | NewLanguage | NewLevel         |
	| 'Tamil'     | 'Conversational' | 'German'    | 'Basic'		  |
	| 'Malayalam' | 'Native'         | 'Malayalam' | 'Basic'          |
	| 'English'   | 'Fluent'         | 'Spanish'   | 'Fluent'         |	
	
	

	Scenario: I. Update a Language Record without making any Changes
	
	When user tries to update a language record without making any changes to it
	Then Mars portal should alert the user and should not update the record

	Scenario: J. Update a Language Record with an already existing language but different level
	
	When user tries to update a language record with an already existing language but different level 'Spanish' 'Fluent'
	Then Mars portal should alert the user and should update the record 'Spanish' 'Fluent'

	Scenario: K. Cancel a Language before Updating
	
	When user tries to update a language record but later Cancels it 'Arabic' 'Basic'
	Then Mars portal should not update the changes 'Arabic' 'Basic'

	Scenario: L. Cancel a Language before Adding
	
	Given Mars portal should have only less than four languages
	When user tries to add a language record but later Cancels it 'Arabic' 'Basic'
	Then Mars portal should not save the cancelled record


	

	

	

	

	