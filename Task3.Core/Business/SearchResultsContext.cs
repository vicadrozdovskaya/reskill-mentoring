using Task3.Core.UI.Pages;
using Task3.Core.Utilities.Logger;

namespace Task3.Core.Business
{
    public class SearchResultsContext
    {
        private static readonly Logger Log = LoggerManager.GetLogger(typeof(SearchResultsContext));
        private SearchPage page = new SearchPage();

        public List<string> GetSearchResults()
        {
            Log.Info("Get text of found results");
            return page.GetSearchArticlesText();
        }
    }
}
