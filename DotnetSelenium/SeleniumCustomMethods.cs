using OpenQA.Selenium;

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

    }
}
