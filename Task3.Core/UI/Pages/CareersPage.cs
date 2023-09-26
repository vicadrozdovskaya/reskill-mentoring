using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Task3.Core.Core;

namespace Task3.Core.UI.Pages
{
    public class CareersPage : BasePage
    {
        readonly Actions action;
        public IWebElement SearchJobKeywordInput => DriverHelper.GetElement(By.Id("new_form_job_search-keyword"));

        public IWebElement SearchJobFilterForm => DriverHelper.GetElement(By.Id("jobSearchFilterForm"));

        public IWebElement SearchJobLocation => DriverHelper.GetElement(By.ClassName("recruiting-search__location"));

        public IWebElement SearchJobRemote => DriverHelper.GetElement(By.XPath("//label[contains(text(),'Remote')]"));

        public IWebElement SearchJobFindBtn => DriverHelper.GetElement(By.XPath("//button[contains(text(),'Find') and @type='submit']"));

        public List<IWebElement> SearchJobResults => DriverHelper.GetElements(By.CssSelector("div.search-result__item-controls a"));

        public IWebElement ViewMoreBtn => DriverHelper.GetElement(By.XPath("//a[contains(text(),'View More')]"));

        public CareersPage()
        {
            action = new Actions(DriverHolder.GetInstance());
        }
        public void SetTextInKeywordInput(string text)
        {
            SearchJobKeywordInput.SendKeys(text);
        }

        public void ClickLocation(string location)
        {
            IWebElement choice = DriverHelper.GetElement(By.XPath(string.Format("//ul/li[@title='{0}']", location)));
            action.ScrollToElement(choice).Perform();
            choice.Click();
        }

        public void ScrollToLastElementOfResultList()
        {
            action.ScrollToElement(SearchJobResults[SearchJobResults.Count - 1]).Perform();
        }
        public void ClickLastElementInSearchResultList()
        {
            SearchJobResults[SearchJobResults.Count - 1].Click();
        }
    }
}
