using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class RediffCheckboxTest
    {

        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://register.rediff.com/register/register.php");
        }


        [Test]
        public void Click_On_Check_Box_Alt_Email_Disappaers()
        {
            IWebElement alternateemailaddress = driver.FindElement(By.XPath("//input[@type='text' and starts-with (@name,'altemail')]"));

            IWebElement checkbox = driver.FindElement(By.XPath("//input[@type='checkbox' and starts-with (@name,'chk_altemail')]"));

            if (!checkbox.Selected)
            {
                checkbox.Click();

            }

            Assert.IsTrue(checkbox.Selected);
            Assert.IsFalse(alternateemailaddress.Displayed);

        }



        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(5000);
            driver.Close();
        }

    }
}
