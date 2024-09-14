using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SeleniumUItest
{
    [TestClass]
    public class SampleTest1
    {
        IWebDriver driver;
        [TestInitialize]
        public void Init() 
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.Manage().Window.Maximize();
        }



        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                string title = driver.Title;
                Assert.AreEqual(title, "Demo Web Shop");
                driver.FindElement(By.ClassName("ico-register")).Click();
                string registertitle = driver.Title;
                Assert.AreEqual(registertitle, "Demo Web Shop. Register");
                driver.FindElement(By.Id("gender-female")).Click();
                driver.FindElement(By.Id("FirstName")).SendKeys("DJ");
                driver.FindElement(By.Id("LastName")).SendKeys("k");
                driver.FindElement(By.Id("Email")).SendKeys("u.djrani@gmail.com");
                driver.FindElement(By.Id("Password")).SendKeys("Test@123");
                driver.FindElement(By.Id("ConfirmPassword")).SendKeys("Test@123");
                driver.FindElement(By.Id("register-button")).Click();
                string message = driver.FindElement(By.ClassName("result")).Text;
                Assert.AreEqual(message, "Your registration completed");

                IWebElement emailaccount = driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a"));
                Assert.IsTrue(emailaccount.Displayed);

                driver.FindElement(By.ClassName("ico-logout")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
            [TestCleanup]
            public void Closebrowser()
        {
            driver.Close();
        }

    }
}
