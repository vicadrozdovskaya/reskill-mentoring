using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Task3.Core.Utilities.Browser
{
    public static class BrowserFactory
    {
        private static string BinariesDirectory = "C:\\Users\\Viktoryia_Drazdouska\\source\\repos\\git\\reskill-mentoring\\Task3.Core\\Resources\\DriverBinaries";
        private static readonly string SeleniumDownloadPath = AppDomain.CurrentDomain.BaseDirectory + "\\Downloads";

        public static IWebDriver InitializeBrowserDriver()
        {
            switch (ConfigurationReader.BrowserType)
            {
                case Enums.BrowserType.Firefox:
                    return new FirefoxDriver();
                case Enums.BrowserType.Chrome:
                    return InitializeChrome();
                default:
                    throw new Exception("Unrecognizable Browser value was specified.");
                    
            }

        }
        public static IWebDriver InitializeChrome()
        {
            var options = new ChromeOptions();
            if (ConfigurationReader.HeadlessMode)
            {
                options.AddArgument("--headless");
            }
            options.AddUserProfilePreference("download.default_directory", SeleniumDownloadPath);

            return new ChromeDriver((BinariesDirectory), options, TimeSpan.FromSeconds(300));
        }
    }
}
