using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.PageObjects
{
    public class HeroHoodieProductPage : BasePage
    {
        public HeroHoodieProductPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "option-label-color-93-item-49")]
	    private IWebElement blackColorOption;

        [FindsBy(How = How.Id, Using = "option-label-color-93-item-52")]
        private IWebElement greyColorOption;

        [FindsBy(How = How.Id, Using = "option-label-color-93-item-53")]
        private IWebElement greenColorOption;

        [FindsBy(How = How.Id, Using = "option-label-size-143-item-166")]
        private IWebElement xsSizeOption;

        [FindsBy(How = How.Id, Using = "option-label-size-143-item-167")]
        private IWebElement sSizeOption;

        [FindsBy(How = How.Id, Using = "option-label-size-143-item-168")]
        private IWebElement mSizeOption;

        [FindsBy(How = How.Id, Using = "option-label-size-143-item-169")]
        private IWebElement lSizeOption;

        [FindsBy(How = How.Id, Using = "option-label-size-143-item-170")]
        private IWebElement xlSizeOption;

        [FindsBy(How = How.Id, Using = "qty")]
        private IWebElement quantityInputField;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Add to Cart']")]
        private IWebElement addToCartButton;

        [FindsBy(How = How.XPath, Using = "//div[@role='alert']")]
        private IWebElement confirmationMessage;

        [FindsBy(How = How.Id, Using = "super_attribute[143]-error")]
        private IWebElement sizeErrorMessageText;

        [FindsBy(How = How.Id, Using = "super_attribute[93]-error")]
        private IWebElement colorErrorMessageText;

        [FindsBy(How = How.Id, Using = "qty-error")]
        private IWebElement quantityErrorMessageText;

        [FindsBy(How = How.XPath, Using = "//a[text()='shopping cart']")]
        private IWebElement shoppingCartPageConfirmationMessageLink;

        [FindsBy(How = How.XPath, Using = "//a[@class='action showcart']")]
        private IWebElement showCartLink;

        public void AddToCart()
        {
            quantityInputField.Click();
            quantityInputField.SendKeys(Keys.Backspace);
            addToCartButton.Click();
        }

        public void AddToCart(String size, String color, String quantity)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            switch (size)
            {
                case "xs":
                    xsSizeOption.Click();
                    break;
                case "s":
                    sSizeOption.Click();
                    break;
                case "m":
                    mSizeOption.Click();
                    break;
                case "l":
                    lSizeOption.Click();
                    break;
                case "xl":
                    xlSizeOption.Click();
                    break;
            }

            switch (color)
            {
                case "black":
                    blackColorOption.Click();
                    break;
                case "grey":
                    greyColorOption.Click();
                    break;
                case "green":
                    greenColorOption.Click();
                    break;
            }

            quantityInputField.Clear();
            quantityInputField.SendKeys(quantity);
            addToCartButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(confirmationMessage));
            shoppingCartPageConfirmationMessageLink.Click();
        }

        public void AssertAllMandatoryFields()
        {
            String actualMessage = "This is a required field.";
            Assert.That(sizeErrorMessageText.Text.Equals(actualMessage), Is.True);
            Assert.That(colorErrorMessageText.Text.Equals(actualMessage), Is.True);
            Assert.That(colorErrorMessageText.Text.Equals(actualMessage), Is.True);
        }
    }
}
