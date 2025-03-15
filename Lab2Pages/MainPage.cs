using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Pages
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public IWebElement Head => driver.FindElement(By.XPath("//div[@class='header']"));
        IWebElement ProductLink => driver.FindElement(By.XPath("//div[@class='item-box']/div[@data-productid='2']//div[@class='details']//a"));

        public ProductPage GoToProduct()
        {
            wait.Until(driver => ProductLink.Displayed && ProductLink.Enabled);
            ProductLink.Click();
            return new ProductPage(driver, wait);
        }
    }
}
