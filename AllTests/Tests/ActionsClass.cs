using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllTests.Utilities;
using AngleSharp.Dom;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager.DriverConfigs.Impl;

namespace AllTests.Tests
{
    [AllureNUnit]
    public class ActionsClass:BaseClass
    {
        [Test]
        public void Test() 
        {
            driver.Url = "https://www.jntua.ac.in/";
            IWebElement element = driver.FindElement(By.LinkText("Directorates"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Build().Perform();
            driver.FindElement(By.XPath("//h6[text()='EXAMINATIONS']")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,900)", "");
            driver.FindElement(By.XPath("//td[text()='Cat']/preceding-sibling::td/child::input")).Click();
            IWebElement wb = driver.FindElement(By.XPath("//button[@ondblclick='myFunction()']"));
            actions.DoubleClick(wb).Perform();
            driver.SwitchTo().Alert().Accept();
        }
    }
}
