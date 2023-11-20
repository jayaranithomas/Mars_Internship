Feature: This test suite contains scenarios for Profile Page Skills feature



Scenario Outline: A. Add New Skills

Given user selects the Skills tab
When user adds a new Skill <Skill> <Level>
Then Mars portal should save this Skill record <Skill>

	Examples: 
	| Skill				| Level            |
	| 'Programming'     | 'Beginner'       |
	| 'Drawing'			| 'Intermediate'   |
	| 'Painting'		| 'Expert'         |
	| 'Reading'			| 'Expert'         |
	| 'Writing'			| 'Beginner'       |



Scenario Outline: B. Adding Skills record without entering all the data

Given user selects the Skills tab
When user adds a new skill without entering all the data <Skill> <Level>
Then Mars portal should not save this Skill record

Examples: 
	| Skill				| Level            |
	| ''				| 'Beginner'       |
	| 'Singing'			| ''			   |
	| ''				| ''			   |

Scenario: C. Adding an existing Skill

Given user selects the Skills tab
When user tries to add an already exixting skill 'Drawing' 'Intermediate'
Then Mars portal should alert the user and should not save the skill record

Scenario: D. Adding Duplicate Skill

Given user selects the Skills tab
When user tries to add an already exixting skill with different level 'Drawing' 'Expert'
Then Mars portal should alert the user and should not save the duplicate skill record

Scenario: E. Adding a Skill with special characters and numbers

Given user selects the Skills tab
When user tries to add a skill with special characters and numbers '@$#%$%$$$3452345612534364566156634656' 'Beginner'
Then Mars portal should save the skill record '@$#%$%$$$3452345612534364566156634656'

Scenario: F. Cancel a Skill before Adding

Given user selects the Skills tab
When user tries to add a skills record but later Cancels it 'Dancing' 'Expert'
Then Mars portal should not save the cancelled skill 'Dancing'

Scenario Outline: G. Edit an existing Skill

Given user selects the Skills tab
When user edits an existing Skill <OldSkill> <OldLevel> <NewSkill> <NewLevel>
Then Mars portal should save the updated Skill record <NewSkill>

	Examples: 
	| OldSkill   | OldLevel   | NewSkill   | NewLevel       |
	| 'Painting' | 'Expert'   | 'Swimming' | 'Intermediate' |
	| 'Reading'  | 'Expert'   | 'Coding'   | 'Expert'       |
	| 'Writing'  | 'Beginner' | 'Writing'  | 'Intermediate' |

Scenario: H. Update a skills record without making any changes

Given user selects the Skills tab
When user tries to update a skills record without making any changes to it
Then Mars portal should not save the updated record

Scenario: I. Update a skills record without with the same skill but different level

Given user selects the Skills tab
When user tries to update a skills record without the same skill but different level 'Writing' 'Beginner'
Then Mars portal should save the updated skills record 'Writing'

Scenario: J. Cancel a skill without updating

Given user selects the Skills tab
When user tries to Cancel a skill without updating 'Racing' 'Intermediate'
Then Mars portal should not save the cancelled skill 'Racing'

Scenario: K. Delete a Skills record

Given user selects the Skills tab
When user tries to delete a skill record 'Writing'
Then Mars portal should alert the user that it has deleted the record 'Writing'