using NUnit.Framework;
using OpenQA.Selenium;
using QA_Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Pages.Implementation
{
    public class MyAccountPage : BasePage
    {
        private IWebElement HomeButton => driver.FindElement(By.CssSelector("a[title='Home']"));
        private IWebElement SignOutButton => driver.FindElement(By.ClassName("logout"));
        public MyAccountPage(IWebDriver driver) : base(driver) { }

        public HomePage GoToHomePage() 
        {
            HomeButton.Click();
            return new HomePage(driver);
        }

        public MyAccountPage IsUserLoggedIn() 
        {
            ElementExtension.UntilVisible(By.CssSelector("a[title='Home']"), driver);

            Assert.True(HomeButton.Displayed);
            return new MyAccountPage(driver);
        }
    }
}
