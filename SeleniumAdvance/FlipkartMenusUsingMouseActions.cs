using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class FlipkartMenusUsingMouseActions
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
        public void Navigating_Menus_Using_Actions_Class()
        {

            IWebElement closebutton = driver.FindElement(By.XPath("//button[contains(text(),'✕')]"));
            
            Assert.IsNotNull(closebutton);

            closebutton.Click();

            IWebElement fashionlink = driver.FindElement(By.CssSelector("img[alt='Fashion']"));

            Actions myaction = new Actions(driver);

            myaction.MoveToElement(fashionlink);

            IAction action = myaction.Build();

            action.Perform();

            Thread.Sleep(2000);

            Utility.TakeScreenShot(driver, @"C:\Users\UJ56\Desktop\SelniumTraining\EurofinsJul2021\ScreenShots\FashionLink_");

            IWebElement menstopwear = driver.FindElement(By.XPath("//a[text()=\"Men's Top Wear\"]"));
           
            Assert.IsTrue(menstopwear.Displayed);

            IWebElement electronic = driver.FindElement(By.XPath("//img[@class='_396cs4 _3exPp9' and @alt='Electronics']"));

            new Actions(driver).MoveToElement(electronic).Build().Perform();

            Thread.Sleep(2000);

            Utility.TakeScreenShot(driver, @"C:\Users\UJ56\Desktop\SelniumTraining\EurofinsJul2021\ScreenShots\Electronics_");

        }

        [Test]
        public void Use_Shift_Key_Open_New_Window()
        {
            IWebElement fashionlink = driver.FindElement(By.CssSelector("img[alt='Fashion']"));

            Actions myaction = new Actions(driver);

            //myaction.MoveToElement(fashionlink);

            //IAction action = myaction.Build();

            new Actions(driver).MoveToElement(fashionlink).Build().Perform();

            Utility.TakeScreenShot(driver, @"C:\Users\UJ56\Desktop\SelniumTraining\EurofinsJul2021\ScreenShots\Fashon22222_");

            Thread.Sleep(5000);


            IWebElement menstopwear = driver.FindElement(By.XPath("//a[text()=\"Men's Top Wear\"]"));

            myaction.KeyDown(Keys.Shift).Build().Perform();

            myaction.Click(menstopwear).Build().Perform();


        }



        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
