using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class GoogleSearchWithExplicitWait
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test, Category("GoogleTest")]
        public void Google_Search_Suggestions_Print_Using_Explict_Wait()
        {

            string searchString = "selenium";

            IWebElement searchbox = driver.FindElement(By.Name("q"));

            searchbox.SendKeys(searchString);

            List<IWebElement> autosuggestions = driver.FindElements(By.XPath("//form//ul//li")).ToList<IWebElement>();

            Console.WriteLine(autosuggestions.Count);

            IWebElement firstsuggestions = driver.FindElement(By.XPath("//form//ul//li"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(firstsuggestions, searchString));


            //customExpected condition

            Func<IWebDriver, bool> customcondition = new Func<IWebDriver, bool>(

                (IWebDriver browser) =>
                {
                    Console.WriteLine("Inside custom condition");

                    bool result = true;

                    List<IWebElement> suggestion = browser.FindElements(By.XPath("//form//ul//li")).ToList<IWebElement>();

                    if (suggestion.Count < 10)
                    {
                        result = false;
                    }
                    return result;

                }


                );

            wait.Until(customcondition);


            foreach (var suggestion in autosuggestions)
            {
                Console.WriteLine("suggestion: " + suggestion.Text);
            }

            //TakeScreenShot(@"C:\Users\UJ56\Desktop\SelniumTraining\EurofinsJul2021\ScreenShots");

            Utility.TakeScreenShot(driver, @"C:\Users\UJ56\Desktop\SelniumTraining\EurofinsJul2021\ScreenShots");

        }

        public void TakeScreenShot(string path)
        {
            string datetimestamp = DateTime.Now.Ticks.ToString();

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            ss.SaveAsFile(path+datetimestamp+ ".Jpeg", ScreenshotImageFormat.Jpeg);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
