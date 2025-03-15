using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2Tests
{
    [TestFixture]
    internal class RegistrationTests : BaseTests
    {
        void FillRegistrationForm(RegistrationPage registrationPage, string email, string password)
        {
            registrationPage.InputGender();
            Thread.Sleep(1000);
            registrationPage.InputFirstName("A");
            Thread.Sleep(1000);
            registrationPage.InputLastName("D");
            Thread.Sleep(1000);
            registrationPage.InputEmail(email);
            Thread.Sleep(1000);
            registrationPage.InputPassword(password);
            Thread.Sleep(1000);
            registrationPage.InputConfirmPassword(password);
            Thread.Sleep(1000);
        }

        [Test]
        public void PositiveTest()
        {
            MainPage mainPage = new MainPage(driver, wait);
            wait.Until(driver => mainPage.Head.Displayed);
            Thread.Sleep(1000);

            RegistrationPage registrationPage = mainPage.Header.GoToRegister();
            wait.Until(driver => registrationPage.RegistrationForm.Displayed);
            Thread.Sleep(1000);

            string email = "aaaqqqzzz10@gmail.com";
            string password = "12345678";

            FillRegistrationForm(registrationPage, email, password);

            registrationPage.RegisterClick();
            Thread.Sleep(3000);

            string actual = registrationPage.Header.GetAccountInfo();

            Assert.That(actual, Is.EqualTo(email));
        }

        [Test]
        public void NegativeTest()
        {
            MainPage mainPage = new MainPage(driver, wait);
            wait.Until(driver => mainPage.Head.Displayed);
            Thread.Sleep(1000);

            RegistrationPage registrationPage = mainPage.Header.GoToRegister();
            wait.Until(driver => registrationPage.RegistrationForm.Displayed);
            Thread.Sleep(1000);

            string email = "aaaqqqzzz1@gmail.com";
            string password = "12345678";
            
            FillRegistrationForm(registrationPage, email, password);

            registrationPage.RegisterClick();
            Thread.Sleep(3000);

            string errorText = "The specified email already exists";
            string actual = registrationPage.ErrorsText();

            Assert.That(actual, Is.EqualTo(errorText));
        }
    }
}
