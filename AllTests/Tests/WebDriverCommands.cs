using System.Xml.Linq;
using AllTests.Utilities;
using OpenQA.Selenium;

namespace AllTests.Tests
{
    public class WebDriverCommands:BaseClass
    {
        [Test]
        public void GetCommands()
        {
            //driver.Url=  "https://www.demoblaze.com/";
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            string title =driver.Title;
            string url=driver.Url;
            TestContext.Progress.WriteLine("Title is"+title);
            TestContext.Progress.WriteLine("Url of the webpage"+url);
        }
    }
}
