using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QA_Framework.Tests
{
    public class DriverOptionsCreator
    {
        private readonly string _browser;

        public DriverOptionsCreator(string browser)
        {
            _browser = browser;
        }

        public DriverOptions GetDriverOptions()
        {
            DriverOptions driverOptions = null;

            switch (_browser)
            {
                case "iexplorer":
                    driverOptions = new InternetExplorerOptions
                    {
                        EnableNativeEvents = true,
                        IgnoreZoomLevel = true,
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        PageLoadStrategy = PageLoadStrategy.Normal,
                        EnsureCleanSession = true
                    };
                    break;

                case "firefox":
                    driverOptions = new FirefoxOptions
                    {
                        PageLoadStrategy = PageLoadStrategy.Normal

                    };
                    break;

                case "chrome":

                    typeof(CapabilityType).GetField(nameof(CapabilityType.LoggingPreferences), BindingFlags.Static | BindingFlags.Public).SetValue(null, "goog:loggingPrefs");
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
                    chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);

                    chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                    chromeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                    chromeOptions.AddArgument("disable-infobars");
                    chromeOptions.AddArgument("disable-dev-shm-usage"); // overcome limited resource problems
                    ChromePerformanceLoggingPreferences preferences = new ChromePerformanceLoggingPreferences();
                    preferences.AddTracingCategories("devtools.network");

                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

                    chromeOptions.PerformanceLoggingPreferences = preferences;
                    chromeOptions.PerformanceLoggingPreferences.IsCollectingPageEvents = false;
                    chromeOptions.PerformanceLoggingPreferences.IsCollectingNetworkEvents = true;
                    chromeOptions.SetLoggingPreference("performance", LogLevel.All);
                    chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    driverOptions = chromeOptions;
                    break;
            }

            return driverOptions;
        }
    }
}
