

using AllTests.Utilities;
using OpenQA.Selenium;

namespace AllTests.Tests
{
    public class MagnetTo:BaseClass
    {
        [Test]
        public void MagnetTest()
        {
            driver.Url = "https://magento.softwaretestingboard.com/";
            driver.FindElement(By.XPath("//li[@class='authorization-link']/a")).Click();
            driver.FindElement(By.Id("email")).SendKeys("haribabu@gmail.com");
            driver.FindElement(By.Id("pass")).SendKeys("Haribabu5060");
            driver.FindElement(By.Id("send2")).Click();
        }
    }
}
