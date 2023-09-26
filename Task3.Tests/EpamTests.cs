using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Task3.Core.Business;

namespace Task3.Tests
{
    [TestClass]
    public class EpamTests : BaseTest
    {
        private static readonly string SeleniumDownloadPath = AppDomain.CurrentDomain.BaseDirectory + "\\Downloads";

        [TestMethod]
        [DataRow(".Net", "All Locations")]
        public void EpamSearchJobTest(string keyword, string location)
        {
            Log.Info("Epam Search Job Test Started ...");
            var carees = LandingContext.ChooseCareersTab();
            carees.SearchJob(keyword, location);
            var jobDetail = carees.ChooseTheLastElementInResults();
            Assert.IsTrue(Regex.IsMatch(jobDetail.GetFromWhatYouHaveSectionText(), Regex.Escape(keyword), RegexOptions.IgnoreCase),
                String.Format("Check that 'What You Have Section' contains word {0}", keyword));
        }

        [TestMethod]
        [DataRow("BLOCKCHAIN")]
        [DataRow("Cloud")]
        [DataRow("Automation")]
        public void EpamSearchTest(string keyword)
        {
            Log.Info("Epam Search Test Started ...");
            var searchResults = LandingContext.Search(keyword);
            Assert.IsTrue(searchResults.GetSearchResults().All(text => Regex.IsMatch(text, Regex.Escape(keyword), RegexOptions.IgnoreCase)), 
                String.Format("Check that all the article contains word {0}", keyword));
        }

        [TestMethod]
        [DataRow("EPAM_Corporate_Overview_2023.pdf")]
        public void EpamFileDownloadTest(string fileName)
        {
            Log.Info("Epam File Download Test Started ...");
            var about = LandingContext.ChooseAboutTab();
            string actualFileName = about.DownloadFile(fileName, SeleniumDownloadPath);
            Assert.AreEqual(fileName, actualFileName, String.Format("Check that file has expected name = {0} ", fileName));
        }

        [TestMethod]
        public void EpamInsigtsTest()
        {
            Log.Info("Epam Insights Test Started ...");
            var insights = LandingContext.ChooseInsightsTab();
            var article = insights.ChooseSlide(3);
            Assert.AreEqual(insights.ArticleTitleText, article.GetTitle(), String.Format("Check that article has expected name = {0} ", insights.ArticleTitleText));
        }

    }
}
