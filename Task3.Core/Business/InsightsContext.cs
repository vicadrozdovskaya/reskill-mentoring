using Task3.Core.UI.Pages;
using Task3.Core.Utilities.Logger;

namespace Task3.Core.Business
{
    public class InsightsContext
    {
        private static readonly Logger Log = LoggerManager.GetLogger(typeof(InsightsContext));
        private InsightsPage page = new InsightsPage();
        public string? ArticleTitleText { get; set; }

        public InsightsArticleContext ChooseSlide(int number)
        {
            for (int i = 1; i < number; i++)
            { 
                page.SliderNextBtn.Click();
            }
            ArticleTitleText = page.ActiveSlide.ArticleTitleText;
            page.ActiveSlide.ArticleReadMoreLink.Click();
            Log.Info(String.Format("Choose slide number {0}", number));
            return new InsightsArticleContext();
        }
    }
}
