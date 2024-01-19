using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using OpenQA.Selenium.Edge;

namespace AllTests.Utilities
{
    public class BaseClass
    {
        public IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            String browserName;
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);
           /* new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
            //driver.Url = "https://only-testing-blog.blogspot.com/";*/
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        }
        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown] 
        public void StopBrowser() 
        {
            driver.Quit();
        }
    }
}
