using DotnetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace DotnetSelenium
{
    [TestFixture("admin", "password")]
    //[TestFixture("admin1", "password1")]
    //[TestFixture("admin2", "password2")]
    public class NUnitTestsDemo
    {
        private IWebDriver _driver;

        public string homeurl;
        public string ehr;
        private string _userName;
        private string _passWord;


        private readonly string otherUsername;
        private readonly string otherPassword;


        public NUnitTestsDemo(string otherUsername, string otherPassword)
        {
            this.otherUsername = otherUsername;
            this.otherPassword = otherPassword;
        }

        [SetUp]
        public void SetUp()
        {
             homeurl = TestContext.Parameters["home_url"];
            _userName = TestContext.Parameters["username"];
            _passWord = TestContext.Parameters["password"];
            ehr = TestContext.Parameters["ehr_url"];

            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(homeurl);
            _driver.Manage().Window.Maximize();

        }

        [Test]
        public void CheckEHR()
        {
            //check ehr url if accessible
        }

        [Test]
        public void TestWithPOM()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(otherUsername, otherPassword);
            loginPage.CheckLogin();

        }

        [Test]
        [TestCase("Chrome", "30")]
        public void TestBrowserVersion(string a, string b)
        {
            Console.WriteLine($"The version of you {a} is version {b}.");
        }


        [TearDown]
        public void TearDown()
        {

            _driver.Close();
        }

    }
}
