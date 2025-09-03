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


        public static void DropdownSelectText(IWebDriver driver, By locator, string text)
        {
            SelectElement element = new SelectElement(driver.FindElement(locator));
            element.SelectByText(text);
       
        }

        public static void MultiSelect(IWebDriver driver, By locator, string[] values)
        {
            SelectElement multiSelectElement = new SelectElement(driver.FindElement(locator));
  
            foreach (var value in values)
            {
                multiSelectElement.SelectByValue(value);
            }
        }

        public static List<string> GetAllSelectedList(IWebDriver driver, By locator)
        {
            SelectElement multiSelectElement = new SelectElement(driver.FindElement(locator));
            List<string> result = new List<string>();

            IList<IWebElement> selectedOption = multiSelectElement.AllSelectedOptions;

            foreach (var option in selectedOption)
            {
                result.Add(option.Text);
            }

            return result;

        }

    }
}
