using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Helpers
{
    public static class ElementExtension
    {
        public static bool WaitUntilClickable(this IWebElement element, IWebDriver driver, int numSec)
        {
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(numSec));

                    return wait.Until(drv =>
                    {
                        if (SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element) != null)
                            return true;
                        return false;
                    });
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool ElementlIsClickable(this IWebElement element, IWebDriver driver, uint timeoutInSeconds = 60, bool displayed = true)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv =>
                {
                    if (SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element) != null)
                        return true;
                    return false;
                });
            }
            catch
            {
                return false;
            }
        }

        public static void ClickWrapper(this IWebElement element, IWebDriver driver, string elementName)
        {
            if (ElementlIsClickable(element,driver))
            {
                element.Click();
            }
            else
            {
                throw new Exception(string.Format("[{0}] - Element [{1}] is not displayed", DateTime.Now.ToString("HH:mm:ss.fff"), elementName));
            }
        }
        public static IWebElement DoesElementExists(this By Locator, IWebDriver driver, uint timeoutInSeconds = 60)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(Locator));
            }
            catch
            {
                return null;
            }
        }

        public static IWebElement UntilVisible(By by, IWebDriver driver, int timeOutSeconds = 200)
        {
            try
            {
                return UntilVisible(by, driver, TimeSpan.FromSeconds(timeOutSeconds));

            }
            catch (Exception e)
            {
                throw new ElementNotVisibleException($"{e.Message} : Element with locator {by} is not visible!");
            }
        }

        private static IWebElement UntilVisible(By by, IWebDriver driver, TimeSpan timeOut)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeOut);
            wait.PollingInterval = TimeSpan.FromMilliseconds(5);
            wait.IgnoreExceptionTypes
            (
                typeof(ElementNotVisibleException),
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException)
            );

            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
    }
}
