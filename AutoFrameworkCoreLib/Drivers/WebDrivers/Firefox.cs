using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AutoFrameworkCoreLib.Drivers.WebDrivers
{
    public class Firefox : IWebDrivers
    {
        public void CloseWebDriver()
        {
            throw new NotImplementedException();
        }

        public IWebDriver LaunchWebDriver()
        {
            return new FirefoxDriver();
        }
    }
}
