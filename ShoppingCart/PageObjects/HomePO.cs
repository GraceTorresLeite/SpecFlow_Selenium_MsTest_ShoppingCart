using OpenQA.Selenium;

namespace ShoppingCart.PageObjects
{
    public class HomePO
    {
        private IWebDriver driver;

        public HomePO(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void HomeSite()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
    }
}
