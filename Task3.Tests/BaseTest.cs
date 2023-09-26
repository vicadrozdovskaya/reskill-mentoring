using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Task3.Core.Utilities.Logger;
using Task3.Core.UI.Pages;
using Task3.Core.Utilities;
using Task3.Core.Core;
using Task3.Core.Business;

namespace Task3.Tests
{
    [TestClass]
    public class BaseTest
    {
        [ThreadStatic]
        private static TestContext testContext;

        private readonly string _screenshotsDirectory;
        public BaseTest()
        {
            this.Log = LoggerManager.GetLogger(this.GetType());
            this._screenshotsDirectory = Path.Combine(Environment.CurrentDirectory, "Screenshots");
        }

        protected Logger Log { get; set; }

        protected LandingContext LandingContext { get; set; }

        protected TestContext TestContext
        {
            get
            {
                return testContext;
            }
            set
            {
                testContext = value;
            }
        }


        [TestInitialize]
        public void RunBeforeEachTest()
        {
            Log.Info("Test Initialize ...");
            DriverHolder.GetInstance().Manage().Window.Maximize();
            DriverHolder.GetInstance().Navigate().GoToUrl(ConfigurationReader.ApplicationUrl);
            LandingContext = LandingContext.Open();
        }

        [TestCleanup]
        public void RunAfterEachTest()
        {
            Log.Info("Test Cleanup ...");
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                this.Log.Error(
                    "Test failed. Screenshot saved at: "
                    + ScreenshotTaker.TakeScreenshot(this._screenshotsDirectory, TestContext.TestName));
            }
            ClassCleanup();
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            BaseTest.testContext = testContext;
            ConfigurationReader.HeadlessMode = Convert.ToBoolean(testContext.Properties["headlessMode"]);
            LoggerManager.ReadConfiguration();
        }

        public static void ClassCleanup()
        {
            DriverHolder.GetInstance().Quit();
        }
    }
}
