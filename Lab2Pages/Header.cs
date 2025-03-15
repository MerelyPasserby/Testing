using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Pages
{
    public class Header
    {
        IWebDriver driver;
        WebDriverWait wait;
        public Header(IWebDriver webDriver, WebDriverWait webWait) => (driver, wait) = (webDriver, webWait);

        IWebElement RegisterLink => driver.FindElement(By.XPath("//a[@href='/register']"));
        IWebElement LogInLink => driver.FindElement(By.XPath("//a[@href='/login']"));
        IWebElement CartLink => driver.FindElement(By.XPath("//a[@href='/cart']"));
        IWebElement CustomerInfoLink => driver.FindElement(By.XPath("//div[@class='header-links']//a[@href='/customer/info']"));
        IWebElement LogOutLink => driver.FindElement(By.XPath("//a[@href='/logout']"));

        public RegistrationPage GoToRegister()
        {
            wait.Until(driver => RegisterLink.Displayed && RegisterLink.Enabled);
            RegisterLink.Click();
            return new RegistrationPage(driver, wait);
        }
        public LoginPage GoToLogin()
        {
            wait.Until(driver => LogInLink.Displayed && LogInLink.Enabled);
            LogInLink.Click();
            return new LoginPage(driver, wait);
        }
        public CartPage GoToCart()
        {
            wait.Until(driver => CartLink.Displayed && CartLink.Enabled);
            CartLink.Click();
            return new CartPage(driver, wait);
        }
        public bool IsAccountInfoAvailable()
        {
            try
            {
                return wait.Until(driver => CustomerInfoLink.Displayed && CustomerInfoLink.Enabled);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string GetAccountInfo()
        {
            if(IsAccountInfoAvailable())
            {
                return CustomerInfoLink.Text;
            }
            throw new Exception("Account info is not available on the page.");
        }
        public bool IsLogOutAvailable()
        {
            try
            {
                return wait.Until(driver => LogOutLink.Displayed && LogOutLink.Enabled);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void LogOut()
        {
            if(IsLogOutAvailable())
            {
                LogOutLink.Click();
            }
            else
            {
                throw new Exception("Log out is not available on the page.");
            }
        }
    }
}
