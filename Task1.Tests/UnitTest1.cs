using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private WebDriver WebDriver { get; set; } = null;
        private string DriverPath { get; set; } = "C:\\chromedriver";
        private string BaseUrl { get; set; } = "https://www.epam.com/";

        [TestInitialize]
        public void Setup()
        {
            WebDriver = GetChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            WebDriver.Manage().Window.Maximize();

        }

        [TestMethod]
        [DataRow(".Net", "All Locations")]
        public void TestMethodTask1(string keyword, string location)
        {
            WebDriver.Navigate().GoToUrl(BaseUrl);

            AcceptCookies();

            WebDriver.FindElement(By.LinkText("Careers")).Click();

            var input = WebDriver.FindElement(By.Id("new_form_job_search-keyword"));
            input.SendKeys(keyword);
            WebDriver.FindElement(By.CssSelector("#jobSearchFilterForm")).Click();

            input = WebDriver.FindElement(By.ClassName("recruiting-search__location"));
            input.Click();

            WebDriver.FindElement(By.XPath(string.Format("//li[@title='{0}']", location))).Click();

            var remote = WebDriver.FindElement(By.XPath("//label[contains(text(),'Remote')]"));
            remote.Click();

            WebDriver.FindElement(By.XPath("//button[contains(text(),'Find') and @type='submit']")).Click();

            var results = WebDriver.FindElements(By.CssSelector("div.search-result__item-controls"));
            Actions action = new Actions(WebDriver);
            action.ScrollToElement(results[results.Count - 1]).Perform();
            WheelInputDevice.ScrollOrigin scrollOrigin = new WheelInputDevice.ScrollOrigin
            {
                Element = results[results.Count - 1]
            };
            action.ScrollFromOrigin(scrollOrigin, 0, 200).Perform();
            while (WebDriver.FindElement(By.XPath("//a[contains(text(),'View More')]")).Displayed)
            {
                var btn = WebDriver.FindElement(By.XPath("//a[contains(text(),'View More')]"));
                action.ScrollToElement(btn).Perform();
                btn.Click();
            }
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElements(By.CssSelector("div.search-result__item-controls a")).Last().Displayed);
            WebDriver.FindElements(By.CssSelector("div.search-result__item-controls a")).Last().Click();

            var text = WebDriver.FindElement(By.XPath("//h3[contains(text(),'What You Have')]/following-sibling::ul/li")).Text;
            Assert.IsTrue(Regex.IsMatch(text, Regex.Escape(keyword), RegexOptions.IgnoreCase));
        }

        [TestMethod]
        [DataRow("BLOCKCHAIN")]
        [DataRow("Cloud")]
        [DataRow("Automation")]
        public void TestMethodTask2(string keyword)
        {
            WebDriver.Navigate().GoToUrl(BaseUrl);

            AcceptCookies();

            WebDriver.FindElement(By.CssSelector("button.header-search__button.header__icon")).Click();

            var input = WebDriver.FindElement(By.Id("new_form_search"));
            input.SendKeys(keyword);
            WebDriver.FindElement(By.XPath("//span[contains(text(),'Find')]")).Click();

            var elements = WebDriver.FindElements(By.CssSelector("article.search-results__item"));
            var texts = elements.Select(el => el.Text).ToList();
            Assert.IsTrue(texts.All(text => Regex.IsMatch(text, Regex.Escape(keyword), RegexOptions.IgnoreCase)));
        }
        private WebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();

            return new ChromeDriver(DriverPath, options, TimeSpan.FromSeconds(300));
        }

        public void AcceptCookies()
        {
            WebDriver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }

        [TestCleanup]
        public void Cleanup() { WebDriver.Quit(); }
    }
}
