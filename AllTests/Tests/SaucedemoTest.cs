using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AllTests.Utilities;
using NUnit.Allure.Core;

namespace AllTests.Tests
{
    [AllureNUnit]
    public class SaucedemoTest:BaseClass
    {
        [Test]
        public void InvalidLogin()
        {
            driver.Url = "https://www.saucedemo.com/";
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sce");
            driver.FindElement(By.Name("login-button")).Click();
            string errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']")).Text;
            Assert.IsNull(errorMessage);
        }
        [Test]
        public void SaucedemoTesting()
        {
            driver.Url = "https://www.saucedemo.com/";
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Name("login-button")).Click();
            Thread.Sleep(2000);
            IWebElement dropdown = driver.FindElement(By.XPath("//select[@class='product_sort_container']"));
            SelectElement s=new SelectElement(dropdown);
            s.SelectByText("Price (high to low)");
            driver.FindElement(By.Name("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Id("continue-shopping")).Click();
            driver.FindElement(By.XPath("//a[@id='item_1_title_link']/div[@class='inventory_item_name ']")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys("Shakeer");
            driver.FindElement(By.Id("last-name")).SendKeys("Basha");
            driver.FindElement(By.Id("postal-code")).SendKeys("56006");
            driver.FindElement(By.Id("continue")).Click();
            driver.FindElement(By.Id("finish")).Click();
            driver.FindElement(By.Name("back-to-products")).Click();
        }
        [TearDown]
        public void StopBrowser()
        {
            driver.Quit();
        }
    }
}
