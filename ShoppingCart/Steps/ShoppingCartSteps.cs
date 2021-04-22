using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ShoppingCart.Hooks;
using ShoppingCart.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace ShoppingCart.Steps
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private ScreenshotImageFormat png;
        private HomePO homePO;
        private ShoppingCartPO shoppingCartPO;
        private CreateAccountPO createAccountPO;
        private WebDriverWait _wait;

        public ShoppingCartSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            _driver = WebHooks.Driver;

            homePO = new HomePO(_driver);

            shoppingCartPO = new ShoppingCartPO(_driver);

            createAccountPO = new CreateAccountPO(_driver);

            if (_scenarioContext.TestError != null)
            {
                png = ScreenshotImageFormat.Png;
            }
        }

        [Given(@"I added the product to the cart")]
        public void GivenIAddedTheProductToTheCart()
        {
            homePO.HomeSite();
            shoppingCartPO.ToAddCart();
            shoppingCartPO.ToCheckAndProceed();
            _scenarioContext.ScenarioExecutionStatus.ToString();
        }
        
        [When(@"I finish adding my data")]
        public void WhenIFinishAddingMyData()
        {
            shoppingCartPO.ToBtnCheckSummary();

            string email = $"{Guid.NewGuid()}@hotmail.com";
            createAccountPO.ToCreateAccount(email);
            createAccountPO.ToFillForm(
               "First",
               "Last",
               "12345",
               "FirstAddress",
               "LastAddress",
               "Street",
               "NameCity",
               "00000",
               "99999999999");
            createAccountPO.BtnRegister();

            shoppingCartPO.ToBtnCheckAddress();

            shoppingCartPO.ToAcceptTermsAndProceedToCheckout();

            shoppingCartPO.ToBtnChoosePayment();

            shoppingCartPO.ToBtnConfirmOrder();

            _scenarioContext.ScenarioExecutionStatus.ToString();

        }
        
        [Then(@"the purchase order will be generated")]
        public void ThenThePurchaseOrderWillBeGenerated()
        {

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            bool equals = _wait.Until(drv => shoppingCartPO.IsPagetDisplayed());
            Assert.IsTrue(equals);
        }
    }
}
