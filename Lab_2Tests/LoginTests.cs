using Lab2Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2Tests
{
    [TestFixture]
    internal class LoginTests : BaseTests
    {
        void FillLoginForm(LoginPage loginPage, string email, string password)
        {
            loginPage.InputEmail(email);
            Thread.Sleep(1000);
            loginPage.InputPassword(password);
            Thread.Sleep(1000);
        }

        [Test]
        public void PositiveTest()
        {
            MainPage mainPage = new MainPage(driver, wait);
            wait.Until(driver => mainPage.Head.Displayed);
            Thread.Sleep(1000);

            LoginPage loginPage = mainPage.Header.GoToLogin();
            wait.Until(driver => loginPage.LoginForm.Displayed);
            Thread.Sleep(1000);           

            string email = "zzzzzzA@gmail.com";
            string password = "12345678";

            FillLoginForm(loginPage, email, password);

            loginPage.LoginClick();
            Thread.Sleep(3000);

            string actual = loginPage.Header.GetAccountInfo();

            Assert.That(actual, Is.EqualTo(email));
        }

        [Test]
        public void NegativeTest()
        {
            MainPage mainPage = new MainPage(driver, wait);
            wait.Until(driver => mainPage.Head.Displayed);
            Thread.Sleep(1000);

            LoginPage loginPage = mainPage.Header.GoToLogin();
            wait.Until(driver => loginPage.LoginForm.Displayed);
            Thread.Sleep(1000);

            string email = "zzzzzzA@gmail.com";
            string password = "11111111";

            FillLoginForm(loginPage, email, password);

            loginPage.LoginClick();
            Thread.Sleep(3000);            

            string errorText = "Login was unsuccessful. Please correct the errors and try again.\r\nThe credentials provided are incorrect";
            string actual = loginPage.ErrorsText();

            Assert.That(actual, Is.EqualTo(errorText));
        }

    }
}
