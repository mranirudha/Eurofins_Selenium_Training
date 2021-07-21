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
    class GoogleSearch
        
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //Arrange
            //Open a browser
            //Navigate to URL

            //IWebDriver driver = new ChromeDriver("C:\\Tools\\Selenium");

            //other way is by adding @ symbol

            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.google.com");
        }

        [Test,Category("GoogleTest")]
        public void When_GoogleSearch_Then_SuccessfulResult()
        {
            //Act
            //Enter the search string

            IWebElement searchbox = driver.FindElement(By.Name("q"));

            string searchString = "selenium";


            searchbox.SendKeys(searchString);

            //Hit the enter key

            searchbox.SendKeys(Keys.Enter);




            //Assert
            //verify the title contains the searchstring

            string actualTitle = driver.Title;

           // Assert.Contains(actualTitle, "selenium");

            Assert.That(driver.Title,Does.Contain(searchString));

            /*

            if (actualTitle.Contains("selenium"))
            {
                Console.WriteLine("Test 1 Passed");
            }else
            {
                Console.WriteLine("Test 1 Failed");
            }
            */


            //first link in the result page should contain searchstring

            // IWebElement firstsearchresult = driver.FindElement(By.ClassName("LC20lb DKV0Md"));

            IWebElement firstsearchresult = driver.FindElement(By.TagName("h3"));

            Assert.That(firstsearchresult.Text.ToLower, Does.Contain(searchString));

            Assert.That(firstsearchresult.Text, Does.Contain(searchString).IgnoreCase);

            Assert.Pass(firstsearchresult.Text, searchString, StringComparison.OrdinalIgnoreCase);

        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
