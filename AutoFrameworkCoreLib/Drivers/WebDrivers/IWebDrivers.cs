using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutoFrameworkCoreLib.Drivers.WebDrivers
{
    public interface IWebDrivers
    {

        public IWebDriver LaunchWebDriver();

        public void CloseWebDriver();


    }
}
