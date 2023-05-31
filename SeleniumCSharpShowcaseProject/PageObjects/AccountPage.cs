using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.PageObjects
{
    public class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//h1[@class='page-title']")]
	    private IWebElement myAccountHeading;

        public void AssertHeadingPresent()
        {
            Assert.That(myAccountHeading.Displayed, Is.True);
        }
    }
}
