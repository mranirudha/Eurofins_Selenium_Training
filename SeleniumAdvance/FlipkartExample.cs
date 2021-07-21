using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SeleniumAdvance
{
    class FlipkartExample
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.flipkart.com/");
        }

        [Test]
        public void Search_Reults_With_Price()
        {

             IWebElement closebutton = driver.FindElement(By.XPath("//button[contains(text(),'✕')]"));
             closebutton.Click();

            //IWebElement closebutton = driver.FindElement(By.XPath("(//button)[2]"));
            // IWebElement closebutton = driver.FindElement(By.XPath("//button[@class='_2KpZ6l _2doB4z']")); //using calss name
           
            //IWebElement closebutton = driver.FindElement(By.XPath("//button[.='✕')]"));

            IWebElement searcbox = driver.FindElement(By.XPath("//input[@type='text' and @name='q']"));
            searcbox.SendKeys("iphone");

            IWebElement searchicon = driver.FindElement(By.XPath("//button[@type='submit']"));
            searchicon.Click();

            Thread.Sleep(5000);


            ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//div[contains(@class,'row')"));


            //IReadOnlyCollection<IWebElement> listoftitle = driver.FindElements(By.XPath("//div[@class='_2kHMtA']//div[@class='_3pLy-c row']//div[@class='_4rR01T']"));
            //IReadOnlyCollection<IWebElement> listofprice = driver.FindElements(By.XPath("//div[@class='_2kHMtA']//div[@class='_30jeq3 _1_WHN1']"));
            


            for(int i=0;i<25;i++)
            {
                IWebElement row = rows[i];

                //string name = row.FindElement(By.XPath("./div/div")).Text;

                string name = row.FindElement(By.XPath("//div[@class='_4rR01T']")).Text;

                //string price = row.FindElement(By.XPath("./div[2]/div/div/div")).Text;

                string price = row.FindElement(By.XPath("//div[@class='_30jeq3 _1_WHN1']")).Text;

                Console.WriteLine(name +":"+ price);

            }



        }



        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }


    }
}
