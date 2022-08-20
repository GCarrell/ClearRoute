using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Stage2_BrowserTest.Pages;

namespace Stage2_BrowserTest
{
    public class ClearRouteE2ETests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TestPageIntegerTableRowsContainEquivalenceIndices()
        {
            ClearRouteHomepage homepage = new(driver);
            ClearRouteTestPage testPage = new(driver);

            homepage.GoToPage();
            homepage.SelectStartTestButton();

            List<List<int>> tableValues = testPage.GetTableValues();

            List<int?> answers = new();
            
            foreach (List<int> row in tableValues)
            {
                for (int i = 1; i <= row.Count - 2; i++)
                {
                    int sumBeforeIndex, sumAfterIndex;
                    sumBeforeIndex = row.GetRange(0, i).Sum();
                    sumAfterIndex = row.GetRange(i + 1, row.Count - (i + 1)).Sum();

                    if (sumBeforeIndex == sumAfterIndex)
                    {
                        answers.Add(i + 1);
                        break;
                    }
                    else if (i == row.Count - 2)
                    {
                        answers.Add(null);
                    }
                }
            }

            Assert.That(answers[0], Is.EqualTo(5));
            Assert.That(answers[1], Is.EqualTo(4));
            Assert.That(answers[2], Is.EqualTo(6));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}