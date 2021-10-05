using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Pages.Implementation
{
    public class RegistrationPage : BasePage
    {
        private IWebElement MrRadioButton => driver.FindElement(By.Id("id_gender1"));
        private IWebElement MrsRadioButton => driver.FindElement(By.Id("id_gender2"));
        private IWebElement CustomerFirstNameField => driver.FindElement(By.Id("customer_firstname"));
        private IWebElement CustomerLastNameField => driver.FindElement(By.Id("customer_lastname"));
        private IWebElement PasswordField => driver.FindElement(By.Id("passwd"));
        private IWebElement AddressFirstName => driver.FindElement(By.Id("firstname"));
        private IWebElement AddressLastName => driver.FindElement(By.Id("lastname"));
        private IWebElement AddressField => driver.FindElement(By.Id("address1"));
        private IWebElement CityField => driver.FindElement(By.Id("city"));
        private SelectElement CountryDropDown => new SelectElement(driver.FindElement(By.Id("id_country")));
        private SelectElement StateDropDown => new SelectElement(driver.FindElement(By.Id("id_state")));
        private IWebElement PostCodeField => driver.FindElement(By.Id("postcode"));
        private IWebElement MobilePhoneField => driver.FindElement(By.Id("phone_mobile"));
        private IWebElement AliasFeild => driver.FindElement(By.Id("alias"));
        private IWebElement RegisterButton => driver.FindElement(By.Id("submitAccount"));

        public RegistrationPage(IWebDriver driver) : base(driver) { }

        public void PopulateAllMandatoryFieldsForRegistration(UserModel user) 
        {
            ElementExtension.UntilVisible(By.Id("id_gender1"), driver);

            if (user.Gender.Equals("Mr"))
            {
                MrRadioButton.Click();
            }
            else 
            {
                MrsRadioButton.Click();
            }                

            CustomerFirstNameField.SendKeys(user.FirstName);
            CustomerLastNameField.SendKeys(user.LastName);
            PasswordField.SendKeys(user.Password);
            AddressFirstName.SendKeys(user.AddressFirstName);
            AddressLastName.SendKeys(user.AddressLastName);
            AddressField.SendKeys(user.Address);
            CityField.SendKeys(user.City);
            StateDropDown.SelectByText(user.State);
            CountryDropDown.SelectByText(user.Country);
            PostCodeField.SendKeys(user.PostCode);
            MobilePhoneField.SendKeys(user.MobilePhone);
            AliasFeild.Clear();
            AliasFeild.SendKeys(user.Alias);
        }

        public MyAccountPage CreateAccount()
        {
            RegisterButton.Click();
            return new MyAccountPage(driver);
        }
    }
}
