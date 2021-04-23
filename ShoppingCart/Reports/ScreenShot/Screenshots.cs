using OpenQA.Selenium;
using System.Threading;

namespace ShoppingCart.Reports.ScreenShot
{
    public class Screenshots
    {
        private readonly IWebDriver driver;
        public string screenshotsFile;
        int count = 1;

        public Screenshots(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Screenshot(IWebDriver driver, string file)
        {
            ITakesScreenshot print = driver as ITakesScreenshot;
            var picture = print.GetScreenshot();
            picture.SaveAsFile(file, ScreenshotImageFormat.Png);
        }

        public void ToImage()
        {
            screenshotsFile = @"C:\Users\grace.torres\source\repos\SELENIUM\ShoppingCart\screenshot\";
            Screenshot(driver, screenshotsFile + "Image_" + count++ + ".png");
            Thread.Sleep(1000);
        }
    }
}
