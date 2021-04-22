using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace ShoppingCart.PageObjects
{
    public class ShoppingCartPO
    {
        private IWebDriver driver;
        public WebDriverWait wait;

        private By byAddToCartBtn;
        private By byProceedToCheckoutAfterAddToCart;
        private By byProceedToCheckoutSummary;
        private By byProceedToCheckoutAddress;

        private By byCheckTermsOfService;
        private By byProceedToCheckCarrier;

        private By byBankWireLink;
        private By byConfirmOrderBtn;

        private By byPageOrderConfirmation;

        public static string TEXT = "Your order on My Store is complete.";
        public ShoppingCartPO(IWebDriver driver)
        {
            this.driver = driver;

            byAddToCartBtn = By.CssSelector("#homefeatured > li.ajax_block_product.col-xs-12.col-sm-4.col-md-3.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line > div > div.right-block > div.button-container > a.button.ajax_add_to_cart_button.btn.btn-default");
            ////*[@id="homefeatured"]/li[1]/div/div[2]/div[2]/a[1]
            ///
            byProceedToCheckoutAfterAddToCart = By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a");
            ////*[@id="layer_cart"]/div[1]/div[2]/div[4]/a
            ///
            byProceedToCheckoutSummary = By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium");
            ////*[@id="center_column"]/p[2]/a[1]
            ///
            byProceedToCheckoutAddress = By.CssSelector("#center_column > form > p > button");
            //*[@id="center_column"]/form/p/button

            byCheckTermsOfService = By.Id("cgv");
            byProceedToCheckCarrier = By.CssSelector("#form > p > button");

            byBankWireLink = By.ClassName("bankwire");
            byConfirmOrderBtn = By.CssSelector("#cart_navigation > button");

            byPageOrderConfirmation = By.CssSelector("#center_column > div > p > strong");
        }

        public void ToAddCart()
        {
            var addCart = driver.FindElement(byAddToCartBtn);          

            IAction addProdutoCart = new Actions(driver)
                .MoveToElement(addCart)
                .Click()             
                .Build();

            addProdutoCart.Perform();
        }

        public void ToCheckAndProceed()
        {
            //var element = driver.FindElement(byProceedToCheckoutAfterAddToCart);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            var checkProduct = wait
                .Until(SeleniumExtras
                .WaitHelpers
                .ExpectedConditions.ElementToBeClickable(byProceedToCheckoutAfterAddToCart));
            checkProduct.Click();
        }

        public void ToBtnCheckSummary()
        {
            driver.FindElement(byProceedToCheckoutSummary).Click();
        }

        public void ToBtnCheckAddress()
        {
            driver.FindElement(byProceedToCheckoutAddress).Click();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3);
        }

        public void ToAcceptTermsAndProceedToCheckout()
        {
            var checkAccept = driver.FindElement(byCheckTermsOfService);
            var proceed = driver.FindElement(byProceedToCheckCarrier);

            IAction check = new Actions(driver)
                .MoveToElement(checkAccept)
                .Click()
                .MoveToElement(proceed)
                .Click()
                .Build();

            check.Perform();
        }

        public void ToBtnChoosePayment()
        {
            driver.FindElement(byBankWireLink).Click();
        }

        public void ToBtnConfirmOrder()
        {
            driver.FindElement(byConfirmOrderBtn).Click();
        }

        public bool IsPagetDisplayed()
        {          
            var titleSelect = driver.FindElement(byPageOrderConfirmation).Text;
            var element = driver.FindElement(byPageOrderConfirmation);
            if (TEXT.Equals(titleSelect, StringComparison.OrdinalIgnoreCase))
            {
                return element.Displayed;
            }
            throw new NotFoundException($"Element with title {TEXT} was not found");
        }

    }
}
