using OpenQA.Selenium;
using System;

namespace ShoppingCart.PageObjects
{
    public class CreateAccountPO
    {
        private IWebDriver driver;

        private By byCreateAccountEmailField;
        private By byCreateAccountEmailBtn;

        private By byInputFirstName;
        private By byInputLastName;
        private By byInputPassword;

        private By byOptionDayDateBirth;
        private By byOptionMonthDateBirth;
        private By byOptionYearDateBirth;

        private By byInputAddressFirstName;
        private By byInputAddressLastName;
        private By byInputAddress;
        private By byInputCity;
        private By bySelectState;
        private By byInputPostalCode;
        private By bySelectCountry;
        private By byInputMobilePhone;

        private By byBtnRegister;

        public CreateAccountPO(IWebDriver driver)
        {
            this.driver = driver;

            byCreateAccountEmailField = By.Id("email_create");
            byCreateAccountEmailBtn = By.Id("SubmitCreate");

            byInputFirstName = By.Id("customer_firstname");
            byInputLastName = By.Id("customer_lastname");
            byInputPassword = By.Id("passwd");

            byOptionDayDateBirth = By.XPath("//select[@id='days']/option[2]");
            byOptionMonthDateBirth = By.XPath("//select[@id='months']/option[3]");
            byOptionYearDateBirth = By.XPath("//*[@id='years']/option[13]");

            byInputAddressFirstName = By.Id("firstname");
            byInputAddressLastName = By.Id("lastname");
            byInputAddress = By.Id("address1");
            byInputCity = By.Id("city");
            bySelectState = By.CssSelector("#id_state > option:nth-child(2)");
            byInputPostalCode = By.Id("postcode");
            bySelectCountry = By.CssSelector("#id_country > option:nth-child(2)");
            byInputMobilePhone = By.Id("phone_mobile");

            byBtnRegister = By.Id("submitAccount");
        }

        public void ToCreateAccount(string email)
        {
            driver.FindElement(byCreateAccountEmailField).SendKeys(email);
            driver.FindElement(byCreateAccountEmailBtn).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public void ToFillForm(
            string firstName,
            string lastName,
            string password,
            string addressFirstName,
            string addressLastName,
            string address,
            string city,
            string postalCode,
            string mobilePhone)
        {
           
            driver.FindElement(byInputFirstName).SendKeys(firstName);
            driver.FindElement(byInputLastName).SendKeys(lastName);
            driver.FindElement(byInputPassword).SendKeys(password);

            driver.FindElement(byOptionDayDateBirth).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(byOptionMonthDateBirth).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(byOptionYearDateBirth).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElement(byInputAddressFirstName).SendKeys(addressFirstName);
            driver.FindElement(byInputAddressLastName).SendKeys(addressLastName);
            driver.FindElement(byInputAddress).SendKeys(address);
            driver.FindElement(byInputCity).SendKeys(city);
            driver.FindElement(bySelectState).Click();
            driver.FindElement(byInputPostalCode).SendKeys(postalCode);
            driver.FindElement(bySelectCountry).Click();
            driver.FindElement(byInputMobilePhone).SendKeys(mobilePhone);           
        }

        public void BtnRegister()
        {
            driver.FindElement(byBtnRegister).Submit();
        }
    }
}
