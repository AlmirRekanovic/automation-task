using OpenQA.Selenium;
using QA_Framework.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Pages
{
    public class BasePage : TestBase
    {
        // protected IWebDriver driver;
        //public BasePage(IWebDriver driver) : base(driver) { }
        public BasePage(IWebDriver driver){
            this.driver = driver;
        }

    }
}
