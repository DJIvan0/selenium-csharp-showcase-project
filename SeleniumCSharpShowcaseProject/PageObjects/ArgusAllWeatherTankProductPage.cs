using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.PageObjects
{
    public class ArgusAllWeatherTankProductPage : BasePage
    {
        public ArgusAllWeatherTankProductPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "tab-label-reviews-title")]
	    private IWebElement reviewTabLink;

        [FindsBy(How = How.Id, Using = "Rating_5_label")]
	    private IWebElement fiveStarRating;

        [FindsBy(How = How.Id, Using = "nickname_field")]
	    private IWebElement nicknameInputField;

        [FindsBy(How = How.Id, Using = "summary_field")]
	    private IWebElement summaryInputField;

        [FindsBy(How = How.Id, Using = "review_field")]
	    private IWebElement reviewTextField;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Submit Review']")]
	    private IWebElement submitReviewButton;

        [FindsBy(How = How.XPath, Using = "//div[@role='alert']")]
	    private IWebElement confirmationMessage;

        [FindsBy(How = How.Id, Using = "ratings[4]-error")]
	    private IWebElement ratingErrorMessageText;

        [FindsBy(How = How.Id, Using = "nickname_field-error")]
	    private IWebElement nicknameErrorMessageText;

        [FindsBy(How = How.Id, Using = "summary_field-error")]
	    private IWebElement summaryErrorMessageText;

        [FindsBy(How = How.Id, Using = "review_field-error")]
	    private IWebElement reviewErrorMessageText;

        public void LeaveAReview(String nickname, String summary, String review)
        {
            reviewTabLink.Click();
            Actions hoverAction = new Actions(driver);
            hoverAction.MoveToElement(fiveStarRating).Click().Perform();
            nicknameInputField.SendKeys(nickname);
            summaryInputField.SendKeys(summary);
            reviewTextField.SendKeys(review);
            submitReviewButton.Click();
            Assert.That(confirmationMessage.Displayed, Is.True);
        }

        public void LeaveAReview()
        {
            reviewTabLink.Click();
            submitReviewButton.Click();
        }

        public void AssertAllMandatoryFields()
        {
            Assert.That(ratingErrorMessageText.Displayed, Is.True);
            Assert.That(nicknameErrorMessageText.Displayed, Is.True);
            Assert.That(summaryErrorMessageText.Displayed, Is.True);
            Assert.That(reviewErrorMessageText.Displayed, Is.True);
        }
    }
}
