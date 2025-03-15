using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab2Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public IWebElement LoginForm => driver.FindElement(By.XPath("//div[contains(@class, 'login-page')]"));
        IWebElement EmailTxt => driver.FindElement(By.XPath("//input[@id='Email']"));
        IWebElement PasswordTxt => driver.FindElement(By.XPath("//input[@id='Password']"));
        IWebElement LoginButton => driver.FindElement(By.XPath("//input[contains(@class, 'login-button')]"));
        IWebElement Errors => driver.FindElement(By.XPath("//div[@class='validation-summary-errors']"));

        public void InputEmail(string email)
        {
            wait.Until(driver => EmailTxt.Displayed && EmailTxt.Enabled);
            EmailTxt.SendKeys(email);
        }
        public void InputPassword(string password)
        {
            wait.Until(driver => PasswordTxt.Displayed && PasswordTxt.Enabled);
            PasswordTxt.SendKeys(password);
        }
        public void LoginClick()
        {
            wait.Until(driver => LoginButton.Displayed && LoginButton.Enabled);
            LoginButton.Click();
        }
        public string ErrorsText()
        {
            wait.Until(driver => Errors.Displayed && Errors.Enabled);
            return Errors.Text;
        }

    }
}
