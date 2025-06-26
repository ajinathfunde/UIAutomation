using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;


namespace AutoFrameworkCoreLib.Drivers.WebDrivers
{
    public class MSEdge : IWebDrivers
    {
        public void CloseWebDriver()
        {
            throw new NotImplementedException();
        }

        public IWebDriver LaunchWebDriver()
        {
            return new EdgeDriver();
        }
    }
}
