using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.SpecFlowProject.Pages
{
    public class GettingStartedPage : BasePage
    {
        private static GettingStartedPage gettingStartedPage;
        public static GettingStartedPage Instance => gettingStartedPage ?? (gettingStartedPage = new GettingStartedPage());
    }
}
