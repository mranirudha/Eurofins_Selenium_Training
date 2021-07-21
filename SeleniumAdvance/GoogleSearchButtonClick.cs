using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class GoogleSearchButtonClick
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test, Category("GoogleTest")]
        public void Click_On_Google_Search_Button()
        {
            string searchString = "selenium";

            IWebElement searchbox = driver.FindElement(By.Name("q"));

            searchbox.SendKeys(searchString);

            IWebElement searcbutton= driver.FindElement(By.XPath("//input[@class='gNO89b' and @name='btnK']"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@class='gNO89b' and @name='btnK']")));

            searcbutton.Click();

        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
