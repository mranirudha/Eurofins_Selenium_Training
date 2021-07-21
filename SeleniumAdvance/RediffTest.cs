using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class RediffTest
    {

        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.rediff.com/");
        }

        [Test]

        public void When_Login_With_Incorrect_Email_Then_Should_Get_Error()
        {
            driver.FindElement(By.LinkText("Rediffmail")).Click();

            driver.FindElement(By.Id("login1")).SendKeys("test");

            driver.FindElement(By.Name("passwd")).SendKeys("test");

            driver.FindElement(By.Name("proceed")).Click();

            Assert.That(driver.FindElement(By.Id("div_login_error")).Text, Does.Contain("Wrong username and password combination.").IgnoreCase);


        }



        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
