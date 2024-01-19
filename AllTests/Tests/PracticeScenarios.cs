

using System.ComponentModel.DataAnnotations;
using System.Drawing;
using AllTests.Utilities;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace AllTests.Tests
{
    
    public class PracticeScenarios:BaseClass
    {
        //WebBrowserCommands
        [Test]
        public void Test1()
        {
            string title;
            int length;
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.LinkText("Gmail")).Click();
            title = driver.Title;
            length=title.Length;
            TestContext.Progress.WriteLine("Title of gmail" + title);
            TestContext.Progress.WriteLine("length of gmail" + length);
            driver.Navigate().Back();
            title = driver.Title;
            length = title.Length;
            TestContext.Progress.WriteLine("Title of Google" + title);
            TestContext.Progress.WriteLine("length of Google" + length);
            driver.Navigate().Forward();
            title = driver.Title;
            length = title.Length;
            TestContext.Progress.WriteLine("length of Gmail" + length);
            driver.Navigate().Refresh();
            driver.Quit();
        }
        [Test]
        public void Test2() 
        {
            driver.Url = "https://www.facebook.com/";
            driver.FindElement(By.Id("email")).SendKeys("praveenachari555@gmail.com");
            driver.FindElement(By.Id("pass")).SendKeys("Praveen@8810");
            driver.FindElement(By.Name("login")).Click();
        }
        [Test]
        public void Test3()
        {
            
            driver.Url = "https://selenium08.blogspot.com/2019/07/check-box-and-radio-buttons.html";
            IWebElement red = driver.FindElement(By.XPath("//input[@value='red']"));
            if(red.Displayed)
            {
                Console.WriteLine("red button is displayed");
            }
            if(!red.Selected)
            {
                Console.WriteLine("red button is not Selected");
            }
        }
        [Test]
        public void Test4()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            /*IList<IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement radioButton in rdos)
            {
                if (radioButton.GetAttribute("value").Equals("user"))
                {
                    radioButton.Click();
                }
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();*/
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByValue("teach");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.Name("signin")).Click();
        }
        [Test]
        public void FramesTest()
        {
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            IWebElement frameScroll=driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", frameScroll);
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("Practice")).Click();
            //driver.FindElement(By.XPath("//a[contains(@class,'btn-min-block')]")).Click();
        }
        [Test]
        public void WindowHandlesTest()
        {
            String email = "mentor@rahulshettyacademy.com";
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2,driver.WindowHandles.Count);
            string childWindowName = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);
            String text= driver.FindElement(By.CssSelector(".red")).Text;
            String[] splittedText=text.Split("at");
            String[] trimmedString= splittedText[1].Trim().Split(" ");
           /* Assert.AreEqual(email, trimmedString);
            Console.WriteLine(email);*/
        }
    }
}
