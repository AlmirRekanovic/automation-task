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
        private IWebElement SignInButton => driver.FindElement(By.ClassName("login"));
        private IWebElement SearchInputField => driver.FindElement(By.Id("search_query_top"));
        private IWebElement SearchButton => driver.FindElement(By.Name("submit_search"));
        private IWebElement BestSellerCategoryButton => driver.FindElement(By.CssSelector("a[href='#blockbestsellers']"));

        public HomePage() : base(driver) { }



        //public HomePage GoToHomePage() 
        //{
        //    return new HomePage(driver);
        //}

        public void GoToPage() {
            SignInButton.Click();
        }

        public LoginPage ClickOnSignIn()
        {
            ElementExtension.UntilVisible(By.ClassName("login"), driver);

            SignInButton.Click();
            return new LoginPage(driver);
        }

        public HomePage VerifyNumberOfSections(string category) 
        {
            if (category.Equals("Popular"))
            {
                var popular = driver.FindElement(By.Id("homefeatured")).FindElements(By.TagName("li"));
                Assert.IsTrue(popular.Count == 7);
            }
            else 
            {
                var bestsell = driver.FindElement(By.Id("blockbestsellers")).FindElements(By.TagName("li"));
                Assert.IsTrue(bestsell.Count == 7);
            }

            return new HomePage(driver);
        }

        public HomePage ClickOnBestSellerCategory() 
        {
            BestSellerCategoryButton.Click();

            return new HomePage(driver);
        }

        public ProductPage SearchProduct(string product) 
        {
            SearchInputField.SendKeys(product);
            SearchButton.Click();

            return new ProductPage(driver);
        }
    }
}