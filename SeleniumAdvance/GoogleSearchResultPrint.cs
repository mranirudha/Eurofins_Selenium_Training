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
    class GoogleSearchResultPrint
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
        public void Count_Number_Of_search_Results()
        {
            IWebElement searchbox = driver.FindElement(By.Name("q"));

            string searchString = "Selenium";

            searchbox.SendKeys(searchString);

            searchbox.SendKeys(Keys.Enter);

            //IWebElement listofresults = driver.FindElement(By.Id("rso"));

            // IReadOnlyCollection<IWebElement> listofresults = driver.FindElements(By.Id("rso"));

            IReadOnlyCollection<IWebElement> listofresults = driver.FindElements(By.ClassName("yuRUbf"));

            //IReadOnlyCollection<IWebElement> listofresults = driver.FindElements(By.ClassName("tF2Cxc"));

           // IReadOnlyCollection<IWebElement> listofresults = driver.FindElements(By.XPath("//h3[@class = 'LC20lb DKV0Md']"));

            int nooflinks = listofresults.Count;

            foreach (IWebElement links in listofresults)
            {

                Console.WriteLine(links.Text);

            }

            Console.WriteLine("No of Element : " + nooflinks);


        }



        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }



    }
}
