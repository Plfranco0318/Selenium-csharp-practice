using OpenQA.Selenium;

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

        IWebElement LoginTxt => driver.FindElement(By.XPath("//div/h2"));

        public void ClickLogin()
        {
            Loginlink.ClickElement();
        } 


        public void CheckLogin()
        {
            string AssertText = LoginTxt.Text;
            Console.WriteLine(AssertText);
        }


        public void Login(string username, string password)
        {
            //SeleniumCustomMethods.EnterText(UsernameTxt, username);
            //SeleniumCustomMethods.EnterText(PasswordTxt, password);

            ////BtnLogin.Click();
            //SeleniumCustomMethods.SubmitForm(BtnLogin);

            UsernameTxt.EnterText(username);
            PasswordTxt.EnterText(password);
            BtnLogin.SubmitElement();
        }
    }
}
