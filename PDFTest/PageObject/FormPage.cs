using OpenQA.Selenium;
using PDFTest.Data;
using PDFTest.drivers;
using PDFTesT.PageObject;
using PDFTest.Models;
using MathNet.Numerics;

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
            string genderRadioButtonDynamic = "//div[@id='genterWrapper']//input[@value='?']";

            bool enterFirstNameInput = globalMethods.EnterText(firstNameInput, formData.FirstName);
            Assert.IsTrue(enterFirstNameInput, $"Validate if firstname {formData.FirstName} was entered.");
            bool enterLastNameInput = globalMethods.EnterText(lastNameInput, formData.LastName);
            Assert.IsTrue(enterLastNameInput, $"Validate if lastname {formData.LastName} was entered.");
            bool enterEmailInput = globalMethods.EnterText(emailInput, formData.Email);
            Assert.IsTrue(enterEmailInput, $"Validate if email {formData.Email} was entered.");
            IWebElement genderRadioButton = globalMethods.CreateDynamicElement(genderRadioButtonDynamic, "Other");
            bool clickGenderRadioButton = globalMethods.ClickOn(genderRadioButton);
            Assert.IsTrue(clickGenderRadioButton, $"Validate if Gender Radio Button was clicked.");
        }
        public void GoToFormPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
        }
    }
}
