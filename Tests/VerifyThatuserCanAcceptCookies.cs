using NUnit.Framework;
using QA_Framework.Pages.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class VerifyThatuserCanAcceptCookies : TestBase
    {
        [Test, Description("Scenario 1")]
        public void VerifyThatuserCanAcceptCookiesTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.VerifyThatAcceptCookiePopUpIsDisplayed();
            homePage.AcceptCookies();
        }
    }
}
