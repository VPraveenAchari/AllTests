using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace AllTests.Tests
{
    [AllureNUnit]
    public class TestClass
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Url = "https://www.demoblaze.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(8);
        }
        [Test]
        public void PurchasingProduct()
        {
            driver.FindElement(By.Id("login2")).Click();
            driver.FindElement(By.Id("loginusername")).SendKeys("shakeerbasha");
            driver.FindElement(By.Id("loginpassword")).SendKeys("shakeer12345");
            driver.FindElement(By.CssSelector("button[onclick='logIn()")).Click();
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("logout2")));
            driver.FindElement(By.LinkText("Iphone 6 32gb")).Click();
            driver.FindElement(By.XPath("//a[normalize-space()='Add to cart']")).Click();
            driver.FindElement(By.XPath("//li[@class='nav-item'][3]")).Click();
            driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();
            driver.FindElement(By.Id("name")).SendKeys("RangaPrasad");
            driver.FindElement(By.Id("country")).SendKeys("India");
            driver.FindElement(By.XPath("//input[@id='city']")).SendKeys("Banagalore");
            driver.FindElement(By.Id("card")).SendKeys("Rupay");
            driver.FindElement(By.Id("month")).SendKeys("November");
            driver.FindElement(By.Id("year")).SendKeys("2023");
            driver.FindElement(By.XPath("//button[@onclick='purchaseOrder()']")).Click();
            driver.FindElement(By.XPath("//button[@class='confirm btn btn-lg btn-primary']")).Click();
        }
        [Test]
        public void CancellingProduct()
        {
            driver.FindElement(By.Id("login2")).Click();
            driver.FindElement(By.Id("loginusername")).SendKeys("shakeerbasha");
            driver.FindElement(By.Id("loginpassword")).SendKeys("shakeer12345");
            driver.FindElement(By.CssSelector("button[onclick='logIn()")).Click();
            Thread.Sleep(1000);
           /* WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("logout2")));*/
            driver.FindElement(By.LinkText("Iphone 6 32gb")).Click();
            driver.FindElement(By.XPath("//a[normalize-space()='Add to cart']")).Click();
            driver.FindElement(By.XPath("//li[@class='nav-item'][3]")).Click();
            driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();
            driver.FindElement(By.Id("name")).SendKeys("RangaPrasad");
            driver.FindElement(By.Id("country")).SendKeys("India");
            driver.FindElement(By.XPath("//input[@id='city']")).SendKeys("Banagalore");
            driver.FindElement(By.Id("card")).SendKeys("Rupay");
            driver.FindElement(By.Id("month")).SendKeys("November");
            driver.FindElement(By.Id("year")).SendKeys("2023");
            driver.FindElement(By.CssSelector("div[id='orderModal'] div[class='modal-footer'] button:nth-child(1)")).Click();
        }
        [TearDown] 
        public void TeardownBrowser()
        {
            driver.Quit();
        }
    }
}
