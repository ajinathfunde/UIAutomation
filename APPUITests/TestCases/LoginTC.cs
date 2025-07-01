using APPUITests.Helpers;
using APPUITests.Models.Config;
using APPUITests.TestData;
using APPUITests.WebPages;
using AutoFrameworkCoreLib.Drivers.WebDrivers;
using AutoFrameworkCoreLib.Logger;
using AutoFrameworkCoreLib.Reports;
using AutoFrameworkCoreLib.ScreenshotService;
using OpenQA.Selenium;

namespace APPUITests.TestCases
{

    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTC : BaseTest
    {
        private IWebDriver driver;
        private WebDriverFactory driverFactory;

        [SetUp]
        public void Setup()
        {
            ScreenshotService.InitTestFolder(TestContext.CurrentContext.Test.Name);
            ExtentManager.Test = ExtentManager.Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driverFactory = new WebDriverFactory();
            driver = driverFactory.Create(BrowserHelper.Parse(browser));
        }


        [Test,TestCaseSource(typeof(LoginMsgDataProvider),nameof(LoginMsgDataProvider.SuccessMgs))]
        public void TestLoginFunwithValidCredentionals(string loginHomePageTitle, string afterLoginPageTitle)
        {
            try
            {
                ExtentManager.Test.Info("Launching application");
                logger.Info("Launching application");

                driver.Navigate().GoToUrl(appURL);
                ExtentManager.Test.Info($"Navigated to {appURL}");

                string title = driver.Title;
                ExtentManager.Test.Info($"Page title: {title}");
                Assert.That(title, Is.EqualTo(loginHomePageTitle), "Failed to validate google home page title");
                ExtentManager.Test.Pass("Home page title validated");
                ScreenshotService.CaptureScreenshot(driver, "BeforeLogin");

                LoginPage loginPage = new LoginPage(driver);
                loginPage.LoginAs(ConfigReader.Settings.UserName, ConfigReader.Settings.Password);
                ExtentManager.Test.Info("Checking user logged in with valid credentials or not");
                //add assertion to check if user is logged in or not

                Thread.Sleep(300);
                Assert.That(driver.Title.Trim(), Is.EqualTo(afterLoginPageTitle), "Failed to validate user is logged in or not");
                ScreenshotService.CaptureScreenshot(driver, "AfterLogin");

                ExtentManager.Test.Pass("User is logged in and Accounts Overview page is displayed");

                LogoutPage logoutPage = new LogoutPage(driver);
                logoutPage.UserLogout();
                //verify user is logged out or not
                Assert.That(driver.Title.Trim(), Is.EqualTo(loginHomePageTitle), "Failed to validate user is logged out or not");
                ScreenshotService.CaptureScreenshot(driver, "AfterLogout");
                logger.Info("User logged out successfully");
                ExtentManager.Test.Info("User logged out successfully");
            }
            catch (Exception ex)
            {
                string screenshotPath = ScreenshotService.CaptureScreenshot(driver, "OnError");
                logger.Error($"An error occurred: {ex.Message}");
                ExtentManager.Test.Fail($"An error occurred: {ex.Message}");
                ExtentManager.Test.AddScreenCaptureFromPath(screenshotPath); // Optional: Attach to ExtentReport
                throw;
            }
        }
 
        [Test,TestCaseSource(typeof(LoginMsgDataProvider),nameof(LoginMsgDataProvider.FailureMgs))]
        public void TestLoginFunwithInvalidCredentionals(string expectedErrorMessage)
        {
            try
            {
                ExtentManager.Test.Info("Launching application");
                logger.Info("Launching application");

                driver.Navigate().GoToUrl(appURL);
                ExtentManager.Test.Info($"Navigated to {appURL}");

                string title = driver.Title;
                ExtentManager.Test.Info($"Page title: {title}");
                string loginHomePageTitle = "Test Login | Practice Test Automation";
                Assert.That(title, Is.EqualTo(loginHomePageTitle), "Failed to validate automation testing home page title");
                ExtentManager.Test.Pass("Home page title validated");
                ScreenshotService.CaptureScreenshot(driver, "BeforeLogin");

                LoginPage loginPage = new LoginPage(driver);
                loginPage.LoginAs(ConfigReader.Settings.UserName, "1234");
                ExtentManager.Test.Info("Checking user logged in with invalid credentials or not");
                //add assertion to check if user is logged in or not
                Thread.Sleep(300);
                Assert.That(driver.Title.Trim(), Is.EqualTo(loginHomePageTitle), "Failed to validate user is logged in or not");
                ExtentManager.Test.Info("Error page displayed after invalid login");

                //string expectedErrorMessage = "Your password is invalid!";
                string errorMessage = loginPage.GetLoginErrorMessage();

                ExtentManager.Test.Info($"Error message displayed: {errorMessage}");
                Assert.That(errorMessage, Is.EqualTo(expectedErrorMessage), "Failed to validate error message");
                ExtentManager.Test.Pass("Error message validated for invalid login");
                ScreenshotService.CaptureScreenshot(driver, "AfterInvalidLogin");
                logger.Info("User logged out successfully");
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred: {ex.Message}");
                ExtentManager.Test.Fail($"Test failed: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (driverFactory != null)
            {
                driverFactory.QuitDriver();
                driver.Dispose();
            }
            logger.Info("Closing application & webdriver");
        }
    }
}
