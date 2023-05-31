using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.PageObjects
{
    public class FusionBackpackProductPage : BasePage
    {
        public FusionBackpackProductPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//a[@aria-label='store logo']//img")]
	    private IWebElement homePageLink;

        [FindsBy(How = How.XPath, Using = "//a[@data-role='add-to-links']")]
        private IWebElement addToCompareLink;

        [FindsBy(How = How.XPath, Using = "//div[@role='alert']")]
        private IWebElement confirmationMessage;

        [FindsBy(How = How.XPath, Using = "//a[@title='Compare Products']")]
        private IWebElement compareProductsPageLink;

        [FindsBy(How = How.XPath, Using = "//a[text()='comparison list']")]
        private IWebElement compareProductsPageConfirmationMessageLink;

        public void AddToProductComparisonAndView(bool headerLink)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            addToCompareLink.Click();

            if (headerLink)
            {
               wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(compareProductsPageLink));
                compareProductsPageLink.Click();
            }
            else
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(compareProductsPageConfirmationMessageLink));
                compareProductsPageConfirmationMessageLink.Click();
            }
        }
    }
}
