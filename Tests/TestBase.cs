using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Framework.Pages;
using QA_Framework.Pages.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup() 
        {
            DriverManager driverManager = new DriverManager("chrome");
            driver = driverManager.CreateDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sports.williamhill.com/betting/en-gb");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
