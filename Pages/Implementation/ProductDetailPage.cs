using NUnit.Framework;
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
    public class ProductDetailPage : BasePage
    {
        private IWebElement TwiterButton => driver.FindElement(By.CssSelector("i[class='icon-twitter']"));
        private IWebElement FacebookButton => driver.FindElement(By.CssSelector("i[class='icon-facebook']"));
        private IWebElement GooglePlusButton => driver.FindElement(By.CssSelector("i[class='icon-google-plus']"));
        private IWebElement PintrestButton => driver.FindElement(By.CssSelector("i[class='icon-pinterest']"));
        private IWebElement DiscountLabel => driver.FindElement(By.Id("reduction_percent_display"));
        private IWebElement QuanityLabel => driver.FindElement(By.Id("quantity_wanted"));
        private SelectElement SizeDropDown => new SelectElement(driver.FindElement(By.Id("group_1")));
        private IWebElement ColorPicker => driver.FindElement(By.Id("color_14"));
        private IWebElement AddToCartButton => driver.FindElement(By.XPath("//p[@id='add_to_cart']/button"));
        private IWebElement ColorAndSizeLabel => driver.FindElement(By.Id("layer_cart_product_attributes"));
        private IWebElement QuantityPopUpLabel => driver.FindElement(By.Id("layer_cart_product_quantity"));
        private IWebElement ProceedToCheckoutButton => driver.FindElement(By.XPath("//a[@title='Proceed to checkout']"));
        private IWebElement DeliveryAdresFirstAndLasteNameLabel => driver.FindElement(By.XPath("//ul[contains(@class,'address first_item')]//span[@class='address_name']"));
        private IWebElement AcceptTermsAndCoinditionsCheckBox => driver.FindElement(By.Id("uniform-cgv"));
        private IWebElement AliasAddress => driver.FindElement(By.XPath("//div[@class='delivery_options_address']/p"));
        private IWebElement BankWireButton => driver.FindElement(By.ClassName("bankwire"));
        private IWebElement ConfirmMyOrderButton => driver.FindElement(By.XPath("//p[@id='cart_navigation']/button"));
        private IWebElement ConfirmationTitle => driver.FindElement(By.ClassName("cheque-indent"));
        private IWebElement SummaryProductName => driver.FindElement(By.XPath("//table[@id='cart_summary']/tbody/tr//p[@class='product-name']"));


        public ProductDetailPage(IWebDriver driver) : base(driver){}

        public ProductDetailPage VerifySocialNetworkButtonsAreDisplayed() 
        {
            ElementExtension.UntilVisible(By.CssSelector("i[class='icon-twitter']"), driver);

            Assert.True(TwiterButton.Displayed);
            Assert.True(FacebookButton.Displayed);
            Assert.True(GooglePlusButton.Displayed);
            Assert.True(PintrestButton.Displayed);

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage SelectColor()
        {
            ColorPicker.Click(); 

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage SelectSize(string size)
        {
            SizeDropDown.SelectByText(size);

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage SelectQuantity(string quantity)
        {
            QuanityLabel.SendKeys(quantity);

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage VerifyDiscount(string expectedDiscount)
        {
            string discount = DiscountLabel.Text;
            Assert.True(discount.Contains(expectedDiscount));

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage AddToCart()
        {
            AddToCartButton.Click();

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage VerifyProductDetails(string size, string color, string quantity)
        {
            ElementExtension.UntilVisible(By.Id("layer_cart_product_attributes"), driver);

            var sizeAndColor = ColorAndSizeLabel.Text.Split(',');
            var colorValue = sizeAndColor[0].Trim();
            var sizeValue = sizeAndColor[1].Trim();
            Assert.AreEqual(colorValue,color);
            Assert.AreEqual(sizeValue, size);
            Assert.True(QuantityPopUpLabel.Text.Trim().Contains(quantity));

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage ClickOnProceedToCheckout()
        {
            ElementExtension.UntilVisible(By.XPath("//a[@title='Proceed to checkout']"), driver);

            ProceedToCheckoutButton.Click(); 

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage ClickOnProceedToCheckoutOnAddress()
        {
            ElementExtension.UntilVisible(By.Name("processAddress"), driver).Click();

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage ClickOnProceedToCheckoutOnCart()
        {
            ElementExtension.UntilVisible(By.XPath("(//a[@title='Proceed to checkout'])[2]"), driver).Click();

            return new ProductDetailPage(driver);
        }
        
         public ProductDetailPage ClickOnProceedToCheckoutOnShiping()
        {
            ElementExtension.UntilVisible(By.Name("processCarrier"), driver).Click();

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage VerifyProductNameOnSummary(string productName)
        {
            ElementExtension.UntilVisible(By.Id("order_step"), driver);

            Assert.True(SummaryProductName.Text.Trim().Contains(productName));

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage VerifyAddressData(string name)
        {
            ElementExtension.UntilVisible(By.XPath("//ul[contains(@class,'address first_item')]//span[@class='address_name']"), driver);

            Assert.True(DeliveryAdresFirstAndLasteNameLabel.Text.Contains(name));

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage VerifyAliasAddress(string address)
        {
            ElementExtension.UntilVisible(By.XPath("//div[@class='delivery_options_address']/p"), driver);

            Assert.True(AliasAddress.Text.Contains(address));

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage AcceptTermsAndConditions()
        {
            ElementExtension.UntilVisible(By.Id("uniform-cgv"), driver);

            AcceptTermsAndCoinditionsCheckBox.Click();

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage ClickOnBankWire()
        {
            ElementExtension.UntilVisible(By.ClassName("bankwire"), driver);

            BankWireButton.Click();

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage ClickOnConfirmOrder()
        {
            ElementExtension.UntilVisible(By.XPath("//p[@id='cart_navigation']/button"), driver);

            ConfirmMyOrderButton.Click();

            return new ProductDetailPage(driver);
        }

        public ProductDetailPage VerifyConfirmationTitle(string title)
        {
            ElementExtension.UntilVisible(By.ClassName("cheque-indent"), driver);

            Assert.True(ConfirmationTitle.Text.Contains(title));

            return new ProductDetailPage(driver);
        }

    }
}
