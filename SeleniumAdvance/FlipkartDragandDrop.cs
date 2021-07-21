using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class FlipkartDragandDrop
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://www.flipkart.com/");
        }

        [Test]
        public void Drag_Price_Range_In_Search_Reults_Page_Between_2000_5000()
        {

            IWebElement closebutton = driver.FindElement(By.XPath("//button[contains(text(),'✕')]"));

            Assert.IsNotNull(closebutton);

            closebutton.Click();

            IWebElement searcbox = driver.FindElement(By.XPath("//input[@type='text' and @name='q']"));
            searcbox.SendKeys("iphone");

            IWebElement searchicon = driver.FindElement(By.XPath("//button[@type='submit']"));
            searchicon.Click();

            IWebElement handel = driver.FindElement(By.XPath("//div[@class='_2IN3-t _1mRwrD']"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='_2IN3-t _1mRwrD']")));

            Actions myaction = new Actions(driver);

            myaction.DragAndDropToOffset(handel, 700, 0);

            myaction.Build().Perform();

           
        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
