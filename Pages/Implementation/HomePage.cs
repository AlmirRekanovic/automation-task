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
    public class HomePage : BasePage
    {
        private IWebElement JoinButton => ElementExtension.UntilVisible(By.XPath("//button[@data-test-id='@sitebase/registration-button_pi-header__registration-button']"),driver);
        private IWebElement SignInButtonTranslation(string translation) => ElementExtension.UntilVisible(By.XPath($"//span[text()='{translation}']"),driver);
        private IWebElement CookiePopup => ElementExtension.UntilVisible(By.ClassName("cookie-disclaimer"),driver);
        private IWebElement AcceptCookiesButton => ElementExtension.UntilVisible(By.ClassName("cookie-disclaimer__button"),driver);
        private IWebElement LanguageDropDownMenu(string country) => ElementExtension.UntilVisible(By.XPath($"//span[text()='{country}']"),driver);
        private IWebElement LanguageSelector(string language) => ElementExtension.UntilVisible(By.XPath($"//span[text()='{language}']"),driver);

        public HomePage(IWebDriver driver) : base(driver) { }
        public void ClickOnJoin()
        {
            JoinButton.Click();
        }

        public void VerifyThatButtonIsDisplayed(By by)
        {
            by.DoesElementExists(driver);

        }

        public void VerifyThatJoinButtonIsDisplayed()
        {
            Assert.True(JoinButton.Displayed);
        }

        public void ChangeTheLanguage(string country, string language)
        {
            LanguageDropDownMenu(country).Click();
            LanguageSelector(language).Click();
        }

        public void VerifyThatJoinButtonIsTranslated(string translation)
        {
            Assert.True(SignInButtonTranslation(translation).Displayed);
        }

        public void AcceptCookies()
        {
            AcceptCookiesButton.Click();
        }

        public void VerifyThatAcceptCookiePopUpIsDisplayed()
        {
                Assert.True(CookiePopup.Displayed);
            
        }

        public void VerifyThatAcceptCookiePopUpIsnotDisplayed()
        {
                Assert.True(CookiePopup.Displayed);

        }
    }
}