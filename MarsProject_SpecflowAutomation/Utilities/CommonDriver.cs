using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject_SpecflowAutomation.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;

        public void Initialize()
        {
            //Opening the Chrome driver
            driver = new ChromeDriver();
            //Maximizing the Window
            driver.Manage().Window.Maximize();
        }
        public void Close() 
        { 
            driver.Quit();
        }
    }
}
