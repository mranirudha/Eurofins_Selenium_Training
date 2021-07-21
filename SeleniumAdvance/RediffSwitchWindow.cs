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
    class RediffSwitchWindow
    {

        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://register.rediff.com/register/register.php");
        }

        [Test]
        public void Rediff_Work_On_Multiple_Windows()
        {
            driver.FindElement(By.LinkText("terms and conditions")).Click();

            driver.FindElement(By.PartialLinkText("policy")).Click();

            IReadOnlyCollection<string> handels =driver.WindowHandles;

            Console.WriteLine("No of open windows : " + handels.Count);

            foreach(string handel in handels)
            {
                driver.SwitchTo().Window(handel);

                if (driver.Title.Contains("Terms"))
                {
                    Console.WriteLine("Switched to --> Terms and Conditions window");
                    break;
                }
            }


            IWebElement header1 = driver.FindElement(By.XPath("//div[@class='header']/div[1]"));

            Assert.AreEqual(header1.Text, "Terms and Conditions");



            foreach (string handel in handels)
            {
                driver.SwitchTo().Window(handel);

                if (driver.Title.Contains("Welcome"))
                {
                    Console.WriteLine("Switched to --> Rediff.com India Ltd. - Privacy Policy");
                    break;
                }
            }


            //IWebElement header2 = driver.FindElement(By.CssSelector("tr[bgcolor='#DEDEDE'] b"));

            IWebElement header2 = driver.FindElement(By.XPath("//b[contains(text(),'Rediff.com India Ltd. - Privacy Policy')]"));
            
            Assert.AreEqual(header2.Text, "Rediff.com India Ltd. - Privacy Policy");

        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();

            driver.Quit();
           
        }


    }
}
