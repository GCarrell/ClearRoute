using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Stage2_BrowserTest.Pages
{
    public class PageBase
    {
        protected readonly IWebDriver driver;
        private WebDriverWait webDriverWait;

        public PageBase(IWebDriver driver, int webDriverWait = 5)
        {
            this.driver = driver;
            this.webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(webDriverWait));
        }

        public WebDriverWait WebDriverWait { get => webDriverWait; set => webDriverWait = value; }
    }
}
