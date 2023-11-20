using MarsProject_SpecflowAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject_SpecflowAutomation.Pages
{
    public class SkillsPage : CommonDriver
    {
        string Message;
        string compare;
        public void AddNewSkill(string skill, string level)
        {
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            //Wait for the table to be Visible
            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(3000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            //IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();

            IWebElement AddSkillTextBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            AddSkillTextBox.Click();
            AddSkillTextBox.SendKeys(skill);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            ChooseLevelDD.Click();


            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }
           

            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
            AddButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddNewSkill(string skill)
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();
            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            compare = skill + " has been added to your skills";

            //IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Message.Equals(compare))
            {
                Assert.Pass(Message);

            }

            Thread.Sleep(2000);
        }

        public void DeleteSkill(string skill)
        {
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
            DeleteButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertDeleteSkill(string skill) 
        {
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            compare = skill + " has been deleted";

            if (Message.Equals(compare))
            {
                Assert.Pass(Message);

            }

        }

        public void AddNewSkillWithoutData(string skill, string level)
        {
            //This fuction tries to add new skill record without entering all the data
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            //Wait for the table to be Visible
            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(3000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            AddNewButton.Click();

            if (!string.IsNullOrEmpty(skill))
            { 
                IWebElement AddSkillTextBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                AddSkillTextBox.Click();
                AddSkillTextBox.SendKeys(skill);
            }

            if (!string.IsNullOrEmpty(level))
            {
                IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
                ChooseLevelDD.Click();


                if (level.Equals("Beginner"))
                {
                    // Select Beginner Option from the Dropdown

                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                    levelOption.Click();
                }
                else if (level.Equals("Intermediate"))
                {
                    // Select Intermediate Option from the Dropdown
                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                    levelOption.Click();
                }
                else if (level.Equals("Expert"))
                {
                    // Select Expert Option from the Dropdown
                    IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                    levelOption.Click();
                }
            }

            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
            AddButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddNewSkillWithoutData()
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();
            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            compare = "Please enter skill and experience level";

            //IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Message.Equals(compare))
            {
                Assert.Pass(Message);

            }

            Thread.Sleep(2000);
        }

        public void AddExistingSkill(string skill, string level)
        {
            //This function tries to add an already existing <Skill,level> combination
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            //Wait for the table to be Visible
            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(3000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            AddNewButton.Click();

            IWebElement AddSkillTextBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            AddSkillTextBox.Click();
            AddSkillTextBox.SendKeys(skill);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            ChooseLevelDD.Click();


            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }


            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
            AddButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddExistingSkill()
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();
            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            compare = "This skill is already exist in your skill list.";

            //IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Message.Equals(compare))
            {
                Assert.Pass(Message);

            }

            Thread.Sleep(2000);
        }

        public void AddDuplicateSkill(string skill, string level)
        {
            //This function tries to add a duplicate skill but with different skill
            
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            //Wait for the table to be Visible
            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(3000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            AddNewButton.Click();

            IWebElement AddSkillTextBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            AddSkillTextBox.Click();
            AddSkillTextBox.SendKeys(skill);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            ChooseLevelDD.Click();


            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }


            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
            AddButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddDuplicateSkill()
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();
            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            compare = "Duplicated data";

            //IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Message.Equals(compare))
            {
                Assert.Pass(Message);

            }

            Thread.Sleep(2000);
        }

        public void AddNewSkillWithInvalidData(string skill, string level)
        {
            
            //This function tries to add a new skill with special characters and numbers
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            //Wait for the table to be Visible
            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(3000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            //IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();

            IWebElement AddSkillTextBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            AddSkillTextBox.Click();
            AddSkillTextBox.SendKeys(skill);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            ChooseLevelDD.Click();


            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }


            Thread.Sleep(2000);
            IWebElement AddButton = driver.FindElement(By.XPath("//span/input[1][@value='Add']"));
            AddButton.Click();

            Thread.Sleep(1000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;

        }

        public void AssertAddNewSkillWithInvalidData(string skill)
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();
            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            compare = skill + " has been added to your skills";

            //IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Message.Equals(compare))
            {
                Assert.Pass(Message);

            }

            Thread.Sleep(2000);
        }

        public void CancelAddNewSkill(string skill, string level)
        {

            //This function tries to Cancel a skills record without adding
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            //Wait for the table to be Visible
            //Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 2);
            Thread.Sleep(3000);

            IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class='ui teal button'][contains(text(),'Add New')]"));
            //IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();

            IWebElement AddSkillTextBox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            AddSkillTextBox.Click();
            AddSkillTextBox.SendKeys(skill);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//select[@name='level']/option[contains(text(),'Choose Skill Level')]"));
            ChooseLevelDD.Click();


            if (level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }


            Thread.Sleep(2000);
            IWebElement CancelButton = driver.FindElement(By.XPath("//span/input[2][@value='Cancel']"));
            CancelButton.Click();

            Thread.Sleep(1000);

        }

        public void AssertCancelSkill(string skill)
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();
            // Wait.WaitToBeVisible("XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            Thread.Sleep(2000);
            compare =skill + " has been cancelled";

            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='second']//table//tbody")).Count;
            int i, flag=0;

            for(i=1;i<=rowcount;i++)
            {
                IWebElement Skill = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody["+i+"]//td[1]"));
                if(Skill.Text.Equals(skill)) 
                {
                    flag = 1;
                    break;
                }

            }
            if (flag == 0)
            {
                Assert.Pass(compare);
            }


            Thread.Sleep(2000);
        }

        public void EditSkill(string OldSkill, string OldLevel, string NewSkill, string NewLevel)
        {
            //This function tries to Edit an existing skill
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();


            //Get the count of rows in the table
            int rowcount = driver.FindElements(By.XPath("//div[@data-tab='second']//table//tbody")).Count;

            for (int i = 1; i <= rowcount; i++)
            {
                //Select the language that need to be edited
                IWebElement Skill = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[" + i + "]//td[1]"));

                if (Skill.Text.Equals(OldSkill))
                {
                    IWebElement EditButton = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[" + i +"]//i[@class='outline write icon']"));
                    EditButton.Click();

                    IWebElement EditSkillTextBox = driver.FindElement(By.XPath(" //div[@data-tab='second']//table//tbody["+i+"]//input[@placeholder='Add Skill']"));
                    EditSkillTextBox.Click();

                    EditSkillTextBox.Clear();
                    EditSkillTextBox.SendKeys(NewSkill);

                    IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody["+i+"]//select[@name='level']"));
                    ChooseLevelDD.Click();

                    if (NewLevel.Equals("Beginner"))
                    {
                        // Select Beginner Option from the Dropdown

                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                        levelOption.Click();
                    }
                    else if (NewLevel.Equals("Intermediate"))
                    {
                        // Select Intermediate Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                        levelOption.Click();
                    }
                    else if (NewLevel.Equals("Expert"))
                    {
                        // Select Expert Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                        levelOption.Click();
                    }

                    Thread.Sleep(2000);

                    IWebElement UpdateButton = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody["+i+"]//span/input[1][@value='Update']"));
                    UpdateButton.Click();
                    break;
                }
            }
            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;
            

        }

        public void AssertEditSkill(string skill)
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            Thread.Sleep(2000);
            compare = skill + " has been updated to your skills";

            //IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Message.Equals(compare))
            {
                Assert.Pass(Message);

            }

            Thread.Sleep(2000);
        }

        public void UpdateSkillWithoutChanges()
        {
            //This function tries to updae an existing skill without making any changes to it

            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();



            //Select the language that need to be edited

            IWebElement EditButton = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[1]//i[@class='outline write icon']"));
            EditButton.Click();

            Thread.Sleep(2000);

            IWebElement UpdateButton = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[1]//span/input[1][@value='Update']"));
            UpdateButton.Click();

            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;


        }

        public void AssertUpdateSkillWithoutChanges()
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            Thread.Sleep(2000);

            compare = "This skill is already added to your skill list.";

            //IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Message.Equals(compare))
            {
                Assert.Pass(Message);

            }

            Thread.Sleep(2000);
        }

        public void UpdateWithDuplicateSkill(string Skill, string Level)
        {
            //This function tries to Edit an existing skill
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();


                    IWebElement EditButton = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[1]//i[@class='outline write icon']"));
                    EditButton.Click();

                    IWebElement EditSkillTextBox = driver.FindElement(By.XPath(" //div[@data-tab='second']//table//tbody[1]//input[@placeholder='Add Skill']"));
                    EditSkillTextBox.Click();

                    EditSkillTextBox.Clear();
                    EditSkillTextBox.SendKeys(Skill);

                    IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[1]//select[@name='level']"));
                    ChooseLevelDD.Click();

                    if (Level.Equals("Beginner"))
                    {
                        // Select Beginner Option from the Dropdown

                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                        levelOption.Click();
                    }
                    else if (Level.Equals("Intermediate"))
                    {
                        // Select Intermediate Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                        levelOption.Click();
                    }
                    else if (Level.Equals("Expert"))
                    {
                        // Select Expert Option from the Dropdown
                        IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                        levelOption.Click();
                    }

                    Thread.Sleep(2000);

                    IWebElement UpdateButton = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[1]//span/input[1][@value='Update']"));
                    UpdateButton.Click();
              
            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Message = messageBox.Text;


        }

        public void AssertUpdateWithDuplicateSkill(string skill)
        {
            //Verify if the new skill has been created Successfully
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();

            Thread.Sleep(2000);
            compare = skill + " has been updated to your skills";

            //IWebElement NewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Message.Equals(compare))
            {
                Assert.Pass(Message);

            }

            Thread.Sleep(2000);
        }

        public void CancelEditSkill(string Skill, string Level)
        {
            //This function tries to Edit an existing skill
            //Refresh the Profile Page 
            driver.Navigate().Refresh();

            IWebElement skillTab = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            skillTab.Click();


            IWebElement EditButton = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[1]//i[@class='outline write icon']"));
            EditButton.Click();

            IWebElement EditSkillTextBox = driver.FindElement(By.XPath(" //div[@data-tab='second']//table//tbody[1]//input[@placeholder='Add Skill']"));
            EditSkillTextBox.Click();

            EditSkillTextBox.Clear();
            EditSkillTextBox.SendKeys(Skill);

            IWebElement ChooseLevelDD = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[1]//select[@name='level']"));
            ChooseLevelDD.Click();

            if (Level.Equals("Beginner"))
            {
                // Select Beginner Option from the Dropdown

                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Beginner']"));
                levelOption.Click();
            }
            else if (Level.Equals("Intermediate"))
            {
                // Select Intermediate Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Intermediate']"));
                levelOption.Click();
            }
            else if (Level.Equals("Expert"))
            {
                // Select Expert Option from the Dropdown
                IWebElement levelOption = driver.FindElement(By.XPath("//option[@value='Expert']"));
                levelOption.Click();
            }

            Thread.Sleep(2000);

            IWebElement CancelButton = driver.FindElement(By.XPath("//div[@data-tab='second']//table//tbody[1]//span/input[2][@value='Cancel']"));
            CancelButton.Click();

        }

    }
}
