using OpenQA.Selenium;
using Task3.Core.Core;

namespace Task3.Core.UI.Pages
{
    public class JobDetailPage : BasePage
    {
        public JobDetailPage()
        {
        }

        public IWebElement WhatYouHaveSection => DriverHelper.GetElement(By.XPath("//h3[contains(text(),'What You Have')]/following-sibling::ul/li"));

        public string GetTextFromWhatYouHaveSection()
        {
            return WhatYouHaveSection.Text;
        }
    }
}
