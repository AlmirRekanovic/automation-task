using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using QA_Framework.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework
{

    public class DriverManager
    {
        private string _browser;

        public DriverManager(string browser) 
        {
            _browser = browser;
        }
        public IWebDriver CreateDriver()
        {
            IWebDriver driver;
            DriverOptionsCreator driverOptions = new DriverOptionsCreator(_browser);

            switch (_browser)
            {
                case "iexplorer":
                    driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory, (InternetExplorerOptions)driverOptions.GetDriverOptions(), TimeSpan.FromMinutes(5));
                    break;
                case "chrome":
                    driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, (ChromeOptions)driverOptions.GetDriverOptions(), TimeSpan.FromMinutes(5));
                    break;

                case "firefox":
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
                    driver = new FirefoxDriver(service, (FirefoxOptions)driverOptions.GetDriverOptions(), TimeSpan.FromMinutes(5));
                    break;
                default:
                    driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, (ChromeOptions)driverOptions.GetDriverOptions(), TimeSpan.FromMinutes(5));
                    break;

            }

            return driver;
        }
    }
}
