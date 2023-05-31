using OpenQA.Selenium;
using SeleniumCSharpShowcaseProject.Resources;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.PageObjects
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "firstname")]
	    private IWebElement firstNameInputField;

        [FindsBy(How = How.Id, Using = "lastname")]
	    private IWebElement lastNameInputField;

        [FindsBy(How = How.Id, Using = "email_address")]
	    private IWebElement emailInputField;

        [FindsBy(How = How.Id, Using = "password")]
	    private IWebElement passwordInputField;

        [FindsBy(How = How.Id, Using = "password-confirmation")]
	    private IWebElement confirmPasswordInputField;

        [FindsBy(How = How.Id, Using = "is_subscribed")]
	    private IWebElement newsletterSubscriptionCheckbox;

        [FindsBy(How = How.XPath, Using = "//form[@id='form-validate']//button")]
	    private IWebElement createAnAccountButton;

        [FindsBy(How = How.Id, Using = "firstname-error")]
	    private IWebElement firstNameErrorMessageText;

        [FindsBy(How = How.Id, Using = "lastname-error")]
	    private IWebElement lastNameErrorMessageText;

        [FindsBy(How = How.Id, Using = "email_address-error")]
	    private IWebElement emailErrorMessageText;

        [FindsBy(How = How.Id, Using = "password-error")]
	    private IWebElement passwordErrorMessageText;

        [FindsBy(How = How.Id, Using = "password-confirmation-error")]
	    private IWebElement confirmPasswordErrorMessageText;

        [FindsBy(How = How.Id, Using = "password-strength-meter-label")]
	    private IWebElement passwordStrengthMeterLabel;

        public void Register()
        {
            createAnAccountButton.Click();
        }

        public void Register(User user)
        {
            if (!String.IsNullOrEmpty(user.FirstName))
            {
                firstNameInputField.SendKeys(user.FirstName);
            }

            if (!String.IsNullOrEmpty(user.LastName))
            {
                lastNameInputField.SendKeys(user.LastName);
            }

            if (!String.IsNullOrEmpty(user.Email))
            {
                emailInputField.SendKeys(user.Email);
            }

            if (!String.IsNullOrEmpty(user.Password))
            {
                passwordInputField.SendKeys(user.Password);
            }

            if (!String.IsNullOrEmpty(user.ConfirmPassword))
            {
                confirmPasswordInputField.SendKeys(user.ConfirmPassword);
            }

            if (user.Subscription)
            {
                newsletterSubscriptionCheckbox.Click();
            }

            createAnAccountButton.Click();
        }

        public void ValidateEmailField(User user, bool validFormat)
        {
            if (validFormat)
            {
                emailInputField.SendKeys(user.Email);
                createAnAccountButton.Click();
                Assert.That(!emailErrorMessageText.Displayed, Is.True);
                emailInputField.Clear();
            }
            else
            {
                emailInputField.SendKeys(user.Email.Replace("@", ""));
                createAnAccountButton.Click();
                Assert.That(emailErrorMessageText.Text.Equals(
                    "Please enter a valid email address (Ex: johndoe@domain.com)."), Is.True);
                emailInputField.Clear();
            }
        }

        public void ValidateLengthInPasswordField(User user, String formatType)
        {
            String actualMessage = "Minimum length of this field must be equal or greater than 8 symbols. Leading and trailing spaces will be ignored.";
            if (formatType.Equals("Has less than 8 characters", StringComparison.OrdinalIgnoreCase))
            {
                passwordInputField.SendKeys(user.Password.Substring(0, 7));
                passwordInputField.Click();
                Assert.That(passwordErrorMessageText.Text.Equals(actualMessage, StringComparison.OrdinalIgnoreCase), Is.True);
                passwordInputField.Clear();
            }
            else if (formatType.Equals("Has 8 characters", StringComparison.OrdinalIgnoreCase))
            {
                passwordInputField.SendKeys(user.Password.Substring(0, 8));
                Assert.That(!passwordErrorMessageText.Text.Equals(actualMessage, StringComparison.OrdinalIgnoreCase), Is.True);
                passwordInputField.Clear();
            }
            else if (formatType.Equals("Has more than 8 characters", StringComparison.OrdinalIgnoreCase))
            {
                passwordInputField.SendKeys(user.Password);
                Assert.That(!passwordErrorMessageText.Text.Equals(actualMessage, StringComparison.OrdinalIgnoreCase), Is.True);
                passwordInputField.Clear();
            }
        }

        public void ValidateMatchingPassword(User user, bool matching)
        {
            if (matching)
            {
                passwordInputField.SendKeys(user.Password);
                confirmPasswordInputField.SendKeys(user.ConfirmPassword);
                createAnAccountButton.Click();
                Assert.That(!confirmPasswordErrorMessageText.Displayed, Is.True);
                passwordInputField.Clear();
                confirmPasswordInputField.Clear();
            }
            else
            {
                passwordInputField.SendKeys(user.Password);
                confirmPasswordInputField.SendKeys(user.ConfirmPassword + ".");
                createAnAccountButton.Click();
                Assert.That(confirmPasswordErrorMessageText.Text.Equals("Please enter the same value again."),Is.True);
                passwordInputField.Clear();
                confirmPasswordInputField.Clear();
            }
        }

        public void ValidatePasswordStrengthMeterIsWorking(User user, String strength)
        {
            if (strength.Equals("Weak", StringComparison.OrdinalIgnoreCase))
            {
                passwordInputField.SendKeys(Regex.Replace(user.Password, @"[\d]", string.Empty));
                Assert.That(passwordStrengthMeterLabel.Text.Equals("Weak"), Is.True);
                Assert.That(passwordStrengthMeterLabel.Displayed, Is.True);
                passwordInputField.Clear();
            }
            else if (strength.Equals("Strong", StringComparison.OrdinalIgnoreCase))
            {
                passwordInputField.SendKeys(user.Password);
                Assert.That(passwordStrengthMeterLabel.Text.Equals("Strong"), Is.True);
                Assert.That(passwordStrengthMeterLabel.Displayed, Is.True);
                passwordInputField.Clear();
            }
            else if (strength.Equals("Very strong", StringComparison.OrdinalIgnoreCase))
            {
                passwordInputField.SendKeys(user.Password + "!.");
                Assert.That(passwordStrengthMeterLabel.Text.Equals("Very Strong"), Is.True);
                Assert.That(passwordStrengthMeterLabel.Displayed, Is.True);
                passwordInputField.Clear();
            }
        }

        public void AssertAllMandatoryFields()
        {
            String actualMessage = "This is a required field.";
            Assert.That(actualMessage, Is.EqualTo(firstNameErrorMessageText.Text));
            Assert.That(actualMessage, Is.EqualTo(lastNameErrorMessageText.Text));
            Assert.That(actualMessage, Is.EqualTo(emailErrorMessageText.Text));
            Assert.That(actualMessage, Is.EqualTo(passwordErrorMessageText.Text));
            Assert.That(actualMessage, Is.EqualTo(confirmPasswordErrorMessageText.Text));
        }
    }
}
