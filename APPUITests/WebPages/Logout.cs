using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V135.Emulation;


namespace APPUITests.Pages
{
    public class Logout
    {

        private readonly IWebDriver _driver;

        //Locators
        private readonly By _mainMenu = By.Id("react-burger-menu-btn");
        private readonly By _logoutButton = By.XPath("//div[@id='leftPanel']/ul/li[8]/a");


        //find elements
        private IWebElement LogoutButton => _driver.FindElement(_logoutButton);


        //constructor
        public Logout(IWebDriver driver)
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
