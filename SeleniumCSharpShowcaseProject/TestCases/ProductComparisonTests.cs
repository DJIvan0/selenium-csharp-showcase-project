using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using SeleniumCSharpShowcaseProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.TestCases
{
    public class ProductComparisonTests : BaseTest
    {
        private HomePage homePage;
        private ProductComparePage productComparePage;
        private FusionBackpackProductPage fusionBackpackProductPage;

        [SetUp]
        public void SetUp()
        {
            homePage = new HomePage(driver);
            fusionBackpackProductPage = new FusionBackpackProductPage(driver);
            productComparePage = new ProductComparePage(driver);

            homePage.ClickOnFusionBackpackLink();
            Thread.Sleep(1000);
        }

        [Test]
        public void AddingProductToComparisonListAndViewingFromConfirmationMessageLinkTest()
        {
            fusionBackpackProductPage.AddToProductComparisonAndView(false);
            productComparePage.VerifyaddToCartButtonPresent();
        }

        [Test]
        public void AddingProductToComparisonListAndViewingFromHeaderLinkTest()
        {
            fusionBackpackProductPage.AddToProductComparisonAndView(true);
            productComparePage.VerifyaddToCartButtonPresent();
        }

        [Test]
        public void RemoveProductFromComparisonListTest()
        {
            fusionBackpackProductPage.AddToProductComparisonAndView(true);
            productComparePage.RemoveProductFromComparisonList();
        }
    }
}
