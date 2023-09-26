using System.Configuration;

using Task3.Core.Utilities.Enums;
using Task3.Core.Utilities.Logger;
namespace Task3.Core.Utilities
{
    public static class ConfigurationReader
    {
        private static readonly Logger.Logger Log = LoggerManager.GetLogger(typeof(ConfigurationReader));

        static ConfigurationReader()
        {
            BrowserType = InitBrowserType();
            ApplicationUrl = InitApplicationUrl();
            Timeout = InitTimeout();
        }

        public static BrowserType BrowserType { get; private set; }

        public static string ApplicationUrl { get; private set; }

        public static int Timeout { get; private set; }

        public static bool HeadlessMode { get; set; }

        private static BrowserType InitBrowserType()
        {
            BrowserType browserType;
            string browserTypeString = ConfigurationManager.AppSettings["Browser"];

            if (!Enum.TryParse(browserTypeString, true, out browserType))
            {
                browserType = BrowserType.Unspecified;
                Log.Error(
                    string.Format(
                        "The value of the browser type '{0}' is invalid. The '{1}' value will be used.",
                        browserTypeString,
                        browserType));
            }

            return browserType;
        }

        private static string InitApplicationUrl()
        {
            string url = ConfigurationManager.AppSettings["ApplicationUrl"] ?? string.Empty;

            if (string.IsNullOrWhiteSpace(url))
            {
                Log.Error("The value of the application URL may be incorrect.");
            }

            return url;
        }

        private static int InitTimeout()
        {
            int timeout;
            string timeoutString = ConfigurationManager.AppSettings["Timeout"];

            if (!int.TryParse(timeoutString, out timeout))
            {
                timeout = 30;
                Log.Error(
                    string.Format(
                        "The value of the timeout '{0}' is invalid. The default value of '{1}' will be used instead.",
                        timeoutString,
                        timeout));
            }

            return timeout;
        }

    }
}
