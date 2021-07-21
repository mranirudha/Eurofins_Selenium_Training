using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDrivenTests
{
    class GoogleSearch
        
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
          
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.google.com");
        }


        public static List<TestCaseData> TestInputs()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\UJ56\Desktop\SelniumTraining\EurofinsJul2021\TestData\GoogleSearchData.csv"));

            var testdata = new List<TestCaseData>();

            while (!reader.EndOfStream)
            {
                char sepatator = ',';

                var line = reader.ReadLine();

                string[] words = line.Split(sepatator);

                testdata.Add(new TestCaseData(words[0], words[1]));
            }

            return testdata;

        }


        [Category("DataDrivenFromCSV")]
        [TestCaseSource("TestInputs")]

        public void Google_Search_Using_CSV(string search,string result)
        {

            Console.WriteLine(search+":"+result);

        }


        [Category("DataDrivenGoogleTest")]

        [TestCase("selenium")]

        [TestCase("iphone")]

        [TestCase("samsung")]

        [TestCase("nokia")]

        public void When_GoogleSearch_Then_SuccessfulResult(string searchstring)
        {
           
            IWebElement searchbox = driver.FindElement(By.Name("q"));

            //string searchString = "selenium";

            searchbox.SendKeys(searchstring);

        
            searchbox.SendKeys(Keys.Enter);


            string actualTitle = driver.Title;

            Assert.That(driver.Title,Does.Contain(searchstring));

          

            IWebElement firstsearchresult = driver.FindElement(By.TagName("h3"));

            Assert.That(firstsearchresult.Text.ToLower, Does.Contain(searchstring));

            Assert.That(firstsearchresult.Text, Does.Contain(searchstring).IgnoreCase);

            Assert.Pass(firstsearchresult.Text, searchstring, StringComparison.OrdinalIgnoreCase);

        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
