using OpenQA.Selenium;
using Task3.Core.Core;

namespace Task3.Core.UI.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage()
        {
        }

        public List<IWebElement> SearchArticles => DriverHelper.GetElements(By.CssSelector("article.search-results__item"));

        public List<string> GetSearchArticlesText()
        {
            return SearchArticles.Select(el => el.Text).ToList();
        }
    }
}
