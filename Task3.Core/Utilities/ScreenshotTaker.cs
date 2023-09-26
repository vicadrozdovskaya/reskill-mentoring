using OpenQA.Selenium;
using Task3.Core.Core;

namespace Task3.Core.Utilities
{
    public static class ScreenshotTaker
    {
       

        public static string TakeScreenshot(string directory, string testName)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string screenshotFileName =
                string.Format(
                    "{0}_{1}.{2}",
                    testName,
                    DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss"),
                    ScreenshotImageFormat.Jpeg.ToString().ToLowerInvariant())
                      .Replace("\"", string.Empty)
                      .Replace("\\", string.Empty);

            string screenshotSaveFullPath = Path.Combine(directory, screenshotFileName);

            Screenshot screenshot = ((ITakesScreenshot)DriverHolder.GetInstance()).GetScreenshot();
            screenshot.SaveAsFile(screenshotSaveFullPath);
            
            return screenshotSaveFullPath;
        }
    }
}
