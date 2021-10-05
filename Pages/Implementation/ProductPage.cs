using OpenQA.Selenium;
using QA_Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Pages.Implementation
{
    public class ProductPage : BasePage
    {
        private IWebElement ProductMenuSection(string product) => driver.FindElement(By.XPath($"(//div[@class='product-container']//a[@class='product-name' and @title='{product}'])[1]"));
        public ProductPage(IWebDriver driver) : base(driver) { }

        public List<String> GetProductNames() 
        {
            var allProductsname = driver.FindElement(By.ClassName("product_list")).FindElements(By.ClassName("product-name"));
            List<string> names = new List<string>();
            foreach (var item in allProductsname)
            {
                names.Add(item.Text);
            }
            
            return names;
        }

        public ProductDetailPage ClickOnProduct(string product) 
        {
            ElementExtension.UntilVisible(By.XPath($"(//div[@class='product-container']//a[@class='product-name' and @title='{product}'])[1]"), driver);

            ProductMenuSection(product).Click();
            return new ProductDetailPage(driver);
        }
    }
}
