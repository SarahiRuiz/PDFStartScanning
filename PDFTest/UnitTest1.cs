//Inside SeleniumTest.cs

using OpenQA.Selenium.Edge;
using Tesseract;

namespace SeleniumCsharp

{

    public class Tests

    {

        //IWebDriver driver;
        static EdgeDriver driver;


        [Test]

        public void verifyLogo()

        {

            //driver.Navigate().GoToUrl("https://www.browserstack.com/");
            Thread.Sleep(5000);
            //Assert.IsTrue(driver.FindElement(By.Id("logo")).Displayed);
            PDFtest();

        }

        [OneTimeTearDown]

        public void TearDown()
        {
            driver.Quit();
        }

        [OneTimeSetUp]

        public void Setup()
        {
            //string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            //driver = new EdgeDriver(path + @"\drivers\");
        }

        public void PDFtest()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var ocrengine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);
            var img = Pix.LoadFromFile(path + @"\FileTest\dailyDriverVerify.tiff");
            var res = ocrengine.Process(img);
            String pdfText = res.GetText();
            Console.WriteLine(pdfText);
            var containAccount = pdfText.Contains("Faulken Billy's Crash");
            Assert.IsTrue(containAccount, "Verify Account contains was verified");
            var containDate = pdfText.Contains("08/29/2023");
            Assert.IsTrue(containDate, "Verify Date contains was verified");
            Console.ReadKey();
        }
        //https://www.youtube.com/watch?v=p8zLyKDKT20

    }

}
