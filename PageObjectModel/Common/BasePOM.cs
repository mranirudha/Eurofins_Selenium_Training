using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Common
{
    class BasePOM
    {

        public static IWebDriver driver;

        public BasePOM()
        {
            LaunchBrowser("chrome");
        }

        public void LaunchBrowser(string browsername)
        {
            if (browsername.Contains("chrome"))
            {
                driver = new ChromeDriver(@"C:\Tools\Selenium");

            }

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //driver.Navigate().GoToUrl("https://www.flipkart.com/");
        }


    }
}
