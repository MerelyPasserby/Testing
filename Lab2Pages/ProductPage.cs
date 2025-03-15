using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public IWebElement ProductForm => driver.FindElement(By.XPath("//div[contains(@class, 'product-details-page')]"));
        IWebElement ProductName => driver.FindElement(By.XPath("//h1"));
        IWebElement RecipientNameTxt => driver.FindElement(By.XPath("//input[@class='recipient-name']"));
        IWebElement RecipientEmailTxt => driver.FindElement(By.XPath("//input[@class='recipient-email']"));
        IWebElement SenderNameTxt => driver.FindElement(By.XPath("//input[@class='sender-name']"));
        IWebElement SenderEmailTxt => driver.FindElement(By.XPath("//input[@class='sender-email']"));
        IWebElement AddToCartButton => driver.FindElement(By.XPath("//input[@class='button-1 add-to-cart-button']"));
        IWebElement Errors => driver.FindElement(By.XPath("//div[@id='bar-notification']"));

        public string GetProductName()
        {
            wait.Until(driver => ProductName.Displayed && ProductName.Enabled);
            return ProductName.Text;
        }

        public void InputRecName(string recName)
        {
            wait.Until(driver => RecipientNameTxt.Displayed && RecipientNameTxt.Enabled);
            RecipientNameTxt.SendKeys(recName);
        }
        public void InputRecEmail(string recEmail)
        {
            wait.Until(driver => RecipientEmailTxt.Displayed && RecipientEmailTxt.Enabled);
            RecipientEmailTxt.SendKeys(recEmail);
        }
        public void InputSendName(string sendName)
        {
            wait.Until(driver => SenderNameTxt.Displayed && SenderNameTxt.Enabled);
            SenderNameTxt.SendKeys(sendName);
        }
        public void InputSendEmail(string sendEmail)
        {
            wait.Until(driver => SenderEmailTxt.Displayed && SenderEmailTxt.Enabled);
            SenderEmailTxt.SendKeys(sendEmail);
        }
        public void AddToCartClick()
        {
            wait.Until(driver => AddToCartButton.Displayed && AddToCartButton.Enabled);
            AddToCartButton.Click();
        }
        public string ErrorsText()
        {
            wait.Until(driver => Errors.Displayed && Errors.Enabled);
            return Errors.Text;
        }

    }
}
