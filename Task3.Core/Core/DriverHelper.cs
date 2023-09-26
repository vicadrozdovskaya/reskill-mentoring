using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task3.Core.Utilities.Browser;

namespace Task3.Core.Core
{
    public static class DriverHelper
    {
        public static readonly TimeSpan SECONDS_5 = TimeSpan.FromSeconds(5);
        public static readonly TimeSpan SECONDS_20 = TimeSpan.FromSeconds(20);

        public static IWebElement GetElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(DriverHolder.GetInstance(), SECONDS_5);
            wait.Until(driver => driver.FindElement(by).Displayed);
            return DriverHolder.GetInstance().FindElement(by);
        }

        public static List<IWebElement> GetElements(By by)
        {
            WebDriverWait wait = new WebDriverWait(DriverHolder.GetInstance(), SECONDS_5);
            wait.Until(driver => driver.FindElement(by).Displayed);
            return DriverHolder.GetInstance().FindElements(by).ToList();
        }
        public static void WaitFileDownloaded(string SeleniumDownloadPath, string fileName)
        {
            WebDriverWait wait = new WebDriverWait(DriverHolder.GetInstance(), TimeSpan.FromMinutes(1));
            bool fileExists;
            wait.Until(x => fileExists = File.Exists(SeleniumDownloadPath + "\\" + fileName));
        }
        public static void WaitForPageReload()
        {
            var initialSource = DriverHolder.GetInstance().PageSource;
            var currentSource = string.Empty;
            new WebDriverWait(DriverHolder.GetInstance(), SECONDS_20)
                .Until(drvr =>
                {
                    var tempSource = drvr.PageSource;
                    if (tempSource != initialSource && tempSource == currentSource)
                    {
                        return true;
                    }
                    currentSource = drvr.PageSource;
                    return false;
                });
        }
    }
}
