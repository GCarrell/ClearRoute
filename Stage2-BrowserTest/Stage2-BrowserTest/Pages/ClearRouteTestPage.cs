using OpenQA.Selenium;

namespace Stage2_BrowserTest.Pages
{
    internal class ClearRouteTestPage : PageBase
    {
        public ClearRouteTestPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement DataTable
        {
            get
            {
                return driver.FindElement(By.CssSelector("[testid*='the-table']"));
            }
        }

        public List<List<int>> GetTableValues()
        {
            List<List<int>> values = new();

            List<IWebElement> tableRow = WebDriverWait.Until(dummyDriv =>
            {
                IWebElement temporaryElement = DataTable;
                return (temporaryElement.Displayed && temporaryElement.Enabled) ? temporaryElement : throw new ArgumentException("Table not visible/enabled");
            }).FindElements(By.TagName("tr")).Where(x => x.GetAttribute("testid") != "row-0").ToList();

            foreach (var item in tableRow)
            {
                var rowElements = item.FindElements(By.TagName("td"));
                values.Add(rowElements.Select(y => int.Parse(y.Text)).ToList());
            }

            return values;
        }
    }
}
