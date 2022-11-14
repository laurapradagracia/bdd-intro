
using IntroToBDD.Helpers;

namespace IntroToBDD.Test.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private Calculator calculator = new Calculator();
        private int result;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            result = calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            this.result.Should().Be(result);
        }
    }
}