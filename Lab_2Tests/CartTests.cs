using Lab2Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.Clients;

namespace Lab_2Tests
{
    [TestFixture]
    internal class CartTests : BaseTests
    {
        void FillProductForm(ProductPage productPage, string resName, string resEmail,string sendName, string sendEmail)
        {
            productPage.InputRecName(resName);
            Thread.Sleep(1000);
            productPage.InputRecEmail(resEmail);
            Thread.Sleep(1000);
            productPage.InputSendName(sendName);
            Thread.Sleep(1000);
            productPage.InputSendEmail(sendEmail);
            Thread.Sleep(1000);
        }

        [Test]
        public void PositiveTest()
        {
            MainPage mainPage = new MainPage(driver, wait);
            wait.Until(driver => mainPage.Head.Displayed);
            Thread.Sleep(1000);

            ProductPage productPage = mainPage.GoToProduct();
            wait.Until(driver => productPage.ProductForm.Displayed);
            Thread.Sleep(1000);

            string resName = "A D";
            string resEmail = "zzzzzzA@gmail.com";
            string sendName = "A D";
            string sendEmail = "zzzqqqaaa@gmail.com";

            string prodName = productPage.GetProductName();

            FillProductForm(productPage, resName, resEmail, sendName, sendEmail);

            productPage.AddToCartClick();
            Thread.Sleep(1000);

            CartPage cartPage = productPage.Header.GoToCart();
            wait.Until(driver => cartPage.Cart.Displayed);
            Thread.Sleep(1000);

            string actual = cartPage.GetCartElementInfo();

            Assert.That(actual, Is.EqualTo(prodName));
        }

        [Test]
        public void NegativeTest()
        {
            MainPage mainPage = new MainPage(driver, wait);
            wait.Until(driver => mainPage.Head.Displayed);
            Thread.Sleep(1000);

            ProductPage productPage = mainPage.GoToProduct();
            wait.Until(driver => productPage.ProductForm.Displayed);
            Thread.Sleep(1000);

            string resName = "A D";
            string resEmail = "";
            string sendName = "A D";
            string sendEmail = "zzzqqqaaa@gmail.com";

            FillProductForm(productPage, resName, resEmail, sendName, sendEmail);

            productPage.AddToCartClick();
            Thread.Sleep(1000);

            string errorText = "Enter valid recipient email";
            string actual = productPage.ErrorsText().Trim();

            Assert.That(actual, Is.EqualTo(errorText));
        }
    }
}
