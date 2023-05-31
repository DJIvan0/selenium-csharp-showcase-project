using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumCSharpShowcaseProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.TestCases
{
    public class ShoppingCartTests : BaseTest
    {
        private HomePage homePage;
        private HeroHoodieProductPage heroHoodieProductPage;
        private ShoppingCartPage shoppingCartPage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(driver);
            heroHoodieProductPage = new HeroHoodieProductPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);

            homePage.ClickOnHeroHoodieLink();
            Thread.Sleep(1000);
        }

        [Test]
        public void AddingToCartWithoutAnyFieldsFilledTest()
        {
            heroHoodieProductPage.AddToCart();
            heroHoodieProductPage.AssertAllMandatoryFields();
        }

        [Test]
        public void AddingToCartWithAllMandatoryFieldsFilledTest()
        {
            heroHoodieProductPage.AddToCart("s", "grey", "1");
            shoppingCartPage.VerifyProceedToCheckoutButtonPresent();
        }
    }
}
