Feature: This test suite contains scenarios for Profile Page Skills feature

Scenario: A. Delete all the Existing Skills
	
	When user deletes all the existing Skills records
	Then Mars portal should not have any Skills records

Scenario Outline: B. Add new Skills
	
	When user adds a new Skill record <Skill> <Level>
	Then Mars portal should save the new Skill record <Skill>

	Examples: 
	| Skill				| Level            |
	| 'Programming'     | 'Beginner'       |
	| 'Drawing'			| 'Intermediate'   |
	| 'Painting'		| 'Expert'         |

	Scenario Outline: C. Edit an Existing Skill
	
	When user edits an existing Skill record <OldSkill> <OldLevel> <NewSkill> <NewLevel>
	Then Mars portal should save the updated Skill record <NewSkill> <NewLevel>
	
	Examples: 
	| OldSkill		| OldLevel			  | NewSkill   | NewLevel       |
	| 'Programming' | 'Beginner'          | 'Writing'  | 'Intermediate' |
	| 'Drawing'     | 'Intermediate'      | 'Drawing'  | 'Beginner'     |
	| 'Painting'    | 'Expert'            | 'Reading'  | 'Expert'       |
	
	
#	Scenario: D. Cancel a Skill before Updating
#	
#	When user tries to update a Skill record but later Cancels it 'Programming' 'Beginner'
#	Then Mars portal should not update the changes 'Programming' 'Beginner'
#
#	Scenario: E. Update a Skills Record without making any Changes
#	
#	When user tries to update a Skils record without making any changes to it
#	Then Mars portal should alert the user and should not update the record
#
#	Scenario: F. Update a Skills Record with an already existing skill but different level
#	
#	When user tries to update a Skills record with an already existing skill but different level 'Spanish' 'Basic'
#	Then Mars portal should alert the user and should not update the record 'Reading' 'Basic'
#
#
#	Scenario: G. Cancel a Skills before Adding
#	
#	When user tries to add a Skills record but later Cancels it 'Reading' 'Expert'
#	Then Mars portal should not save the cencelled record
#
#	Scenario: H. Adding a Existing Skill
#	
#	When user tries to add an already existing skill record 'Reading' 'Expert'
#	Then Mars portal should alert the user and should not save the duplicate record
#
#	Scenario: I. Adding the same Skill with different Level
#	
#	When user tries to add an already existing skill with different level 'Reading' 'Intermediate'
#	Then Mars portal should alert the user and should not save the record
#
#	Scenario Outline: J. Add a new Skill Record without entering all the data
#	
#	When user Adds a new Skill record without entering all the data <Skill> <Level>
#	Then Mars portal should not save the new Skill
#	
#	Examples: 
#	| Skill		  | Level      |
#	| ''		  | 'Beginner' |
#	| 'Designing' | ''		   |
#	| ''		  | ''         |
#
#	Scenario: K. Adding a new Skill with invalid data
#	
#	When user tries to add a new skill with invalid data ')(*&%T1*&2345' 'Beginner'
#	Then Mars portal should alert the user and should not save the invalid record
