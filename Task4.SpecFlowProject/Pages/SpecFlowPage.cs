using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.SpecFlowProject.Drivers;

namespace Task4.SpecFlowProject.Pages
{
    public class SpecFlowPage : BasePage
    {
        private string SearchForm => "rtd-search-form";
        private string SearchInputXpath => "//input[@placeholder='Search docs']";
        private string SearchInputPopupXpath => "//input[@class='search__outer__input']";
        private string SearchResultsPopupXpath => "//h2[@class='search__result__title']";

        private static SpecFlowPage specFlowPage;
        public static SpecFlowPage Instance => specFlowPage ?? (specFlowPage = new SpecFlowPage());

        public void ClickLeftMenuItem(string fieldName)
        {
            DriverHelper.GetElement(By.Id(SearchForm)).Click();
        }

        public void FillSearchText(string text)
        {
            DriverHelper.GetElement(By.XPath(SearchInputPopupXpath)).SendKeys(text);
        }

        public void SelectSearchResult(string text)
        {
            DriverHelper.GetElements((By.XPath(SearchResultsPopupXpath))).First(el => el.Text.Equals(text)).Click();
        }
    }
}
