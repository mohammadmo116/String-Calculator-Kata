using StringAddCalculatorKata;
using Xunit.Sdk;

namespace StringAddCalculatorKataTest
{
    public class StringAdditionTest
    {
        private StringAddition _obj;
        public StringAdditionTest()
        {
            _obj = new StringAddition();
        }

        [Theory]
        //step1
        [InlineData(" ", 0)]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        //step2
        [InlineData("15,9,,7", 31)]
        [InlineData("15,9, ,8, ", 32)]
        //step3
        [InlineData("2\n12\n4", 18)]
        [InlineData("2\n12\n", 14)]
        [InlineData("1\n2,4", 7)]
        //step4
        [InlineData("//;\n1;2", 3)]
        [InlineData("//t\n1t12", 13)]
        [InlineData("//?\n1?3?7", 11)]  
        public void EmptyString_ReturnZeroTest(string Input, int Expected)
        {
            //Act
            int Actual = _obj.AddNumbersInString(Input);

            //Assert
            Assert.Equal(Expected, Actual);
        }
        
        [Theory]
        //step3
        [InlineData("2\n12,\n1")]
        [InlineData("2\n12\n,4\n")]
        //step4
        [InlineData("//?\n1?3?\n7")]
        [InlineData("//?\n1?3\n?7")]
        public void HandleNotValidInputTest(string Input)
        {
            //Act
            void Act() => _obj.AddNumbersInString(Input);

            //Assert
            Assert.Throws<ArgumentException>(nameof(Input), Act);
        }
   


    }
}