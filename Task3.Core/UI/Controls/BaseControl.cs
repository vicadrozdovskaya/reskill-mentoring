using OpenQA.Selenium;
using Task3.Core.Utilities.Logger;

namespace Task3.Core.UI.Controls
{
	public class BaseControl
	{
        protected IWebElement Root;

        protected Logger Log;

        protected BaseControl(IWebElement root)
        {
            this.Root = root;
            this.Log = LoggerManager.GetLogger(this.GetType());
        }
    }
}

