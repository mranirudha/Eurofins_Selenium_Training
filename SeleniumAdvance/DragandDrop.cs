using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class DragandDrop
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://jqueryui.com/slider/");
        }

        [Test]
        public void Drag_And_Drop_Example()
        {
            driver.SwitchTo().Frame(0);

            IWebElement slider = driver.FindElement(By.Id("slider"));

            IWebElement handel = driver.FindElement(By.CssSelector("#slider span"));

            int sliderwidth = slider.Size.Width;

            Actions myaction = new Actions(driver);

            myaction.DragAndDropToOffset(handel,sliderwidth/2,0);

            myaction.Build().Perform();


            string actual = handel.GetAttribute("style");

            string expected = "left: 50%;";

            Assert.AreEqual(actual, expected);

            Utility.TakeScreenShot(driver, @"C:\Users\UJ56\Desktop\SelniumTraining\EurofinsJul2021\ScreenShots\DragDrop_");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }


    }
}
