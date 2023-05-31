using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.PageObjects
{
    public class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//button[@data-role='proceed-to-checkout']")]
	    private IWebElement proceedToCheckoutButton;

        public void VerifyProceedToCheckoutButtonPresent()
        {
            Assert.That(proceedToCheckoutButton.Displayed, Is.True);
        }
    }

}
