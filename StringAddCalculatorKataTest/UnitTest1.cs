namespace StringAddCalculatorKataTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddTwoNumbersInString()
        {
            //Arrange
            string Number = "1";
            string Expected = Number;
            Test Calculator = new Test();

            //Act
            string Actual = Calculator.add(Number);

            //Assert
            Assert.Equal(Actual, Expected);

        }
    }
}