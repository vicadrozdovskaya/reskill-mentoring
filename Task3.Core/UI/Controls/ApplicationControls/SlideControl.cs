using OpenQA.Selenium;

namespace Task3.Core.UI.Controls.ApplicationControls
{
    public class SlideControl : BaseControl
    {
        public SlideControl(IWebElement root) : base(root)
        {
        }
        public IWebElement ArticleTitle => Root.FindElement(By.ClassName("font-size-60"));
        public string ArticleTitleText => ArticleTitle.Text.Trim();
        public IWebElement ArticleReadMoreLink => Root.FindElement(By.ClassName("link-with-bottom-arrow"));
        public string ArticleReadMoreLinkText => ArticleReadMoreLink.Text.Trim();
    }
}
