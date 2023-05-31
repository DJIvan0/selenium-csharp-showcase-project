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
    public class ProductComparePage : BasePage
    {
        public ProductComparePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//a[@title='Remove Product']")]
	    private IWebElement removeProductLink;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-inner-wrap']//span[text()='OK']")]
	    private IWebElement okButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Add to Cart']")]
	    private IWebElement addToCartButton;

        [FindsBy(How = How.XPath, Using = "//div[@role='alert']")]
	    private IWebElement confirmationMessage;

        [FindsBy(How = How.XPath, Using = "//div[text()='You have no items to compare.']")]
	    private IWebElement noItemsForComparisonMessage;

        public void VerifyaddToCartButtonPresent()
        {
            Assert.That(addToCartButton.Displayed, Is.True);
        }

        public void RemoveProductFromComparisonList()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(removeProductLink));
            removeProductLink.Click();
            okButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(noItemsForComparisonMessage));
            Assert.That(noItemsForComparisonMessage.Displayed, Is.True);
        }
    }
}
