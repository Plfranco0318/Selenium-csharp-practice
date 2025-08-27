using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public class SeleniumCustomMethods
    {

        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).Click();
            driver.FindElement(locator).SendKeys(text);

        }

        public static void Submit(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Submit();
        }


        public static void DropdownSelect(IWebDriver driver, By locator, string dropdownElement)
        {
            IWebElement element = driver.FindElement(locator);
            var select = new SelectElement(element);

            select.SelectByText(dropdownElement);
        }

    }
}
