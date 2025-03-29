using OpenQA.Selenium;

namespace SeleniumLocatersDemo.Pages
{
    public class LoginPage
    {
        private  IWebDriver driver;
        private  IWebElement usernameField;
        private  IWebElement passwordField;
        private  IWebElement btnSubmit;
        private IWebElement errorDiv;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            usernameField = driver.FindElement(By.Id("username"));
            passwordField = driver.FindElement(By.Id("password"));
            btnSubmit = driver.FindElement(By.CssSelector("button.radius[type=submit]"));
            

        }
        public string Username { 
            set { usernameField.SendKeys(value); } 
        }
        public string Password
        {
            set { passwordField.SendKeys(value); }
        }

        public string ErrorMessage
        {
            get
            {
                errorDiv = driver.FindElement(By.Id("flash"));
                return errorDiv.Text;
            }
        }
        public void Submit()
        {
            btnSubmit.Click();
        }
    }

    
}
