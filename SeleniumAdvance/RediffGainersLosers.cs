using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class RediffGainersLosers
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://www.rediff.com/");
        }

        [Test]
        public void Rediff_Gainers_Looser_Page_Print_Company_Name_Where_Price_Less_Than_100()
        {
            IWebElement moneylink = driver.FindElement(By.XPath("//a[@class='moneyicon relative']"));
            moneylink.Click();

            IWebElement gainerloserslink = driver.FindElement(By.XPath("//a[contains(text(),'Gainers / Losers')]"));
            gainerloserslink.Click();

            //ReadOnlyCollection<IWebElement> allrecords= driver.FindElements(By.XPath("//body/div[@id='wrapper']/div[@id='leftcontainer']/table[1]"));

            //ReadOnlyCollection<IWebElement> allrecords = driver.FindElements(By.XPath("//table[@class='datatable']//tbody//tr"));--//table[@class='dataTable']

            ReadOnlyCollection<IWebElement> allrecords = driver.FindElements(By.XPath("table[@class='dataTable']"));

            IWebElement table = driver.FindElement(By.CssSelector("table.dataTable"));

            IReadOnlyList<IWebElement> rows = table.FindElements(By.XPath("./tbody/tr"));

            for (int i = 0; i < 10; i++)
            {
                IWebElement row = rows[i];

                string currentprice = row.FindElement(By.XPath("./td[4]")).Text;

                float price = float.Parse(currentprice);

                if (price < 100)
                {
                    string companyname = row.FindElement(By.XPath("./td[1]")).Text;

                    Console.WriteLine(companyname + ":" + price);
                }

            }

        }



        [TearDown]
        public void TearDown()
        {
            
            driver.Close();
        }

    }
}
