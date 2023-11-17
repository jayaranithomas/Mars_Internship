using MarsProject_SpecflowAutomation.Pages;
using MarsProject_SpecflowAutomation.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsProject_SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinition:CommonDriver
    {
        LoginPage loginObj = new LoginPage();
        HomePage homeObj = new HomePage();
        ProfilePage profileObj = new ProfilePage();
        LanguagePage languageObj = new LanguagePage();

        [BeforeScenario]
        public void SetUp()
        {
           Initialize();
           homeObj.SignInAction();
           loginObj.LoginActions();
           profileObj.SelectLanguage();
        }


        [When(@"user adds a new Language record '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewLanguageRecord(string language, string level)
        {
            languageObj.AddLanguage(language, level);
        }


        [Then(@"Mars portal should save the new Language record '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheNewLanguageRecord(string language)
        {
            languageObj.AssertAddNewLanguage(language);
        }

        [When(@"user edits an existing Language record '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingLanguageRecord(string OldLan, string OldLevel, string NewLan, string NewLevel)
        {
            languageObj.EditLanguage(OldLan, OldLevel, NewLan, NewLevel);
        }

        [Then(@"Mars portal should save the updated Language record '([^']*)' '([^']*)'")]
        public void ThenMarsPortalShouldSaveTheUpdatedLanguageRecord(string NewLan, string NewLevel)
        {
            languageObj.AssertEditLanguage(NewLan, NewLevel);
        }

        [When(@"user deletes all the existing Language records")]
        public void WhenUserDeletesAllTheExistingLanguageRecords()
        {
            languageObj.DeleteLanguage();
        }

        [Then(@"Mars portal should not have any Language records")]
        public void ThenMarsPortalShouldNotHaveAnyLanguageRecords()
        {
            languageObj.AssertDeleteLanguage();   
        }

        [When(@"user tries to add the fifth language record '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddTheFifthLanguageRecord(string lan, string level)
        {
            languageObj.AddFifthLanguage(lan,level);
        }

        [Then(@"Mars portal should not allow the user to add that")]
        public void ThenMarsPortalShouldNotAllowTheUserToAddThat()
        {
            languageObj.AssertAddFifthLanguage();
        }
        [Given(@"Mars portal should have only less than four languages")]
        public void GivenMarsPortalShouldHaveOnlyLessThanFourLanguages()
        {
            languageObj.DeleteOneLanguage();
        }

        [When(@"user tries to add a language record but later Cancels it '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddALanguageRecordButLaterCancelsIt(string lan, string level)
        {
            languageObj.CancelAddLanguage(lan,level);
        }

        [Then(@"Mars portal should not save the cencelled record")]
        public void ThenMarsPortalShouldNotSaveTheCencelledRecord()
        {
            languageObj.AssertCancelAddLanguage();
        }

        [When(@"user tries to update a language record but later Cancels it '([^']*)' '([^']*)'")]
        public void WhenUserTriesToUpdateALanguageRecordButLaterCancelsIt(string lan, string level)
        {
            languageObj.CancelEditLanguage(lan,level);
        }


        [Then(@"Mars portal should not update the changes '([^']*)' '([^']*)'")]
        public void ThenMarsPortalShouldNotUpdateTheChanges(string lan, string level)
        {
            languageObj.AssertCancelEditLanguage(lan, level);
        }

        [When(@"user tries to update a language record without making any changes to it")]
        public void WhenUserTriesToUpdateALanguageRecordWithoutMakingAnyChangesToIt()
        {
            languageObj.NoChangeUpdateLanguage();   
        }

        [Then(@"Mars portal should alert the user and should not update the record")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotUpdateTheRecord()
        {
            languageObj.AssertNoChangeUpdateLanguage();
        }

        [When(@"user tries to add an already existing language record '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddAnAlreadyExistingLanguageRecord(string lan, string level)
        {
            languageObj.AddExistingLanguage(lan,level);
        }

        [Then(@"Mars portal should alert the user and should not save the duplicate record")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveTheDuplicateRecord()
        {
            languageObj.AssertAddExistingLanguage();
        }

        [When(@"user tries to add an already existing language with different level '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddAnAlreadyExistingLanguageWithDifferentLevel(string lan, string level)
        {
            languageObj.AddDuplicateLanguage(lan,level);
        }

        [Then(@"Mars portal should alert the user and should not save the record")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveTheRecord()
        {
            languageObj.AssertAddDuplicateLanguage();
        }

        [When(@"user Adds a new Language record without entering all the data '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewLanguageRecordWithoutEnteringAllTheData(string lan, string level)
        {
            languageObj.AddLanguageWithoutData(lan,level);
        }

        [Then(@"Mars portal should not save the new Language")]
        public void ThenMarsPortalShouldNotSaveTheNewLanguage()
        {
            languageObj.AssertAddLanguageWithoutData();
        }

        [When(@"user tries to add a new language with invalid data '([^']*)' '([^']*)'")]
        public void WhenUserTriesToAddANewLanguageWithInvalidData(string lan, string level)
        {
            languageObj.AddLanguageInvalidData(lan,level);
        }

        [Then(@"Mars portal should alert the user and should not save the invalid record")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotSaveTheInvalidRecord()
        {
            languageObj.AssertAddLanguageInvalidData();
        }

        [When(@"user tries to update a language record with an already existing language but different level '([^']*)' '([^']*)'")]
        public void WhenUserTriesToUpdateALanguageRecordWithAnAlreadyExistingLanguageButDifferentLevel(string lan, string level)
        {
            languageObj.UpdateWithExistingLanguage(lan,level);
        }

        [Then(@"Mars portal should alert the user and should not update the record '([^']*)' '([^']*)'")]
        public void ThenMarsPortalShouldAlertTheUserAndShouldNotUpdateTheRecord(string lan, string level)
        {
            languageObj.AssertUpdateWithExistingLanguage(lan,level);
        }



        [AfterScenario]
        public void QuitDriver()
        {
            Close();
        }
    }
}
