using OpenQA.Selenium;
using PDFTest.Data;
using PDFTest.drivers;
using PDFTesT.PageObject;
using PDFTest.Models;

namespace PDFTest.PageObject
{
    public class FormPage : SetUp
    {
        public GenericsMethod globalMethods = new GenericsMethod();        
        public void FillForm(FormData formData)
        {            
            IWebElement firstNameInput = driver.FindElement(By.Id("firstName"));
            IWebElement lastNameInput = driver.FindElement(By.Id("lastName"));
            IWebElement emailInput = driver.FindElement(By.Id("userEmail"));

            bool enterFirstNameInput = globalMethods.EnterText(firstNameInput, formData.FirstName);
            Assert.IsTrue(enterFirstNameInput, $"Validate if firstname was {formData.FirstName} was entered.");
            bool enterLastNameInput = globalMethods.EnterText(lastNameInput, formData.LastName);
            Assert.IsTrue(enterLastNameInput, $"Validate if lastname was {formData.LastName} was entered.");
            bool enterEmailInput = globalMethods.EnterText(emailInput, formData.Email);
            Assert.IsTrue(enterLastNameInput, $"Validate if email was {formData.Email} was entered.");
            string genderRadioButton = "//div[@id='genterWrapper']//input[@value='?']";
            IWebElement genderRadioButtonDynamic = globalMethods.CreateDynamicElement(genderRadioButton, "Other");
            genderRadioButtonDynamic.Click();
        }
        public void GoToFormPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(5000);
        }
    }
}
