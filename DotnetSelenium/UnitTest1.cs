using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public class Tests
    {
        IWebDriver driver;
        
        public string homeurl;
        private string userName;
        private string passWord;
        private string google_url;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
            homeurl = TestContext.Parameters["home_url"];
            userName = TestContext.Parameters["username"];
            passWord = TestContext.Parameters["password"];
            google_url = TestContext.Parameters["google_url"];

        }

        [Test]
        public void GoogleChromeTest()  
        { 
            driver.Navigate().GoToUrl(google_url);
            
            IWebElement SearchInput = driver.FindElement(By.Name("q"));
            SearchInput.SendKeys("Panda"); SearchInput.SendKeys(Keys.Return);
        }

        [Test]
        public void EaAppTest()
        {
            driver.Navigate().GoToUrl(homeurl);

            SeleniumCustomMethods.Click(driver, By.Id("loginLink"));
            SeleniumCustomMethods.EnterText(driver, By.Id("UserName"), userName);
            SeleniumCustomMethods.EnterText(driver, By.Name("Password"), passWord);
            SeleniumCustomMethods.Submit(driver, By.Id("loginIn"));


            //IWebElement LoginBtn = driver.FindElement(By.Id("loginLink"));
            //LoginBtn.Click();

            //IWebElement UsernameInput = driver.FindElement(By.Id("UserName"));
            //IWebElement PasswordInput = driver.FindElement(By.Name("Password"));
            //IWebElement SubmitBtn = driver.FindElement(By.Id("loginIn"));
            //SubmitBtn.Click();


        }

        [Test]
        public void WorkingWithDropdown() 
        
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            //var selectElement = driver.FindElement(By.Name("Service"));
            //var select = new SelectElement(selectElement);

            // select.SelectByText("Interest Classes");

           SeleniumCustomMethods.DropdownSelect(driver, By.Name("Service"), "Child Care");
            Thread.Sleep(2000);

        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}