using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class FlipkartSearchSuggestionsPrint
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
        public void Search_Suggestions_Print()
        {
            IWebElement closebutton = driver.FindElement(By.XPath("//button[contains(text(),'✕')]"));
            closebutton.Click();

            IWebElement searcbox = driver.FindElement(By.XPath("//input[@type='text' and @name='q']"));
            searcbox.SendKeys("iphone");






            //IReadOnlyCollection<IWebElement> listofresults = driver.FindElements(By.XPath("//ul[@class='col-12-12 _1MRYA1 _38UFBk']//li"));

            //Thread.Sleep(5000);   

            IReadOnlyCollection<IWebElement> listofresults = driver.FindElements(By.CssSelector("form li"));


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("form li"),"iphone"));



            string autosuggections;

            foreach (IWebElement webElement in listofresults)
            {
                autosuggections = webElement.Text;
                Console.WriteLine(autosuggections);
            }




        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
