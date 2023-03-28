using OpenQA.Selenium;
using System.Globalization;
using static System.Net.WebRequestMethods;
namespace WebDriverCalculatorPOM.Pages
{
    public class SumNumbersPage
    {
        private WebDriver driver;
        private const string baseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        public SumNumbersPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FieldOne => driver.FindElement(By.Id("number1"));
        //public IWebElement FieldOne { get { return driver.FindElement(By.Id("number1")); } }
        public IWebElement FieldTwo => driver.FindElement(By.Id("number2"));
        public IWebElement OperationField => driver.FindElement(By.Id("operation"));
        public IWebElement CalcButton => driver.FindElement(By.Id("calcButton"));
        public IWebElement ResetButton => driver.FindElement(By.Id("resetButton"));
        public IWebElement ResultButton => driver.FindElement(By.Id("result"));
        public IWebElement ResultLabel => driver.FindElement(By.XPath("//*[@id=\"result\"]/pre"));

        public void Open()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public bool IsPageOpen()
        {
            return driver.Url == baseUrl;
        }

        public string CalculateNumbers(string firstValue, string operation, string secondValue)
        {
            FieldOne.SendKeys(firstValue);
            OperationField.SendKeys(operation);
            FieldTwo.SendKeys(secondValue);
            CalcButton.Click();

            return ResultButton.Text;
        }

        public string CalculateNumbersValue(string firstValue, string operation, string secondValue)
        {
            FieldOne.SendKeys(firstValue);
            OperationField.SendKeys(operation);
            FieldTwo.SendKeys(secondValue);
            CalcButton.Click();

            return ResultLabel.Text;
        }

        public bool IsFormEmpty()
        {
            bool empty = (FieldOne.Text == "" && FieldTwo.Text == "");
            return empty;
        }

        public void ResetForm()
        {
            ResultButton.Click();
        }

    }
}
