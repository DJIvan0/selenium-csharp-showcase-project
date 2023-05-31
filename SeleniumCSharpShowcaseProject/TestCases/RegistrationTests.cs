using SeleniumCSharpShowcaseProject.PageObjects;
using SeleniumCSharpShowcaseProject.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.TestCases
{
    public class RegistrationTests : BaseTest
    {
        private HomePage homePage;
        private RegistrationPage registrationPage;
        private AccountPage accountPage;
        private User user;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(driver);
            registrationPage = new RegistrationPage(driver);
            accountPage = new AccountPage(driver);

            homePage.ClickOnRegistrationLink();
            Thread.Sleep(1000);
        }

        [Test]
        public void RegisterWithoutAnyFieldsFilledTest()
        {
            registrationPage.Register();
            registrationPage.AssertAllMandatoryFields();
        }

        [Test]
        public void RegisterWithAllMandatoryFieldsFilledTest()
        {
            user = UserFactory.CreateUser(false);

            registrationPage.Register(user);
            accountPage.AssertHeadingPresent();
        }

        [Test]
        public void RegisterWithAllMandatoryFieldsFilledAndSubscriptionTest()
        {
            user = UserFactory.CreateUser(true);

            registrationPage.Register(user);
            accountPage.AssertHeadingPresent();
        }

        [Test]
        public void EmailFieldValidationTest()
        {
            user = UserFactory.CreateUser(false);

            registrationPage.ValidateEmailField(user, false);
            registrationPage.ValidateEmailField(user, true);
        }

        [Test]
        public void PasswordLengthValidationTest()
        {
            user = UserFactory.CreateUser(false);

            registrationPage.ValidateLengthInPasswordField(user, "Has less than 8 characters");
            registrationPage.ValidateLengthInPasswordField(user, "Has 8 characters");
            registrationPage.ValidateLengthInPasswordField(user, "Has more than 8 characters");
        }

        [Test]
        public void PasswordMatchingValidationTest()
        {
            user = UserFactory.CreateUser(false);

            registrationPage.ValidateMatchingPassword(user, false);
            registrationPage.ValidateMatchingPassword(user, true);
        }

        [Test]
        public void PasswordStrengthMeterValidationTest()
        {
            user = UserFactory.CreateUser(true);

            registrationPage.ValidatePasswordStrengthMeterIsWorking(user, "Weak");
            registrationPage.ValidatePasswordStrengthMeterIsWorking(user, "Strong");
            registrationPage.ValidatePasswordStrengthMeterIsWorking(user, "Very strong");
        }
    }
}
