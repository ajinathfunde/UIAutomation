using APPUITests.Helpers;
using AutoFrameworkCoreLib.Drivers.WebDrivers;
using APPUITests.Pages;
using OpenQA.Selenium;
using APPUITests.Models.Config;


namespace APPUITests.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Login2 : BaseTest
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
        public void TestLoginFunwithValidCredentionals2()
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
                loginPage.LoginAs(ConfigReader.Settings.UserName, ConfigReader.Settings.Password);
                Thread.Sleep(300);

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
        public void TestLoginFunwithInvalidCredentionals4()
        {
            logger.Info("Launching application url");
            driver.Navigate().GoToUrl(appURL);
            string title = driver.Title;
            Assert.That(title, Is.EqualTo("ParaBank | Welcome | Online Banking"), "Failed to validate google home page title");
            logger.Info("PARA BANK Home page title is verified successfully");

            // Additional test logic can be added here, such as logging in with valid credentials
            Pages.Login loginPage = new Pages.Login(driver);
            loginPage.LoginAs(ConfigReader.Settings.UserName + "123", ConfigReader.Settings.Password);
            Thread.Sleep(300);

            //now validate the login error message is poped-up or not
            string expectedErrorMessage = "An internal error has occurred and has been logged.";
            // You can add assertions to verify the successful login or the presence of a specific element after login
            string errorFlag = loginPage.GetLoginErrorMessage();
            logger.Info($"{expectedErrorMessage}");
            Assert.That(errorFlag, Is.EqualTo(expectedErrorMessage), "Login error message does not match expected value.");
            logger.Info("Login with invalid credentials test is successful and error message is verified successfully");
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