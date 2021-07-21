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
    class RediffHandelJavaScriptPopUps
    {

        class RediffAccountCreate
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
            public void Rediff_Work_On_Java_Script_PopUps()
            {
                driver.FindElement(By.XPath("//input[@class='submitbtn' and @id='Register']")).Click();

                //Utility.TakeScreenShot(driver,@"C:\Users\UJ56\Desktop\SelniumTraining\EurofinsJul2021\ScreenShots");

                IAlert popupalert = driver.SwitchTo().Alert();

                string popuptext = popupalert.Text;

                Assert.That(popuptext, Does.Contain("Your full name cannot be blank").IgnoreCase);

                Thread.Sleep(3000);

                popupalert.Accept();



            }


            [TearDown]
            public void TearDown()
            {

                driver.Close();
            }



        }

    }

}
