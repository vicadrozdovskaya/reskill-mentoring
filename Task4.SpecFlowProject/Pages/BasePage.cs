using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.SpecFlowProject.Drivers;

namespace Task4.SpecFlowProject.Pages
{
    public class BasePage
    {
        private string TitleXPath => "//h1[text()='{0}']";

        public BasePage()
        {

        }

        private static BasePage basePage;
        public static BasePage Instance => basePage ?? (basePage = new BasePage());

        public bool IsDisplayed(By locator, int timeout = 30)
        {
            var wait = new WebDriverWait(DriverHolder.Instance(), TimeSpan.FromSeconds(timeout));
            return wait.Until(d => DriverHelper.GetElement(locator).Displayed);
        }

        public bool IsPageTitleDisplayed(string pageTitle)
        {
            return IsDisplayed(By.XPath(string.Format(TitleXPath, pageTitle)));
        }
    }
}
