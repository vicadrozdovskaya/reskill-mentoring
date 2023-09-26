using OpenQA.Selenium;
using Task3.Core.Core;

namespace Task3.Core.UI.Pages
{
    public class InsightsArticlePage : BasePage
    {
        public IWebElement Title => DriverHelper.GetElement(By.ClassName("museo-sans-light"));

        public string GetTitleText()
        {
            return Title.Text.Trim();
        }
    }
}
