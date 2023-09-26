using OpenQA.Selenium;
using Task3.Core.Utilities.Browser;
using Task3.Core.Utilities.Logger;

namespace Task3.Core.UI.Pages
{
    public abstract class BasePage
    {
        protected Logger Log;

        protected BasePage()
        {
            this.Log = LoggerManager.GetLogger(this.GetType());
        }
        
    }
}
