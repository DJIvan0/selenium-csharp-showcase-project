using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumCSharpShowcaseProject.PageObjects;
using SeleniumCSharpShowcaseProject.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.TestCases
{
    public class ProductReviewTests : BaseTest
    {
        private HomePage homePage;
        private ArgusAllWeatherTankProductPage argusAllWeatherTankProductPage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(driver);
            argusAllWeatherTankProductPage = new ArgusAllWeatherTankProductPage(driver);

            homePage.ClickOnArgusAllWeatherTankLink();
            Thread.Sleep(1000);
        }

        [Test]
        public void LeavingAReviewWithAllMandatoryFieldsFilledTest()
        {
            argusAllWeatherTankProductPage.LeaveAReview("nickname", "summary", "review");
        }

        [Test]
        public void LeavingAReviewWithoutAnyFieldsFilledTest()
        {
            argusAllWeatherTankProductPage.LeaveAReview();
            argusAllWeatherTankProductPage.AssertAllMandatoryFields();
        }
    }
}
