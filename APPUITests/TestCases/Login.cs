using APPUITests.Helpers;
using APPUITests.Models.Config;
using APPUITests.Pages;
using AutoFrameworkCoreLib.Drivers.WebDrivers;
using OpenQA.Selenium;


namespace APPUITests.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Login : BaseTest
    {
        //private string appURL;
        private IWebDriver driver;
        private WebDriverFactory driverFactory;

        [SetUp]
        public void Setup()
        {
            driverFactory = new WebDriverFactory();
            driver = driverFactory.Create(BrowserHelper.Parse(browser));
        }

        [Test]
        public void TestLoginFunwithValidCredentionals()
        {
            //add try catch block to handle exceptions
            try
            {
                logger.Info("Launching application url");
                driver.Navigate().GoToUrl(appURL);
                string title = driver.Title;
                Assert.That(title, Is.EqualTo("ParaBank | Welcome | Online Banking"), "Failed to validate google home page title");
                logger.Info("PARA BANK Home page title is verified successfully");

                // Additional test logic can be added here, such as logging in with valid credentials
                Pages.Login loginPage = new Pages.Login(driver);
                loginPage.LoginAs(ConfigReader.Settings.UserName,ConfigReader.Settings.Password);

                Thread.Sleep(300);
                //after successfull login validate the user is logged in or not
                Assert.That(driver.Title.Trim, Is.EqualTo("ParaBank | Accounts Overview"), "Failed to validate user is logged in or not");

                Logout logoutPage = new Logout(driver);
                logoutPage.UserLogout();
                logger.Info("User logged out successfully");

            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred: {ex.Message}");
                throw; // Re-throw the exception after logging it
            }

        }

        [Test]
        public void TestLoginFunwithInvalidCredentionals()
        {
            try
            {
                logger.Info("Launching application url");
                driver.Navigate().GoToUrl(appURL);
                string title = driver.Title;
                Assert.That(title, Is.EqualTo("ParaBank | Welcome | Online Banking"), "Failed to validate google home page title");
                logger.Info("PARA BANK Home page title is verified successfully");

                // Additional test logic can be added here, such as logging in with valid credentials
                Pages.Login loginPage = new Pages.Login(driver);
                loginPage.LoginAs(ConfigReader.Settings.UserName+"123", ConfigReader.Settings.Password);
                Thread.Sleep(300);
                Assert.That(driver.Title.Trim, Is.EqualTo("ParaBank | Error"), "Failed to validate user is logged in or not");
                string expectedErrorMessage = "An internal error has occurred and has been logged.";

                //now validate error description
                string errorMessage = loginPage.GetLoginErrorMessage();
                Assert.That(errorMessage, Is.EqualTo(expectedErrorMessage), "Failed to validate error message");

                logger.Info("User logged out successfully");

            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred: {ex.Message}");
                throw; // Re-throw the exception after logging it
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