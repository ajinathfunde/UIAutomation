using OpenQA.Selenium;

namespace APPUITests.WebPages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        // Locators
        private readonly By _userNameField = By.Id("username");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("submit");
        private readonly By _loginError = By.Id("error");

        // Constructor
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Page Elements as Properties
        private IWebElement UserNameField => _driver.FindElement(_userNameField);
        private IWebElement PasswordField => _driver.FindElement(_passwordField);
        private IWebElement LoginButton => _driver.FindElement(_loginButton);
        private IWebElement LoginError => _driver.FindElement(_loginError);


        // Page Actions
        public void EnterUserName(string userName)
        {
            UserNameField.Clear();
            UserNameField.SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public string GetLoginErrorMessage()
        {
            return LoginError.Text;
        }


        // Optional: Convenience method for full login
        public void LoginAs(string userName, string password)
        {
            EnterUserName(userName);
            EnterPassword(password);
            ClickLoginButton();
        }
    }
}
