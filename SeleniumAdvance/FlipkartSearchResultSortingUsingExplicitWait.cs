using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class FlipkartSearchResultSortingUsingExplicitWait
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
        public void Flipkart_Search_Results_Print_Using_Explict_Wait_And_With_Sorting()
        {

            IWebElement closebutton = driver.FindElement(By.XPath("//button[contains(text(),'✕')]"));
            closebutton.Click();

            IWebElement searcbox = driver.FindElement(By.XPath("//input[@type='text' and @name='q']"));
            searcbox.SendKeys("iphone");

            IWebElement searchicon = driver.FindElement(By.XPath("//button[@type='submit']"));
            searchicon.Click();

            ReadOnlyCollection<IWebElement> searchresults = driver.FindElements(By.XPath("//div[contains(@class,'row')"));

            for (int i = 0; i < 25; i++)
            {
                IWebElement searchresult = searchresults[i];

                string name = searchresult.FindElement(By.XPath("./div/div")).Text;

                string price = searchresult.FindElement(By.XPath("//div[@class='_30jeq3 _1_WHN1']")).Text;


            }



        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
