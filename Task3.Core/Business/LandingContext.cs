using Task3.Core.UI.Pages;
using Task3.Core.Utilities.Logger;

namespace Task3.Core.Business
{
    public class LandingContext
    {
        private static readonly Logger Log = LoggerManager.GetLogger(typeof(LandingContext));
        private HomePage page = new HomePage();

        public SearchResultsContext Search(string SearchText)
        {
            page.headerMenu.SearchBtn.Click();
            page.SetTextInSearchInput(SearchText);
            page.headerMenu.FindBtn.Click();
            Log.Info(String.Format("Search {0}", SearchText));
            return new SearchResultsContext();
        }

        public CareersContext ChooseCareersTab()
        {
            page.headerMenu.CareersBtn.Click();
            Log.Info("Click Carreer button");
            return new CareersContext();
        }

        public AboutContext ChooseAboutTab()
        {
            page.headerMenu.AboutBtn.Click();
            Log.Info("Click About button");
            return new AboutContext();
        }

        public InsightsContext ChooseInsightsTab()
        {
            page.headerMenu.InsightsBtn.Click();
            Log.Info("Click Insights button");
            return new InsightsContext();
        }

        public static LandingContext Open()
        {
            var _page = new LandingContext();
            _page.page.GoToPage();
            _page.page.AcceptCookieBtn.Click();
            Log.Info("Open main page");
            return _page; 
        }
    }
}
