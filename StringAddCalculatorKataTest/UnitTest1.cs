using StringAddCalculatorKata;

namespace StringAddCalculatorKataTest
{
    public class UnitTest1
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