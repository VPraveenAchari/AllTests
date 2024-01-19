using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using AllTests.Utilities;
using NUnit.Framework;
using NUnit.Allure.Core;
using OpenQA.Selenium.Support.UI;

namespace AllTests.Tests
{
    [AllureNUnit]
    public class NopCommerce
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Url = "https://demo.nopcommerce.com/";
            driver.Manage().Window.Maximize();
        }
        
        [Test]
        public void NopCommerceTest()
        {
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("haribabu@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("haribabu5060");
            driver.FindElement(By.XPath("//div[@class='buttons']/button[@type='submit']")).Click();
            //driver.FindElement(By.XPath("//input[@name='q']")).SendKeys("Nokia Lumia 1020");
            driver.FindElement(By.XPath("//input[@name='q']")).SendKeys("hat");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.XPath("//div[@class='picture']/a/img")).Click();
            bool result=driver.FindElement(By.XPath("//div[@class='picture']/a/img")).Displayed;
            TestContext.WriteLine(result);
            driver.FindElement(By.XPath("//div[@class='add-to-cart-panel']/input")).SendKeys("3");
            Thread.Sleep(1000);
            IWebElement d = driver.FindElement(By.Id("product_attribute_13"));
            SelectElement element = new SelectElement(d);
            element.SelectByText("Medium");
            Thread.Sleep(3000);
        }
        [TearDown] 
        public void TearDown() 
        {
            driver.Quit();
        }
    }
}
