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
    class GoogleAbsoluteXPathExample
    {

        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.google.com");
        }

        [Test, Category("GoogleTest")]

        public void Test_Google_With_Xpath()
        {

            IWebElement searchbox = driver.FindElement(By.XPath("/html/body/div/div[3]/form/div/div/div/div/div[2]/input"));

            string searchString = "selenium";

            searchbox.SendKeys(searchString);          

            searchbox.SendKeys(Keys.Enter);


        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
