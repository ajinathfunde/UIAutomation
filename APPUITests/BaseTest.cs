
using APPUITests.Models.Config;
using AutoFrameworkCoreLib.Logger;


namespace APPUITests
{
    public class BaseTest
    {

        public Logger logger;
        public string appURL;
        public string browser;

        public BaseTest() 
        {
            logger = Logger.Instance;
            appURL = ConfigReader.Settings.AppURL;
            logger.Info("BaseTest constructor called. App URL: " + appURL);
            logger.Info("Creating an instance of webdriver");
            browser = ConfigReader.Settings.Browser;
           
            logger.Info(ConfigReader.Settings.Browser + " driver instance is created successfully");
        }
    }
}
