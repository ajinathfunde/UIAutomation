using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Emulation;


namespace APPUITests.WebPages
{
    public class LogoutPage
    {

        private readonly IWebDriver _driver;

        //Locators
        private readonly By _mainMenu = By.Id("react-burger-menu-btn");
        private readonly By _logoutButton = By.XPath("//div[@id='loop-container']/div//a");


        //find elements
        private IWebElement LogoutButton => _driver.FindElement(_logoutButton);


        //constructor
        public LogoutPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public void ClickLogoutButton()
        {
            LogoutButton.Click();
        }
       
        // Optional: Convenience method for full login
        public void UserLogout()
        {
            ClickLogoutButton();

        }
    }
}
