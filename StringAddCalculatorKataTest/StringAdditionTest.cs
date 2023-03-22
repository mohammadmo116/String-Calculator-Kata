using StringAddCalculatorKata;
using Xunit.Sdk;

namespace StringAddCalculatorKataTest
{
    public class StringAdditionTest
    {

        [Theory]
        [InlineData(" ", 0)]
        [InlineData("", 0)]
        public void EmptyString_ReturnZeroTest(string Input, int Expected)
        {
            //Act
            int Actual = Input.AddNumbersInString();

            //Assert
            Assert.Equal(Expected, Actual);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
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
        [InlineData("15,,9,,7", 31)]
        [InlineData("15,9,,7", 31)]
        [InlineData("15,9, ,8, ", 32)]
        public void AddMultipleNumbersInStringTest(string Input, int Expected)
        {
            //Act
            int Actual = Input.AddNumbersInString();

            //Assert
            Assert.Equal(Expected, Actual);
        }

        [Theory]
        [InlineData("1,2\n3",6)]
        [InlineData("1\n2,4",7)]
        [InlineData("2\n12\n4",18)]
        [InlineData("2\n12\n", 14)]   
        public void HandleNewLineTest(string Input, int Expected)
        {
            //Act
            int Actual = Input.AddNumbersInString();

            //Assert
            Assert.Equal(Expected, Actual);
        }
        [Theory]
        [InlineData("2\n12,\n1")]
        [InlineData("2\n12\n,4\n")]
        public void HandleNotValidInputTest(string Input)
        {
            //Act
            void Act() => Input.AddNumbersInString();

            //Assert
            Assert.Throws<ArgumentException>(nameof(Input),Act);
        }

    }
}