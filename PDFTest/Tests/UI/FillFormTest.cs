using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using PDFTesT.PageObject;
using PDFTest.drivers;
using PDFTest.PageObject;
using PDFTest.Data;
using PDFTest.Models;

namespace PDFTest.Tests.UI
{
    public class FillFormTest : SetUp
    {
        public FormPage formPage = new FormPage();
        [Test]
        public void VerifyAndFillForm()
        {
            FormData validFormData = FormDataInstances.ValidadData;
            formPage.GoToFormPage();
            formPage.FillForm(validFormData);
        }               
    }
}
