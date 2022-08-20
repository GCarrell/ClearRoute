using OpenQA.Selenium;

namespace Stage2_BrowserTest.Pages
{
    internal class ClearRouteHomepage : PageBase
    {
        private const string BaseUrl = "http://localhost:3000/";

        public ClearRouteHomepage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement StartTestButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("a[href*='/test']"));
            }
        }

        public void SelectStartTestButton()
        {
            WebDriverWait.Until(dummyDriv =>
            {
                IWebElement temporaryElement = StartTestButton;
                return (temporaryElement.Displayed && temporaryElement.Enabled) ? temporaryElement : throw new ArgumentException("Button to Start Test not visible/enabled");
            }).Click();
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }
    }
}
