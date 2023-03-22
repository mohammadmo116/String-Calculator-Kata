using System.Linq;
using System.Text.RegularExpressions;

namespace StringAddCalculatorKata
{
    public class StringAddition
    {
        private char _delimiter = ',';

        public int AddNumbersInString(string Input)
        {
            if (string.IsNullOrWhiteSpace(Input))
                return 0;
            if (Input.Length > 4)
                CheckCustomDelimiter(ref Input);
            if (HasInvalidSeparator(Input))
                throw new ArgumentException("Not Valid Separator", nameof(Input));
            return SumOfNumbers(Input);
        }

        public string CheckCustomDelimiter(ref string Input)
        {
            Regex rx = new("//[\\s\\S]\\n");
            if (rx.IsMatch(Input[..4]))
            {
                _delimiter = Input[2];
                Input = Input[4..];
            }
            return Input;
        }

        public bool HasInvalidSeparator(string Input)
        {
            return Input.Contains($"{_delimiter}\n") || Input.Contains($"\n{_delimiter}");
        }

        private int SumOfNumbers(string Input)
        {
            return Input.Split(_delimiter, '\n')
                         .Aggregate(0, (total, value) =>
                             string.IsNullOrWhiteSpace(value) ?
                                total : total + Convert.ToInt32(value));
        }

    }
}


