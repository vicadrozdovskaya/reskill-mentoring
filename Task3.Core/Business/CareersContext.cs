using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.UI.Pages;

namespace Task3.Core.Business
{
    public class CareersContext
    {
        private CareersPage page = new CareersPage();

        public void SearchJob(string jobName, string location)
        {
            page.SetTextInKeywordInput(jobName);
            page.SearchJobFilterForm.Click();
            page.SearchJobLocation.Click();
            page.ClickLocation(location);
            page.SearchJobRemote.Click();
            page.SearchJobFindBtn.Click();
        }

        public JobDetailContext ChooseTheLastElementInResults()
        {
            page.ScrollToLastElementOfResultList();
            while (page.ViewMoreBtn.Displayed)
            {
                page.ViewMoreBtn.Click();
            }
            page.ClickLastElementInSearchResultList();
            return new JobDetailContext();
        }
    }
}
