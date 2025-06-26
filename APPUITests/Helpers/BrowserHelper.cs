
using AutoFrameworkCoreLib.Drivers.WebDrivers;

namespace APPUITests.Helpers
{
    public static class BrowserHelper
    {
        public static Browser Parse(string browserString)
        {
            if (!Enum.TryParse(browserString, true, out Browser browserEnum))
            {
                throw new ArgumentException($"Invalid browser type: {browserString}");
            }
            return browserEnum;
        }
    }
}
