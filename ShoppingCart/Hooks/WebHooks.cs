using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace ShoppingCart.Hooks
{
    [Binding]
    public sealed class WebHooks
    {
        public static IWebDriver Driver { get; private set; }
        private WebDriverWait _wait;

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions chromeOptions = new ChromeOptions();

           // chromeOptions.AddArguments("--start-maximized");
            chromeOptions.AddArguments("--disable-notifications");
            chromeOptions.AddExcludedArgument("disable-popup-blocking");

            Driver = new ChromeDriver(chromeOptions);
            _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
