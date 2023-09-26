using OpenQA.Selenium;
using Task3.Core.Core;

namespace Task3.Core.UI.Pages
{
    public class AboutPage : BasePage
    {
        public IWebElement DownloadBtn => DriverHelper.GetElement(By.XPath("//span[contains(text(),'DOWNLOAD')]"));

    }
}
