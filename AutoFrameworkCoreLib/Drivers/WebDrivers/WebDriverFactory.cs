using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutoFrameworkCoreLib.Drivers.WebDrivers
{
    public class WebDriverFactory
    {

        ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        public IWebDriver Create(Browser browser) {

            IWebDriver driver;

            switch (browser) {

                case Browser.Chrome:
                    driver =  new Chrome().LaunchWebDriver();
                    break;
                case Browser.Firefox:
                    driver = new Firefox().LaunchWebDriver();
                    break;
                case Browser.Edge:
                    driver = new MSEdge().LaunchWebDriver();
                    break;
                default:
                    throw new NotImplementedException(nameof(browser));
            }
            _driver.Value = driver;
            _driver.Value.Manage().Window.Maximize();
            
            return _driver.Value;
        }

        public void QuitDriver()
        {
            if (_driver.Value != null)
            {
                _driver.Value.Quit();
                _driver.Value.Dispose();
                //_driver.Value = null;
            }
        }
    }

}
