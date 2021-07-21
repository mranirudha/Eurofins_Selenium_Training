
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasics
{
    class NavigationExample
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\Tools\\Selenium");

            driver.Manage().Window.Maximize();

            driver.Url = "https://www.google.com";

            string actualTitle = driver.Title;

            string actualURL = driver.Url;

            Console.WriteLine("Navigate To : "+ actualTitle+":"+actualURL);

            if (actualTitle.Contains("Google"))
            {
                Console.WriteLine("Test 1 Passed : Navigated to Google.com");
            }

            driver.Navigate().GoToUrl("https://www.amazon.com");

            Console.WriteLine("Navigate To : " + driver.Title + ":" + driver.Url);

            if (driver.Title.Contains("Amazon"))
            {
                Console.WriteLine("Test 2 Passed : Navigated to Amazon.com");
            }

            driver.Navigate().GoToUrl("https://www.flipkart.com");

            Console.WriteLine("Navigate To : " + driver.Title + ":" + driver.Url);

            if (driver.Title.Contains("Flipkart"))
            {
                Console.WriteLine("Test 3 Passed : Navigated to Flipkart.com");
            }

            driver.Navigate().Back();

            Console.WriteLine("Back Navigate To : " + driver.Title + ":" + driver.Url);

            driver.Navigate().Refresh();

            Console.WriteLine("Refresh Navigate To : " + driver.Title + ":" + driver.Url);

            driver.Navigate().Back();

            Console.WriteLine("Back Navigate To : " + driver.Title + ":" + driver.Url);

            driver.Navigate().Refresh();

            Console.WriteLine("Refresh Navigate To : " + driver.Title + ":" + driver.Url);

            driver.Navigate().Forward();

            Console.WriteLine("Forward Navigate To : " + driver.Title + ":" + driver.Url);

            driver.Navigate().Refresh();

            Console.WriteLine("Refresh Navigate To : " + driver.Title + ":" + driver.Url);


            // driver.Close();

            //driver.Quit();




        }
    }
}
