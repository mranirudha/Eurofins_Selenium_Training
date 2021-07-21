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
    class RediffAccountCreate
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
        public void Create_Rediff_account()
        {
            IWebElement fullname = driver.FindElement(By.XPath("//table//input[starts-with(@name,'name')]"));
            fullname.SendKeys("Anirudha Sahoo");

            IWebElement rediffmailid = driver.FindElement(By.XPath("//table//input[starts-with(@name,'login')]"));
            rediffmailid.SendKeys("anirudha.sahoo");

            IWebElement password = driver.FindElement(By.XPath("//table//input[starts-with(@name,'passwd')]"));
            password.SendKeys("password");

            IWebElement retypepassword = driver.FindElement(By.XPath("//table//input[starts-with(@name,'confirm_passwd')]"));
            retypepassword.SendKeys("password");

            IWebElement alternateemailaddress = driver.FindElement(By.XPath("//input[@type='text' and starts-with (@name,'altemail')]"));
            alternateemailaddress.SendKeys("anirudha_sahoo");

            IWebElement mobilenumber = driver.FindElement(By.XPath("//input[@type='text' and starts-with (@name,'mobno')]"));
            mobilenumber.SendKeys("1234567890");

            //one way of selecting date -month-year is as below

          //  driver.FindElement(By.XPath("//option[text()='02']")).Click();
            //driver.FindElement(By.XPath("//option[text()='JUL']")).Click();
            //driver.FindElement(By.XPath("//option[text()='1985']")).Click();


            //another way of selecting date -month-year is as below

            SelectElement day = new SelectElement(driver.FindElement(By.XPath("//select[starts-with(@name,'DOB_Day')]")));
            
            day.SelectByText("02");

            SelectElement month = new SelectElement(driver.FindElement(By.XPath("//select[starts-with(@name,'DOB_Month')]")));

            day.SelectByText("JUL");

            SelectElement year = new SelectElement(driver.FindElement(By.XPath("//select[starts-with(@name,'DOB_Year')]")));

            day.SelectByText("1985");

            IWebElement actual_year = year.SelectedOption;
            Assert.AreEqual(actual_year, "1985");


        }



        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(5000);
            driver.Close();
        }
    }
}
