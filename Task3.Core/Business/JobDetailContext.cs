using System;
using Task3.Core.UI.Pages;
using Task3.Core.Utilities.Logger;

namespace Task3.Core.Business
{
    public class JobDetailContext
    {
        private static readonly Logger Log = LoggerManager.GetLogger(typeof(JobDetailContext));
        JobDetailPage page = new JobDetailPage();
        public string GetFromWhatYouHaveSectionText()
        {
            Log.Info("Get Text from 'What You Have' section");
            return page.GetTextFromWhatYouHaveSection();
        }
    }
}
