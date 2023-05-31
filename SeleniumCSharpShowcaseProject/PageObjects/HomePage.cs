using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//a[@title='Argus All-Weather Tank']")]
	    private IWebElement argusAllWeatherTankLink;

        [FindsBy(How = How.XPath, Using = "//a[@title='Fusion Backpack']")]
	    private IWebElement fusionBackpackLink;

        [FindsBy(How = How.XPath, Using = "//a[@title='Push It Messenger Bag']")]
	    private IWebElement pushItMessengerBagLink;

        [FindsBy(How = How.XPath, Using = "//a[@title='Hero Hoodie'][normalize-space()='Hero Hoodie']")]
	    private IWebElement heroHoodieLink;

        [FindsBy(How = How.XPath, Using = "//header[@class='page-header']//li[3]/a")]
	    private IWebElement registrationLink;

        public void ClickOnRegistrationLink() => registrationLink.Click();

        public void ClickOnArgusAllWeatherTankLink() => argusAllWeatherTankLink.Click();

        public void ClickOnFusionBackpackLink() => fusionBackpackLink.Click();

        public void ClickOnPushItMessengerBagLink() => pushItMessengerBagLink.Click();

        public void ClickOnHeroHoodieLink() => heroHoodieLink.Click();
    }
}
