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
    class EasemyTripWithImplicitWait
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://www.easemytrip.com/");
        }

        [Test]
        public void Fill_EaseMyTrip_Booking_Form()
        {
            driver.FindElement(By.XPath("(//input[@class='src_btn'])[1]")).Click();

            driver.FindElement(By.XPath("//button[text()='Book Now']")).Click();


            Assert.IsNotNull(driver.FindElement(By.XPath("//span[text()='Price Summary']")));



        }


        [TearDown]
        public void TearDown()
        {

            driver.Close();
        }

    }
}
