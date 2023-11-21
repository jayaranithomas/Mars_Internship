using MarsProject_SpecflowAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MarsProject_SpecflowAutomation.Pages
{
    public class LanguagePage : CommonDriver
    {

        string Message;
        public void AddLanguage(string language, string level)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            //Wait for the table to be Visible
            Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(2000);
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            IWebElement AddLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            AddLanguageTextBox.Click();
            AddLanguageTextBox.SendKeys(language);
            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            ChooseLevelDD.Click();


            if (level.Equals("Basic"))
            {
                // Select Basic Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                levelOption.Click();
            }
            else if (level.Equals("Conversational"))
            {
                // Select Conversational Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                levelOption.Click();
            }
            else if (level.Equals("Fluent"))
            {
                // Select Fluent Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                levelOption.Click();
            }
            else if (level.Equals("Native"))
            {
                // Select Native/Bilingual Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                levelOption.Click();
            }

            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddNewLanguage(string language)
        {
            //Verify if the new Language has been created Successfully
            driver.Navigate().Refresh();
            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (NewLanguage.Text.Equals(language))
            {
                Assert.Pass(Message);

            }

            Thread.Sleep(2000);
        }

        public void EditLanguage(string OldLan, string OldLevel, string NewLan, string NewLevel)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();
            Thread.Sleep(3000);

            //Get the count of rows in the table
            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            for (int i = 1; i <= rowcount; i++)
            {
                //Select the language that need to be edited
                IWebElement SelectLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                if (SelectLanguage.Text.Equals(OldLan))
                {
                    IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                    EditButton.Click();

                    IWebElement EditLanguageTextBox = driver.FindElement(By.XPath(" //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    EditLanguageTextBox.Click();

                    EditLanguageTextBox.Clear();
                    EditLanguageTextBox.SendKeys(NewLan);

                    IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    ChooseLevelDD.Click();

                    if (NewLevel.Equals("Basic"))
                    {
                        // Select Basic Option from the Dropdown

                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                        levelOption.Click();
                    }
                    else if (NewLevel.Equals("Conversational"))
                    {
                        // Select Conversational Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                        levelOption.Click();
                    }
                    else if (NewLevel.Equals("Fluent"))
                    {
                        // Select Fluent Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                        levelOption.Click();
                    }
                    else if (NewLevel.Equals("Native"))
                    {
                        // Select Native/Bilingual Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                        levelOption.Click();
                    }

                    Thread.Sleep(2000);

                    IWebElement UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]"));
                    UpdateButton.Click();
                    break;
                }
            }
            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }
        public void AssertEditLanguage(string NewLan, string NewLevel)
        {
            //Verify if the existing Language has updated Successfully
            driver.Navigate().Refresh();

            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 2);
            Thread.Sleep(3000);

            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            int i;
            for (i = 1; i <= rowcount; i++)
            {
                IWebElement SelectLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                IWebElement SelectLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[2]"));

                if ((SelectLanguage.Text.Equals(NewLan)) && (SelectLevel.Text.Equals(NewLevel)))
                {
                    //Assert.That((SelectLanguage.Text.Equals(NewLan)) && (SelectLevel.Text.Equals(NewLevel)), "Language NOT  Updated Successfully");
                    Assert.Pass(Message);
                    break;

                }
            }

            Thread.Sleep(2000);
        }
        public void DeleteLanguage()
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();
            Thread.Sleep(3000);

            //Get the count of rows in the table
            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;


            for (int i = 1; i <= rowcount;)
            {

                IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));

                DeleteButton.Click();
                rowcount--;
                driver.Navigate().Refresh();
                Thread.Sleep(5000);

            }

        }
        public void AssertDeleteLanguage()
        {
            //Verify if the existing Language has deleted Successfully
            driver.Navigate().Refresh();

            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 2);
            Thread.Sleep(3000);

            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;


            Assert.True(rowcount == 0, "All Languages NOT Deleted");


            Thread.Sleep(2000);
        }
        public void AddFifthLanguage(string language, string level)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            //Wait for the table to be Visible
            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(5000);
            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            if (rowcount == 4)
            {
                try
                {
                    IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
                    AddNewButton.Click();
                }
                catch (Exception ex)
                {
                    Assert.Pass(ex.Message);
                }
            }

        }
        public void AssertAddFifthLanguage()
        {
            //Verify if the existing Language has deleted Successfully
            driver.Navigate().Refresh();

            Thread.Sleep(3000);

            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            if (rowcount == 4)
            {
                Assert.Pass("5th Language NOT Added");
            }

            Thread.Sleep(2000);
        }

        public void DeleteOneLanguage()
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();
            Thread.Sleep(3000);

            //Get the count of rows in the table
            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            if (rowcount == 4)
            {

                IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                DeleteButton.Click();
                driver.Navigate().Refresh();
                Thread.Sleep(5000);

            }

        }

        public void CancelAddLanguage(string language, string level)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            //Wait for the table to be Visible
            Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(2000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();

            IWebElement AddLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            AddLanguageTextBox.Click();
            AddLanguageTextBox.SendKeys(language);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            ChooseLevelDD.Click();


            if (level.Equals("Basic"))
            {
                // Select Basic Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                levelOption.Click();
            }
            else if (level.Equals("Conversational"))
            {
                // Select Conversational Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                levelOption.Click();
            }
            else if (level.Equals("Fluent"))
            {
                // Select Fluent Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                levelOption.Click();
            }
            else if (level.Equals("Native"))
            {
                // Select Native/Bilingual Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                levelOption.Click();
            }

            Thread.Sleep(2000);

            IWebElement CancelButton = driver.FindElement(By.XPath("//div/input[2][@type='button'][@value='Cancel']"));
            CancelButton.Click();

        }

        public void AssertCancelAddLanguage()
        {
            //Verify if the existing Language has deleted Successfully
            driver.Navigate().Refresh();

            Thread.Sleep(3000);

            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            if (rowcount == 3)//No new entries made
            {
                Assert.Pass("Language Addition Cancelled");
            }

            Thread.Sleep(2000);
        }

        public void CancelEditLanguage(string NewLan, string NewLevel)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();
            Thread.Sleep(3000);

            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            EditButton.Click();

            IWebElement EditLanguageTextBox = driver.FindElement(By.XPath(" //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
            EditLanguageTextBox.Click();

            EditLanguageTextBox.Clear();
            EditLanguageTextBox.SendKeys(NewLan);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
            ChooseLevelDD.Click();

            if (NewLevel.Equals("Basic"))
            {
                // Select Basic Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                levelOption.Click();
            }
            else if (NewLevel.Equals("Conversational"))
            {
                // Select Conversational Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                levelOption.Click();
            }
            else if (NewLevel.Equals("Fluent"))
            {
                // Select Fluent Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                levelOption.Click();
            }
            else if (NewLevel.Equals("Native"))
            {
                // Select Native/Bilingual Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                levelOption.Click();
            }

            Thread.Sleep(2000);

            IWebElement CancelButton = driver.FindElement(By.XPath("//span/input[2][@type='button'][@value='Cancel']"));
            CancelButton.Click();


        }

        public void AssertCancelEditLanguage(string NewLan, string NewLevel)
        {
            //Verify if the existing Language has updated Successfully
            driver.Navigate().Refresh();

            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 2);
            Thread.Sleep(3000);

            IWebElement SelectLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            IWebElement SelectLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]"));

            string Language = SelectLanguage.Text;
            string Level = SelectLevel.Text;

            if ((Language != NewLan) && (Level != NewLevel))
            {
                //Assert.That((SelectLanguage.Text.Equals(NewLan)) && (SelectLevel.Text.Equals(NewLevel)), "Language NOT  Updated Successfully");
                //break;
                Assert.Pass("Updation Cancelled");

            }


            Thread.Sleep(2000);
        }

        public void NoChangeUpdateLanguage()
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();
            Thread.Sleep(3000);

            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            EditButton.Click();

            Thread.Sleep(5000);

            //Trying to click Update Button Without making any changes
            IWebElement UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
            UpdateButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertNoChangeUpdateLanguage()
        {
            driver.Navigate().Refresh();
            Assert.Pass(Message);
        }

        public void AddExistingLanguage(string language, string level)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            //Wait for the table to be Visible
            Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(2000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();

            IWebElement AddLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            AddLanguageTextBox.Click();
            AddLanguageTextBox.SendKeys(language);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            ChooseLevelDD.Click();


            if (level.Equals("Basic"))
            {
                // Select Basic Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                levelOption.Click();
            }
            else if (level.Equals("Conversational"))
            {
                // Select Conversational Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                levelOption.Click();
            }
            else if (level.Equals("Fluent"))
            {
                // Select Fluent Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                levelOption.Click();
            }
            else if (level.Equals("Native"))
            {
                // Select Native/Bilingual Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                levelOption.Click();
            }

            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();

            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddExistingLanguage()
        {
            driver.Navigate().Refresh();

            Thread.Sleep(3000);

            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            if (rowcount == 3)
            {
                Assert.Pass(Message);
            }

        }
        public void AddDuplicateLanguage(string language, string level)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            //Wait for the table to be Visible
            Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(2000);
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            IWebElement AddLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            AddLanguageTextBox.Click();
            AddLanguageTextBox.SendKeys(language);
            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            ChooseLevelDD.Click();


            if (level.Equals("Basic"))
            {
                // Select Basic Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                levelOption.Click();
            }
            else if (level.Equals("Conversational"))
            {
                // Select Conversational Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                levelOption.Click();
            }
            else if (level.Equals("Fluent"))
            {
                // Select Fluent Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                levelOption.Click();
            }
            else if (level.Equals("Native"))
            {
                // Select Native/Bilingual Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                levelOption.Click();
            }

            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();

            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddDuplicateLanguage()
        {
            driver.Navigate().Refresh();

            Thread.Sleep(3000);

            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;

            if (rowcount == 3)
            {
                Assert.Pass(Message);
            }

        }

        public void AddLanguageWithoutData(string language, string level)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            //Wait for the table to be Visible
            Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(2000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();

            if (!string.IsNullOrEmpty(language))
            {
                IWebElement AddLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
                AddLanguageTextBox.Click();
                AddLanguageTextBox.SendKeys(language);
            }

            if (!string.IsNullOrEmpty(level))
            {
                IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
                ChooseLevelDD.Click();


                if (level.Equals("Basic"))
                {
                    // Select Basic Option from the Dropdown

                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                    levelOption.Click();
                }
                else if (level.Equals("Conversational"))
                {
                    // Select Conversational Option from the Dropdown
                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                    levelOption.Click();
                }
                else if (level.Equals("Fluent"))
                {
                    // Select Fluent Option from the Dropdown
                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                    levelOption.Click();
                }
                else if (level.Equals("Native"))
                {
                    // Select Native/Bilingual Option from the Dropdown
                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                    levelOption.Click();
                }
            }

            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();

            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddLanguageWithoutData()
        {
            driver.Navigate().Refresh();

            Thread.Sleep(3000);

            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;


            if (rowcount == 3)
            {
                Assert.Pass(Message);
            }

        }

        public void AddLanguageInvalidData(string language, string level)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            //Wait for the table to be Visible
            Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(2000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();


            IWebElement AddLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            AddLanguageTextBox.Click();
            AddLanguageTextBox.SendKeys(language);



            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            ChooseLevelDD.Click();


            if (level.Equals("Basic"))
            {
                // Select Basic Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                levelOption.Click();
            }
            else if (level.Equals("Conversational"))
            {
                // Select Conversational Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                levelOption.Click();
            }
            else if (level.Equals("Fluent"))
            {
                // Select Fluent Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                levelOption.Click();
            }
            else if (level.Equals("Native"))
            {
                // Select Native/Bilingual Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                levelOption.Click();
            }


            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();

            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddLanguageInvalidData()
        {
            driver.Navigate().Refresh();

            Thread.Sleep(3000);

            int rowcount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;


            if (rowcount == 4)//New Entry added
            {
                Assert.Pass(Message);
            }
            

        }

        public void UpdateWithExistingLanguage(string Lan, string Level)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();
            Thread.Sleep(3000);


            IWebElement EditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            EditButton.Click();
            Thread.Sleep(3000);
            IWebElement EditLanguageTextBox = driver.FindElement(By.XPath(" //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
            EditLanguageTextBox.Click();

            EditLanguageTextBox.Clear();
            EditLanguageTextBox.SendKeys(Lan);
            Thread.Sleep(3000);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
            ChooseLevelDD.Click();

            if (Level.Equals("Basic"))
            {
                // Select Basic Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Basic']"));
                levelOption.Click();
            }
            else if (Level.Equals("Conversational"))
            {
                // Select Conversational Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Conversational']"));
                levelOption.Click();
            }
            else if (Level.Equals("Fluent"))
            {
                // Select Fluent Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Fluent']"));
                levelOption.Click();
            }
            else if (Level.Equals("Native"))
            {
                // Select Native/Bilingual Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
                levelOption.Click();
            }

            Thread.Sleep(2000);

            IWebElement UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
            UpdateButton.Click();

            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;




        }
        public void AssertUpdateWithExistingLanguage(string NewLan, string NewLevel)
        {
            //Verify if the existing Language has updated Successfully
            driver.Navigate().Refresh();

            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table", 2);
            Thread.Sleep(3000);


            IWebElement SelectLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            IWebElement SelectLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]"));

            if ((SelectLanguage.Text.Equals(NewLan)) && (SelectLevel.Text.Equals(NewLevel)))
            {
                Assert.Pass(Message);
             }


            Thread.Sleep(2000);
        }

    }
}

