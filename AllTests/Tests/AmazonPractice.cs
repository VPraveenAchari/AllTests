using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllTests.Utilities;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AllTests.Tests
{
    [AllureNUnit]
    public class AmazonPractice:BaseClass
    {
        [Test]
        public void Test()
        {
            driver.Url = "https://www.amazon.in/";
            driver.FindElement(By.XPath("//div[@id='nav-tools']/a[2]")).Click();
            driver.FindElement(By.Id("ap_email")).SendKeys("praveenachari555@gmail.com");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            //driver.FindElement(By.LinkText("Forgot Password")).Click();
            driver.FindElement(By.Id("ap_password")).SendKeys("praveen8810");
            driver.FindElement(By.Id("signInSubmit")).Click();
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("sma");
            driver.FindElement(By.XPath("//div[@aria-label='smart watch for men']")).Click();

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500)");
            driver.FindElement(By.Id("nav-hamburger-menu")).Click();
            driver.FindElement(By.LinkText("Sign Out")).Click();
        }
        [Test]
        public void SearchBook()
        {
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            IList<IWebElement> products=driver.FindElements(By.XPath("//div[contains(@id,'desktop-grid')]"));
            foreach(IWebElement element in products)
            {
                string product = element.Text;
                TestContext.Progress.WriteLine(product);
            }
        }
    }
}
