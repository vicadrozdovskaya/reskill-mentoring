using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Task3.Core.Utilities.Browser;

namespace Task3.Core.Core
{
    public static class DriverHolder
    {
        private static IWebDriver? instance;

        public static IWebDriver GetInstance()
        {
            if (instance == null || ((WebDriver)instance).SessionId == null)
            {
                instance = BrowserFactory.InitializeBrowserDriver();
            }
            return instance;
        }  

    }
}
