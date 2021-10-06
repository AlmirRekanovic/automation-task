using NUnit.Framework;
using OpenQA.Selenium;
using QA_Framework.Pages.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests
{
        [Parallelizable(ParallelScope.All)]
        public class VerifyThatuserCanChangeTheLanguage : TestBase
        {
            [Test, Description("Scenario 2")]
            public void VerifyThatuserCanChangeTheLanguageTest()
            {
                HomePage homePage = new HomePage(driver);
                homePage.VerifyThatJoinButtonIsDisplayed();
                homePage.ChangeTheLanguage("English","Deutsch");
                homePage.VerifyThatJoinButtonIsTranslated("Anmelden");
                homePage.ChangeTheLanguage("Deutsch","日本語");
                homePage.VerifyThatJoinButtonIsTranslated("登録");
                homePage.ChangeTheLanguage("日本語", "Ελληνική");
                homePage.VerifyThatJoinButtonIsTranslated("Εγγραφή");
            }
        }
}
