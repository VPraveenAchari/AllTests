using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using NUnit.Allure.Core;

namespace AllTests.Tests
{
    [AllureNUnit]
    public class CalenderControls
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Url = "https://www.hyrtutorials.com/p/calendar-practice.html";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        }
        /*
         * Select a date in the current year and current month
         * how to validate the user input
         * select a past date
         * select a future date
         * Create a utility function for handling calenders
         */
        [Test]
        public void CalenderSelection()
        {
            driver.FindElement(By.Id("first_date_picker")).Click();
            int day = 10;
            driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']//a[text()=" + day + "]")).Click();

            //SecondCalender
            /*driver.FindElement(By.Id("second_date_picker")).Click();
            int day = 1;
            driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']//td[not(contains(@class,' ui-datepicker-other-month '))]/a[text()=" + day + "]")).Click();*/

        }
    }
}
