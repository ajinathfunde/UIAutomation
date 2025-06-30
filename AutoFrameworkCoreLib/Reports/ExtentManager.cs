

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;
using System.Threading;


namespace AutoFrameworkCoreLib.Reports 
{
    public static class ExtentManager
    {
        private static readonly ExtentReports _extent;
        private static readonly ExtentHtmlReporter _htmlReporter;
        private static ThreadLocal<ExtentTest> _test = new ThreadLocal<ExtentTest>();

        static ExtentManager()
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string reportDir = string.Concat(baseDirectory, "TestResults");
          
            if (!Directory.Exists(reportDir))
                Directory.CreateDirectory(reportDir);

            _htmlReporter = new ExtentHtmlReporter(Path.Combine(reportDir, "ExtentReport.html"));
            // Set the report name and document title
            _htmlReporter.Config.ReportName = "Automation Test Report - C# Selenium";
            _htmlReporter.Config.DocumentTitle = "Automation Execution Report";


            _extent = new ExtentReports();
            
            _extent.AttachReporter(_htmlReporter);
        }


        public static ExtentReports Extent => _extent;

        public static ExtentTest Test
        {
            get => _test.Value;
            set => _test.Value = value;
        }

        public static void Flush() => _extent.Flush();
    }

}

