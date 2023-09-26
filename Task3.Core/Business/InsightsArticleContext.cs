using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.UI.Pages;
using Task3.Core.Utilities.Logger;

namespace Task3.Core.Business
{
    public class InsightsArticleContext
    {
        private static readonly Logger Log = LoggerManager.GetLogger(typeof(InsightsArticleContext));
        private InsightsArticlePage page = new InsightsArticlePage();

        public string GetTitle()
        {
            Log.Info("Get Title of Insights article");
            return page.GetTitleText();
        }
    }
}
