using DotnetSelenium.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DotnetSelenium
{
    public class DataDrivenTesting
    {
        private IWebDriver _driver;




        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();

        }


        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void TestWithPOM(LoginModel loginModel)
        {
            LoginPage loginPage = new LoginPage(_driver); 
            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.PassWord);

        }

        //public void TestPOMWithJsonFile()
        //{
        //    string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
        //    var jsonString = File.ReadAllText(jsonFilePath);

        //    var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

        //    LoginPage loginPage = new LoginPage(_driver);
        //    loginPage.ClickLogin();
        //    loginPage.Login(loginModel.UserName, loginModel.PassWord);

        //}

        //public static IEnumerable<LoginModel> Login()
        //{
        //    yield return new LoginModel()
        //    {
        //        UserName = "admin",
        //        PassWord = "password"

        //    };

        //    yield return new LoginModel()
        //    {
        //        UserName = "admins",
        //        PassWord = "password"

        //    };

        //    yield return new LoginModel()
        //    {
        //        UserName = "admin",
        //        PassWord = "passwords"

        //    };
        //}

        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);


            //if one in json only do not use list and foreach
            foreach(var loginData in loginModel)
            {
                yield return loginData;
            }

        }

        private void ReadJsonFile()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);
        }



        [TearDown]
        public void TearDown()
        {

            _driver.Close();
        }
    }
}
