using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPUITests.Models.Config;
using AutoFrameworkCoreLib.Logger;

namespace APPUITests
{
    // Identifies a class as containing NUnit.Framework.OneTimeSetUpAttribute or NUnit.Framework.OneTimeTearDownAttribute
    // methods for all the test fixtures under a given namespace.
    [SetUpFixture]
    public class TestsInitlization
    {

        private Logger logger;

        // This constructor is called once before any child tests are run.
        public TestsInitlization()
        {
            logger = Logger.Instance;
        }

        //Identifies a method that is called once to perform setup before any child tests are run.
        [OneTimeSetUp]
        public void ReadConfigFile() 
        {

            logger.Info("Reading automation config file - AutomationConfig.json");
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configFilePath = string.Concat(baseDirectory,"\\AutomationConfig.json");
            logger.Info($"{configFilePath}");
            ConfigReader.LoadConfig(configFilePath);
            logger.Info("Config file read successfully");
        }


        //Identifies a method to be called once after all the child tests have run. The method is guaranteed to be called, even if an exception is thrown
        [OneTimeTearDown]
        public void TearDown() {
            logger.Info("Cleaning some resources");
        }
    }
}
