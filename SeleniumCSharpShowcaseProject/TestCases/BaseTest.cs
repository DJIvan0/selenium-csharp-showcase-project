using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumCSharpShowcaseProject.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.TestCases
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }

    public class BaseTest : Driver
    {
        [SetUp]
        public void SetUp()
        {
            if (BrowserSettings.Browser.Equals(BrowserType.Firefox.ToString()))
            {
                driver = new FirefoxDriver();

            }
           else if(BrowserSettings.Browser.Equals(BrowserType.Chrome.ToString()))
            {
                driver = new ChromeDriver();

            }
            else if(BrowserSettings.Browser.Equals(BrowserType.IE.ToString()))
            {
                driver = new InternetExplorerDriver();
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
