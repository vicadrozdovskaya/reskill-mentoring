using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.SpecFlowProject.Drivers;

namespace Task4.SpecFlowProject.Pages
{
    public class HomePage : BasePage
    {
        private string URL => "https://specflow.org";
        private string MainMenuItemXpath => "//ul[@id='menu-main-navigation']/li/a";
        private string SubMenuItemXpath => "//ul[@class='sub-menu']/li/a";

        private static HomePage homePage;
        public static HomePage Instance => homePage ?? (homePage = new HomePage());

        public void OpenSpecFlowHomePage()
        {
            DriverHolder.Instance().Navigate().GoToUrl(URL);
            DriverHelper.GetElement(By.Id("consent-accept")).Click();
        }

        public void HoverMainMenuItem(string item)
        {
            var actions = new Actions(DriverHolder.Instance());
            var menuItem = DriverHelper.GetElements(By.XPath(MainMenuItemXpath)).First(x => x.Text.Equals(item));
            actions.MoveToElement(menuItem).Perform();
        }

        public void ClickSubMenuItem(string item)
        {
            var subMenuItem = DriverHelper.GetElements(By.XPath(SubMenuItemXpath)).First(x => x.Text.Equals(item));
            subMenuItem.Click();
        }
    }
}
