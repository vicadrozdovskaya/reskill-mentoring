using OpenQA.Selenium;
using Task3.Core.Core;
using Task3.Core.UI.Controls.ApplicationControls;

namespace Task3.Core.UI.Pages
{
    public class InsightsPage : BasePage
    {
        public SlideControl ActiveSlide => new SlideControl(DriverHelper.GetElement(By.CssSelector("div.owl-item.active")));

        public IWebElement SliderNextBtn => DriverHelper.GetElements(By.ClassName("slider__right-arrow"))[1];
        


    }
}
