using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using QA_Framework.Helpers;
using QA_Framework.Pages.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class CountTheGames : TestBase
    {
        [Test, Description("Scenario 2")]
        public void CountTheGamesTest()
        {
            driver.Navigate().GoToUrl("https://games.williamhill.com/en-gb/");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ElementExtension.UntilVisible(By.XPath("//a[contains(text(),'New')]"), driver));
            actions.Perform();
            HomePage homePage = new HomePage(driver);
            homePage.AcceptCookies();
            ElementExtension.UntilVisible(By.XPath("//a[contains(text(),'New')]"), driver).Click(); 
            //ElementExtension.UntilVisible(By.XPath(" //a[contains(text(),'Live Game Shows')]"), driver).Click();
            var popular = ElementExtension.UntilVisible(By.ClassName("whgg-tile-grid"),driver).FindElements(By.TagName("li"));
            //var live = driver.FindElements(By.XPath("//*[@id='app']/div/div/div[1]/div[4]/div/div[1]/div[2]/div/div[2]/section/section/div/div[2]/div/section/div/div/div")); //.FindElements(By.XPath("//div[@class='sc-fAjcbJ eLITSG']"));
            //Console.WriteLine(live.Count);
            Console.WriteLine(popular.Count);
            //Console.Write(popular.ToString());
        }
    }
}
