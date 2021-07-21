using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class GoogleGrid
    {

        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.google.com");
        }

        [Test]
        public void Count_Number_Of_Items_Inside_Grid()
        {
            driver.FindElement(By.ClassName("gb_Ve")).Click();

            driver.SwitchTo().Frame(0);

            Thread.Sleep(20000);

            IReadOnlyCollection<IWebElement> allApps = driver.FindElements(By.ClassName("j1ei8c"));

            //IReadOnlyCollection<IWebElement> allApps = driver.FindElements(By.TagName("li"));

            //IReadOnlyCollection<IWebElement> allApps = driver.FindElements(By.ClassName("Rq5Gcb"));


            // IReadOnlyCollection<IWebElement> allApps = driver.FindElements(By.id(""));


            //IReadOnlyCollection<IWebElement> allApps = driver.FindElements(By.XPath("//div[@id="yDmH0d"]//ul[1]/li"));

            int numberOfApps = allApps.Count;

            foreach (IWebElement everyApp in allApps)
            {
                Console.WriteLine(everyApp.Text);
            }

            Console.WriteLine("No of Element : " + numberOfApps);

            Assert.AreEqual(31, numberOfApps);


        }



        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
