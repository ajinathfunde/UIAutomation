using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace AutoFrameworkCoreLib.ScreenshotService
{
    public static class ScreenshotService
    {
        private static readonly string BaseScreenshotDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", "Screenshots");

        // Thread-safe folder for each test case
        private static ThreadLocal<string> _testFolder = new ThreadLocal<string>();

        public static void InitTestFolder(string testName)
        {
            string safeTestName = MakeSafeFileName(testName);
            string testFolder = Path.Combine(BaseScreenshotDir, safeTestName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff"));
            Directory.CreateDirectory(testFolder);
            _testFolder.Value = testFolder;
        }

        public static string CaptureScreenshot(IWebDriver driver, string stepName)
        {
            if (_testFolder.Value == null)
                throw new InvalidOperationException("Test folder not initialized. Call InitTestFolder at test start.");

            string safeStepName = MakeSafeFileName(stepName);
            string fileName = $"{DateTime.Now:HHmmss_fff}_{safeStepName}.png";
            string filePath = Path.Combine(_testFolder.Value, fileName);

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filePath);

            return filePath;
        }

        private static string MakeSafeFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }
    }
}
