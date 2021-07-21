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
    class GoogleSearchUsingCSV
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

        public void Google_Search_From_CSV(string search, string result)
        {

            IWebElement searchbox = driver.FindElement(By.Name("q"));

            searchbox.SendKeys(search);

            searchbox.SendKeys(Keys.Enter);

            string actualTitle = driver.Title;

            Assert.That(driver.Title, Does.Contain(search));

        }



        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }


    }
}
