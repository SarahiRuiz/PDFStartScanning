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
            IWebElement movilNumberInput = driver.FindElement(By.Id("userNumber"));
            IWebElement dateOfBirthInput = driver.FindElement(By.Id("dateOfBirthInput"));
            string genderRadioButtonDynamic = "//div[@id='genterWrapper']//input[@value='?']";
            string yearCalendarOptionDynamic = "//select[@class='react-datepicker__year-select']/option[@value='?']";

            bool enterFirstNameInput = globalMethods.EnterText(firstNameInput, formData.FirstName);
            Assert.IsTrue(enterFirstNameInput, $"Validate if firstname {formData.FirstName} was entered.");
            bool enterLastNameInput = globalMethods.EnterText(lastNameInput, formData.LastName);
            Assert.IsTrue(enterLastNameInput, $"Validate if lastname {formData.LastName} was entered.");
            bool enterEmailInput = globalMethods.EnterText(emailInput, formData.Email);
            Assert.IsTrue(enterEmailInput, $"Validate if email {formData.Email} was entered.");
            bool enterMovilNumberInput = globalMethods.EnterText(movilNumberInput, formData.MovilNumber);
            Assert.IsTrue(enterMovilNumberInput, $"Validate if Movil Number {formData.MovilNumber} was entered.");
            //IWebElement genderRadioButton = globalMethods.CreateDynamicElement(genderRadioButtonDynamic, "Other");
            //bool clickGenderRadioButton = globalMethods.ClickOn(genderRadioButton);
            //Assert.IsTrue(clickGenderRadioButton, $"Validate if Gender Radio Button was clicked.");
            bool clickOnDateOfBirthInput = globalMethods.ClickOn(dateOfBirthInput);
            Assert.IsTrue(clickOnDateOfBirthInput, "Validate if date Of Birth was clicked.");
            IWebElement yearCalendarOption = globalMethods.CreateDynamicElement(yearCalendarOptionDynamic, formData.Year);
            bool selectYearCalendarOption = globalMethods.SelectFromDropDown(yearCalendarOption);
            Assert.IsTrue(selectYearCalendarOption, $"Validate if Year Calendar Option {formData.Year} was selected.");
        }
        public void GoToFormPage()
        {
            //driver.Navigate().GoToUrl("");
            driver.Url = "https://demoqa.com/automation-practice-form";
            Thread.Sleep(5000);
            driver.Manage().Window.Maximize();
        }
    }
}
