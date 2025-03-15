using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab2Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        public Header Header { get; }
        public BasePage(IWebDriver webDriver, WebDriverWait webWait)
        {
            (driver, wait) = (webDriver, webWait);             
            Header = new Header(driver, wait);
        }
    }
}