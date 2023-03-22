using Newtonsoft.Json.Linq;
using StringAddCalculatorKata;

namespace StringAddCalculatorKataTest
{
    public class StringAdditionTest
    {

        [Theory]
        [InlineData(" ", 0)]
        [InlineData("", 0)]
        public void IfStringIsEmptyShouldReturnZeroTest(string Input, int Expected)
        {
           //Act
            int Actual = Input.AddNumbersInString();

            //Assert
            Assert.Equal(Expected, Actual);
        }

        [Theory]
        [InlineData("1",1)]
        [InlineData("5", 5)]
        public void AddOneNumberInStringTest(string Input, int Expected)
        {
            //Act
            int Actual = Input.AddNumbersInString();

            //Assert
            Assert.Equal(Expected, Actual);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("15,9,7", 31)]
       
        public void AddMultipleNumbersInStringTest(string Input, int Expected)
        {
            //Act
            int Actual = Input.AddNumbersInString();

            //Assert
            Assert.Equal(Expected, Actual);
        }
        
    }
}