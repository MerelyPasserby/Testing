using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2Tests
{
    [TestFixture]
    internal class LogoutTests : BaseTests
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

            loginPage.Header.LogOut();
            Thread.Sleep(1000);

            bool actual = loginPage.Header.IsAccountInfoAvailable();

            Assert.That(actual, Is.False);

        }

        [Test]
        public void NegativeTest()
        {
            MainPage mainPage = new MainPage(driver, wait);
            wait.Until(driver => mainPage.Head.Displayed);
            Thread.Sleep(1000);

            bool actual = mainPage.Header.IsLogOutAvailable();

            Assert.That(actual, Is.False);
        }
    }
}
