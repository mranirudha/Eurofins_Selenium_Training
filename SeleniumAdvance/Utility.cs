using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvance
{
    class Utility
    {

        public static void TakeScreenShot(IWebDriver driver, string path)
        {
            string datetimestamp = DateTime.Now.Ticks.ToString();

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            ss.SaveAsFile(path+datetimestamp + ".Jpeg", ScreenshotImageFormat.Jpeg);

        }

    }
}
