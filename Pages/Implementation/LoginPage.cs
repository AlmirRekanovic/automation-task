using OpenQA.Selenium;
using QA_Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Pages.Implementation
{
    public class LoginPage : BasePage
    {
        private IWebElement RegistrationEmailField => driver.FindElement(By.Id("email_create"));
        private IWebElement CreateAccountButton => driver.FindElement(By.Id("SubmitCreate"));
        private IWebElement LoginEmailField => driver.FindElement(By.Id("email"));
        private IWebElement PasswordField => driver.FindElement(By.Id("passwd"));
        private IWebElement SingInButton => driver.FindElement(By.Id("SubmitLogin"));
        
        public LoginPage(IWebDriver driver) : base(driver) { }


        public LoginPage PopulateRegistrationEmail(string email) 
        {
            ElementExtension.UntilVisible(By.Id("email_create"), driver);

            RegistrationEmailField.SendKeys(email);

            return new LoginPage(driver);
        }

        public RegistrationPage ClickOnCreateAccount()
        {
            CreateAccountButton.Click();

            return new RegistrationPage(driver);
        }
        public MyAccountPage LogIn(UserModel user)
        {
            ElementExtension.UntilVisible(By.Id("email"),driver);

            LoginEmailField.SendKeys(user.Email);
            PasswordField.SendKeys(user.Password);
            SingInButton.Click();

            return new MyAccountPage(driver);
        }
    }
}
