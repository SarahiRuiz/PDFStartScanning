using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PDFTest.drivers
{
    public class SetUp
    {
        public static IWebDriver driver;
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
        }
    }
}
