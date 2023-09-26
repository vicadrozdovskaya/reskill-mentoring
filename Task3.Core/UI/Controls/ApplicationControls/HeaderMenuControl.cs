using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.Core;

namespace Task3.Core.UI.Controls.ApplicationControls
{
    public class HeaderMenuControl : BaseControl
    {
        public HeaderMenuControl(IWebElement root) : base(root)
        {
        }
        public IWebElement CareersBtn => Root.FindElement(By.LinkText("Careers"));

        public IWebElement AboutBtn => Root.FindElement(By.LinkText("About"));

        public IWebElement InsightsBtn => Root.FindElement(By.LinkText("Insights"));

        public IWebElement SearchBtn => Root.FindElement(By.CssSelector("button.header-search__button.header__icon"));

        public IWebElement SearchInput => Root.FindElement(By.Id("new_form_search"));

        public IWebElement FindBtn => Root.FindElement(By.XPath("//span[contains(text(),'Find')]"));
    }
}
