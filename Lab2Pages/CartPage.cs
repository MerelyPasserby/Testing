using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public IWebElement Cart => driver.FindElement(By.XPath("//div[contains(@class, 'shopping-cart-page')]"));
        IWebElement CartElement => driver.FindElement(By.XPath("//tr[@class='cart-item-row'][1]/td[@class='product']/a"));

        public bool IsCartElementAvailable()
        {
            try
            {
                return wait.Until(driver => CartElement.Displayed && CartElement.Enabled);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string GetCartElementInfo()
        {
            if (IsCartElementAvailable())
            {
                return CartElement.Text;
            }
            throw new Exception("CartElement info is not available on the page.");
        }
    }
}
