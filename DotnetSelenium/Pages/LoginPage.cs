using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium.Pages
{
    public  class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        IWebElement Loginlink => driver.FindElement(By.Id("loginLink"));

        IWebElement UsernameTxt => driver.FindElement(By.Id("UserName"));
        IWebElement PasswordTxt => driver.FindElement(By.Name("Password"));

        IWebElement BtnLogin => driver.FindElement(By.Id("loginIn"));

        public void ClickLogin()
        {
            Loginlink.Click(); 
        } 

        public void Login(string username, string password)
        {
            UsernameTxt.SendKeys(username);
            PasswordTxt.SendKeys(password);
            BtnLogin.Click();
        }
    }
}
