using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDFTest.drivers;
using System.Text;

namespace PDFTesT.PageObject
{
    public class GenericsMethod : SetUp
    {       
        public IWebElement CreateDynamicElement(string element, string dynamicValue)
        {
            string dynamicElement = element.Replace("?", dynamicValue);
            return driver.FindElement(By.XPath(dynamicElement));
        }
        /*public IWebElement CreateDynamicElement(string element, string dynamicValue1, string dynamicValue2)
        {
            string dynamicElement = "";
            try
            {
                int totalIncognits = element.Count(c => c == '?');
                if (totalIncognits==2)
                {
                    dynamicElement = element.Replace("?", dynamicValue1);
                }else if(totalIncognits == 1)
                {
                    dynamicElement = element.Replace("?", dynamicValue2);
                }
                else if(totalIncognits<=0)
                {
                    return driver.FindElement(By.XPath(dynamicElement));
                }               
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }*/

        public bool EnterText(IWebElement element, string value, int timeOut = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(d => WaitElementEnter(wait, element, value));
        }

        private bool WaitElementEnter(WebDriverWait wait, IWebElement element, string Value)
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
            return wait.Until(d => WaitElementClicked(wait, element));
        }

        private bool WaitElementClicked(WebDriverWait wait, IWebElement element)
        {
            try
            {
                return wait.Until(d =>
                {
                    element.Click();
                    return true;
                });
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool WaitForElement(IWebElement element, int timeOut = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(d => WaitElementVisibility(wait, element));
        }

        private bool WaitElementVisibility(WebDriverWait wait, IWebElement element)
        {
            try
            {
                return wait.Until(d =>
                {
                    return element.Displayed;
                });
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
