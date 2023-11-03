//Inside SeleniumTest.cs

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using PDFTest.SetUp;
using Tesseract;

namespace SeleniumCsharp
{
    public class Tests : SetUp
    {

        

        [Test]
        public void FillForm()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(5000);
                    IWebElement firstNameInput = driver.FindElement(By.Id("firstName"));
        IWebElement lastNameInput = driver.FindElement(By.Id("lastName"));
        IWebElement emailInput = driver.FindElement(By.Id("userEmail"));
            bool testInput = TextInput(wait, firstNameInput, "Billy");
            //EnterTextAndValidate(firstNameInput, "Billy");
            //EnterTextAndValidate(lastNameInput, "Lasti");
            //EnterTextAndValidate(emailInput, "test@test.com");
            string genderRadioButton = "//div[@id='genterWrapper']//input[@value='?']";
            IWebElement genderRadioButtonDynamic = CreateDynamicElement(genderRadioButton, "Other");
            genderRadioButtonDynamic.Click();
           
            
            bool test = wait.Until(Timeout => driver.FindElement(By.Id("submit")).Displayed);
           
            Thread.Sleep(5000);
            //new WebDriverWait(driver, 20).until(ExpectedConditions.elementToBeClickable(By.xpath("//input[@id='radioNTP' and @name='timeSyncType'][starts-with(@ng-click, 'oSettingTimeInfo')]"))).click();
            //https://stackoverflow.com/questions/71183346/how-to-click-on-a-radio-button-using-selenium
            //https://www.selenium.dev/documentation/webdriver/waits/
        }

        public void EnterTextAndValidate(IWebElement element, string value)
        {
            Assert.IsTrue(element.Displayed, $"Element input is {value} entered.");
            element.SendKeys(value);
            Thread.Sleep(5000);
            String textInput = element.GetAttribute("value");
            Assert.IsTrue(textInput.Equals(value));
        }
        
        public void ClickOnRadioButton(IWebElement element)
        {
            Assert.IsTrue(element.Displayed, $"Element radio button was {element} entered.");
            element.Click();
        }   

        public IWebElement CreateDynamicElement(string element, string dynamicValue)
        {
            string dynamicElement = element.Replace("?", dynamicValue);
            return driver.FindElement(By.XPath(dynamicElement));
        }

        public bool TextInput(IWebElement element, String value, int timeOut = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(d => {
                element.SendKeys(value);
                return true;
            });  
        }

        public bool ClickOn(IWebElement element, int timeOut = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(d => {
                element.Click();
                return true;
            });
        }


        public void PDFtest()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string textPath = path;
            /*var ocrengine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);
            var img = Pix.LoadFromFile(path + @"\FileTest\dailyDriverVerify.tiff");
            var res = ocrengine.Process(img);
            String pdfText = res.GetText();
            Console.WriteLine(pdfText);
            var containAccount = pdfText.Contains("Faulken Billy's Crash");
            Assert.IsTrue(containAccount, "Verify Account contains was verified");
            var containDate = pdfText.Contains("08/29/2023");
            Assert.IsTrue(containDate, "Verify Date contains was verified");
            Console.ReadKey();*/
        }
        //https://www.youtube.com/watch?v=p8zLyKDKT20

    }

}
