using System;
using Task4.SpecFlowProject.Drivers;
using Task4.SpecFlowProject.Pages;
using TechTalk.SpecFlow;

namespace Task4.SpecFlowProject.StepDefinitions
{
    [Binding]
    public class SpecFlowMenuTestsStepDefinitions
    {
        private readonly ScenarioContext context;

        public SpecFlowMenuTestsStepDefinitions(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I open official SpecFlow web site")]
        public void GivenIOpenOfficialSpecFlowWebSite()
        {
            HomePage.Instance.OpenSpecFlowHomePage();
        }

        [When(@"I hover the '([^']*)' menu item from the main menu")]
        public void WhenIHoverTheMenuItemFromTheMainMenu(string menuItem)
        {
            Thread.Sleep(2000);
            HomePage.Instance.HoverMainMenuItem(menuItem);
        }

        [When(@"I click '([^']*)' option from the main menu")]
        public void WhenIClickOptionFromTheMainMenu(string option)
        {
            HomePage.Instance.ClickSubMenuItem(option);
        }

        [Then(@"Page with '([^']*)' title should be opened")]
        public void ThenPageWithTitleShouldBeOpened(string title)
        {
            Assert.True(BasePage.Instance.IsPageTitleDisplayed(title), "Page title for the page is not displayed");
        }

        [When(@"I click on the '([^']*)' field")]
        public void WhenIClickOnTheField(string fieldName)
        {
            SpecFlowPage.Instance.ClickLeftMenuItem(fieldName);
        }

        [When(@"I enter the '([^']*)' in the popup window")]
        public void WhenIEnterTheInThePopupWindow(string installation)
        {
            SpecFlowPage.Instance.FillSearchText(installation);
        }

        [When(@"I select the '([^']*)' result")]
        public void WhenISelectTheResult(string installation)
        {
            SpecFlowPage.Instance.SelectSearchResult(installation);
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            DriverHolder.QuitDriver();
        }
    }
}
