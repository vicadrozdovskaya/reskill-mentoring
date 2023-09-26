using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.Core;
using Task3.Core.UI.Pages;

namespace Task3.Core.Business
{
    public class AboutContext
    {
        AboutPage page = new AboutPage();

        public string DownloadFile(string fileName,string SeleniumDownloadPath)
        {
            page.DownloadBtn.Click();
            DriverHelper.WaitFileDownloaded(SeleniumDownloadPath, fileName);
            FileInfo fileInfo = new FileInfo(SeleniumDownloadPath + "\\" + fileName);
            File.Delete(SeleniumDownloadPath + "\\" + fileName);
            return fileInfo.Name;
        }
    }
}
