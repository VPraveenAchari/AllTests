using AllTests.Utilities;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AllTests.Tests
{
    [AllureNUnit]
    public class RedBus:BaseClass
    {
        [Test]
        public void ReBusTest()
        {
            driver.Url = "https://www.redbus.in/";
            driver.FindElement(By.XPath("//input[@id='src']")).SendKeys("Bang");
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//text[text()='Bangalore']")));
            driver.FindElement(By.XPath("//text[text()='Bangalore']")).Click();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("Kur");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//text[text()='Kurnool']")));
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//text[text()='Kurnool']")).Click();
            driver.FindElement(By.XPath("//div[@class='DatePicker__MainBlock-sc-1kf43k8-1 hHKFiR']//child::div[@class='DayNavigator__IconBlock-qj8jdz-2 iZpveD'][3]")).Click();
            driver.FindElement(By.XPath("//span[text()='12']")).Click();
            driver.FindElement(By.XPath("//button[@id='search_button']")).Click();
            Thread.Sleep(3000);
        }
    }
}
