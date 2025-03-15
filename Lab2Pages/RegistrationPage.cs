using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Pages
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public IWebElement RegistrationForm => driver.FindElement(By.XPath("//div[contains(@class,'registration-page')]"));
        IWebElement MaleCheckbox => driver.FindElement(By.XPath("//input[@id='gender-male']"));
        IWebElement FirstNameTxt => driver.FindElement(By.XPath("//input[@id='FirstName']"));
        IWebElement LastNameTxt => driver.FindElement(By.XPath("//input[@id='LastName']"));
        IWebElement EmailTxt => driver.FindElement(By.XPath("//input[@id='Email']"));
        IWebElement PasswordTxt => driver.FindElement(By.XPath("//input[@id='Password']"));
        IWebElement ConfirmPasswordTxt => driver.FindElement(By.XPath("//input[@id='ConfirmPassword']"));
        IWebElement RegisterButton => driver.FindElement(By.XPath("//input[@id='register-button']"));
        IWebElement Errors => driver.FindElement(By.XPath("//div[@class='validation-summary-errors']"));
        
        public void InputGender()
        {
            wait.Until(driver => MaleCheckbox.Displayed && MaleCheckbox.Enabled);
            MaleCheckbox.Click();
        }
        public void InputFirstName(string firstName)
        {
            wait.Until(driver => FirstNameTxt.Displayed && FirstNameTxt.Enabled);
            FirstNameTxt.SendKeys(firstName);
        }
        public void InputLastName(string lastName)
        {
            wait.Until(driver => LastNameTxt.Displayed && LastNameTxt.Enabled);
            LastNameTxt.SendKeys(lastName);
        }
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
        public void InputConfirmPassword(string password)
        {
            wait.Until(driver => ConfirmPasswordTxt.Displayed && ConfirmPasswordTxt.Enabled);
            ConfirmPasswordTxt.SendKeys(password);
        }
        public void RegisterClick()
        {
            wait.Until(driver => RegisterButton.Displayed && RegisterButton.Enabled);
            RegisterButton.Click();
        }
        public string ErrorsText()
        {
            wait.Until(driver => Errors.Displayed && Errors.Enabled);
            return Errors.Text;
        }

    }
}
