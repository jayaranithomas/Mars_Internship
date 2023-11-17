using System;
using TechTalk.SpecFlow;
using MarsProject_SpecflowAutomation.Utilities;
using MarsProject_SpecflowAutomation.Pages;

namespace MarsProject_SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinition:CommonDriver
    {

        LoginPage loginObj = new LoginPage();
        HomePage homeObj = new HomePage();
        ProfilePage profileObj = new ProfilePage();
        SkillsPage skillObj = new SkillsPage();

        [BeforeScenario]
        public void SetUp()
        {
            Initialize();
            homeObj.SignInAction();
            loginObj.LoginActions();
            profileObj.SelectSkill();
        }




        [When(@"user deletes all the existing Skills records")]
        public void WhenUserDeletesAllTheExistingSkillsRecords()
        {
            throw new PendingStepException();
        }

        [Then(@"Mars portal should not have any Skills records")]
        public void ThenMarsPortalShouldNotHaveAnySkillsRecords()
        {
            throw new PendingStepException();
        }

        [When(@"user adds a new Skill record '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewSkillRecord(string programming, string beginner)
        {
            throw new PendingStepException();
        }

        [Then(@"Mars portal should save the new Skill record '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheNewSkillRecord(string programming)
        {
            throw new PendingStepException();
        }

        [When(@"user edits an existing Skill record '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingSkillRecord(string programming, string beginner, string writing, string intermediate)
        {
            throw new PendingStepException();
        }

        [Then(@"Mars portal should save the updated Skill record '([^']*)' '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheUpdatedSkillRecord(string writing, string intermediate)
        {
            throw new PendingStepException();
        }
    }
}
