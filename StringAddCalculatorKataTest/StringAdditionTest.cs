using StringAddCalculatorKata;

namespace StringAddCalculatorKataTest
{
    public class StringAdditionTest
    {
        [Fact]
        public void AddNumbersInStringTest()
        {
            //Arrange
            string Number = "1";
            int Expected = 1;
           
            //Act
            int Actual = Number.AddNumbersInString();

            //Assert
            Assert.Equal(Actual, Expected);

        }
    }
}