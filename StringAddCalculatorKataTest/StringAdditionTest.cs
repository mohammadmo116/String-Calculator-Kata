using StringAddCalculatorKata;

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
        //step6
        [InlineData("15,9,,10001", 24)]
        [InlineData("//t\n1t1000", 1001)]
        [InlineData("//?\n1005?3?7", 10)]
        public void AddNumbersInString(string input, int Expected)
        {
            //Act
            int Actual = _obj.GetSumNumbersFromString(input);

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
        public void NotValidInputThrowException(string input)
        {
            //Act
            void Act() => _obj.GetSumNumbersFromString(input);

            //Assert
            Assert.Throws<ArgumentException>(nameof(input), Act);
        }



        //step5
        [Theory]
        [InlineData("1,-2", new int[] { -2 })]
        [InlineData("//;\n-1;2", new int[] { -1 })]
        [InlineData("//t\n-11t1t-2", new int[] { -11, -2 })]
        [InlineData("//?\n1?3?-7", new int[] { -7 })]

        public void NegativeInputThrowException(string input, int[] Expected)
        {
            //Act
            void Act() => _obj.GetSumNumbersFromString(input);
            //AssertActual
            ArgumentException Actual = Assert.Throws<ArgumentException>(Act);
            ArgumentException ExpectedException = new($"Negatives Are Not Allowed: {string.Join(',', Expected)}");

            Assert.Equal(Actual.Message, ExpectedException.Message);

        }




        [Theory]
        [InlineData("//-\n--11-1--2")]
        public void NegativeSeparatortThrowException(string input)
        {
            //Act
            void Act() => _obj.GetSumNumbersFromString(input);
            //Assert
            ArgumentException Exception = Assert.Throws<ArgumentException>(Act);
            ArgumentException Actual = new($"Negative Separator '-' is Not Allowed");

            Assert.Equal(Actual.Message, Exception.Message);

        }


    }
}