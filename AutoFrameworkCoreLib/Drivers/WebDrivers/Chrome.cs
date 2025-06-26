using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoFrameworkCoreLib.Drivers.WebDrivers
{
    public class Chrome : IWebDrivers
    {
        public void CloseWebDriver()
        {
            throw new NotImplementedException();
        }

        public IWebDriver LaunchWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            options.PageLoadTimeout = TimeSpan.FromSeconds(30);
            return new ChromeDriver(options);
        }
    }
}
