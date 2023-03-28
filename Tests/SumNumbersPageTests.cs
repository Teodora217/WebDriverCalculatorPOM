using NUnit.Framework;
using WebDriverCalculatorPOM.Pages;

namespace WebDriverCalculatorPOM.Tests
{
    public class SumNumbersPageTests : BaseTest
    {

        private SumNumbersPage page;

        [SetUp]
        public void Setup()
        {
            this.page = new SumNumbersPage(driver);
            page.Open();
        }

        [Test]
        public void Test_SumNumberPage_CheckTitle()
        {
            Assert.That(page.GetPageTitle(), Is.EqualTo("Number Calculator"));
        }

        //[Test]
        //public void Test_SumNumberPage_SumTwoPositiveNumbers()
        // {
        // var actualResult = page.CalculateNumbers("5", "+", "15");
        // Assert.That(actualResult, Is.EqualTo("Result: 20"));
        //}
        //[Test]
        //public void Test_SumNumberPage_MultiplyTwoPositiveNumbers()
        //{
        //var actualResult = page.CalculateNumbers("5", "*", "15");
        //Assert.That(actualResult, Is.EqualTo("Result: 75"));
        //}
        [TestCase("5", "*", "15", "Result: 75")]
        [TestCase("5", "+", "15", "Result: 20")]
        [TestCase("5", "-", "15", "Result: -10")]
        [TestCase("15", "/", "3", "Result: 5")]
        [TestCase("aaa", "+", "bbb", "Result: invalid input")]
        public void Test_SumNumberPage_MultiplyTwoPositiveNumbers(
            string firstValue, string operation, string secondValue, string result)
        {
            var actualResult = page.CalculateNumbers(firstValue, operation, secondValue);
            Assert.That(actualResult, Is.EqualTo(result));
        }
        [Test]
        public void Test_SumNumberPage_CheckResetButton()
        {
            page.CalculateNumbers("6", "+", "8");
            page.ResetForm();
            Assert.True(page.IsFormEmpty());
        }

        [Test]
        public void Test_SumNumberPage_CheckResultValue()
        {
            var result = page.CalculateNumbersValue("6", "+", "8");
            Assert.That(result, Is.EqualTo("14"));

        }
    }
}