using MarsProject_SpecflowAutomation.Pages;
using MarsProject_SpecflowAutomation.Utilities;
using System;
using TechTalk.SpecFlow;

namespace MarsProject_SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinition : CommonDriver
    {
       
        ProfilePage ProfileObj = new ProfilePage();
        SkillsPage SkillsObj = new SkillsPage();

        [Given(@"user selects the Skills tab")]
        public void GivenUserSelectsTheSkillsTab()
        {
            ProfileObj.SelectSkill();
        }


        [When(@"user adds a new Skill '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewSkill(string skill, string level)
        {
            SkillsObj.AddNewSkill(skill, level);
        }

        [Then(@"Mars portal should save this Skill record '([^']*)'")]
        public void ThenMarsPortalShouldSaveThisSkillRecord(string skill)
        {
            SkillsObj.AssertAddNewSkill(skill);
        }

        [When(@"user tries to delete a skill record '([^']*)'")]
        public void WhenUserTriesToDeleteASkillRecord(string skill)
        {
            SkillsObj.DeleteSkill(skill);
        }

       
        [Then(@"Mars portal should alert the user that it has deleted the record '([^']*)'")]
        public void ThenMarsPortalShouldAlertTheUserThatItHasDeletedTheRecord(string skill)
        {
            SkillsObj.AssertDeleteSkill(skill);
        }

        [When(@"user adds a new skill without entering all the data '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewSkillWithoutEnteringAllTheData(string skill, string level)
        {
            SkillsObj.AddNewSkillWithoutData(skill,level);
        }

        [Then(@"Mars portal should not save this Skill record")]
        public void ThenMarsPortalShouldNotSaveThisSkillRecord()
        {
            SkillsObj.AssertAddNewSkillWithoutData();
        }

        [When(@"user tries to add an already exixting skill '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddAnAlreadyExixtingSkill(string skill, string level)
        {
            SkillsObj.AddExistingSkill(skill,level);    
        }

        [Then(@"Mars portal should alert the user and should not save the skill record")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveTheSkillRecord()
        {
            SkillsObj.AssertAddExistingSkill();
        }

        [When(@"user tries to add an already exixting skill with different level '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddAnAlreadyExixtingSkillWithDifferentLevel(string skill, string level)
        {
            SkillsObj.AddDuplicateSkill(skill,level);
        }

        [Then(@"Mars portal should alert the user and should not save the duplicate skill record")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveTheDuplicateSkillRecord()
        {
            SkillsObj.AssertAddDuplicateSkill();
        }

        [When(@"user tries to add a skill with special characters and numbers '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddASkillWithSpecialCharactersAndNumbers(string skill, string level)
        {
            SkillsObj.AddNewSkillWithInvalidData(skill,level);
        }

        [Then(@"Mars portal should save the skill record '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheSkillRecord(string skill)
        {
            SkillsObj.AssertAddNewSkillWithInvalidData(skill);
        }

        [When(@"user tries to add a skills record but later Cancels it '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddASkillsRecordButLaterCancelsIt(string skill, string level)
        {
            SkillsObj.CancelAddNewSkill(skill,level);
        }

        [Then(@"Mars portal should not save the cancelled skill '([^']*)'")]
        public void ThenMarsPortalShouldNotSaveTheCancelledSkill(string skill)
        {
            SkillsObj.AssertCancelSkill(skill);
        }

        [When(@"user edits an existing Skill '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingSkill(string oldskill, string oldlevel, string newskill, string newlevel)
        {
            SkillsObj.EditSkill(oldskill, oldlevel, newskill, newlevel);
        }

        [Then(@"Mars portal should save the updated Skill record '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheUpdatedSkillRecord(string newskill)
        {
            SkillsObj.AssertEditSkill(newskill);
        }

        [When(@"user tries to update a skills record without making any changes to it")]
        public void WhenUserTriesToUpdateASkillsRecordWithoutMakingAnyChangesToIt()
        {
            SkillsObj.UpdateSkillWithoutChanges();
        }

        [Then(@"Mars portal should not save the updated record")]
        public void ThenMarsPortalShouldNotSaveTheUpdatedRecord()
        {
            SkillsObj.AssertUpdateSkillWithoutChanges();
        }

        [When(@"user tries to update a skills record without the same skill but different level '([^']*)' '([^']*)'")]
        public void WhenUserTriesToUpdateASkillsRecordWithoutTheSameSkillButDifferentLevel(string skill, string level)
        {
            SkillsObj.UpdateWithDuplicateSkill(skill, level);
        }

        [Then(@"Mars portal should save the updated skills record '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheUpdatedSkillsRecord(string skill)
        {
            SkillsObj.AssertUpdateWithDuplicateSkill(skill);
        }

        [When(@"user tries to Cancel a skill without updating '([^']*)' '([^']*)'")]
        public void WhenUserTriesToCancelASkillWithoutUpdating(string skill, string racing)
        {
            SkillsObj.CancelEditSkill(skill, racing);
        }


    }
}
