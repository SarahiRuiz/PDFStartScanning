using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDFTest.drivers;

namespace PDFTesT.PageObject
{
    public class GenericsMethod : SetUp
    {       
        public void EnterTextAndValidate(IWebElement element, string value)
        {
            Assert.IsTrue(element.Displayed, $"Element input is {value} entered.");
            element.SendKeys(value);
            Thread.Sleep(5000);
            string textInput = element.GetAttribute("value");
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

        public bool EnterText(IWebElement element, string value, int timeOut = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(d => WaitElementEnter(wait, element, value));
        }

        public bool WaitElementEnter(WebDriverWait wait, IWebElement element, string Value)
        {
            try
            {
                return wait.Until(d =>
                {
                    element.SendKeys(Value);
                    return true;
                });
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ClickOn(IWebElement element, int timeOut = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(d =>
            {
                element.Click();
                return true;
            });
        }
    }
}
