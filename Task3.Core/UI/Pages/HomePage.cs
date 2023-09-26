using OpenQA.Selenium;
using Task3.Core.Core;
using Task3.Core.UI.Controls.ApplicationControls;

namespace Task3.Core.UI.Pages
{
    public class HomePage : BasePage
    {
        private string BaseUrl { get; set; } = "https://www.epam.com/";

        public HomePage()
        {
        }

        public IWebElement AcceptCookieBtn => DriverHelper.GetElement(By.Id("onetrust-accept-btn-handler"));
        public HeaderMenuControl headerMenu => new HeaderMenuControl(DriverHelper.GetElement(By.CssSelector(".header__inner")));

        public void GoToPage()
        {
            DriverHolder.GetInstance().Navigate().GoToUrl(BaseUrl);
        }
        public void SetTextInSearchInput(string text)
        {
            headerMenu.SearchInput.SendKeys(text);
        }

    }
}

