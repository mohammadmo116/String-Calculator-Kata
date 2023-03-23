using System.Text.RegularExpressions;

namespace StringAddCalculatorKata
{
    public class StringAddition
    {
        private char _delimiter;
        private List<int> _negativeNumbers;

        public StringAddition()
        {
            _delimiter = ',';
            _negativeNumbers = new List<int>();

        }

        public int GetSumNumbersFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))

            {
                return 0;
            }

            if (input.Length > 4)
            {
                ExtractDelimiter(ref input);
            }

            ValidateInput(input);
 
            int total = SumOfNumbers(input);
            if (_negativeNumbers.Any())
            {
                throw new ArgumentException($"Negatives Are Not Allowed: {string.Join(',', _negativeNumbers)}");
            }
            return total;
        }

        private void ExtractDelimiter(ref string input)
        {
            //;\n1;2;4
            Regex rx = new("//[\\s\\S]\\n");
            if (rx.IsMatch(input[..4]))
            {
                _delimiter = input[2];
                input = input[4..];
            }


        }
        private void ValidateInput(string input)
        {
            ValidateDelimiter();
            if (input.Contains($"{_delimiter}\n") || input.Contains($"\n{_delimiter}"))
            {
                throw new ArgumentException("Not Valid Separator", nameof(input));
            }
        }

        private void ValidateDelimiter()
        {
            if (_delimiter == '-')
            {
                throw new ArgumentException($"Negative Separator '-' is Not Allowed");
            }
        }

        private int SumOfNumbers(string input)
        {
            return input.Split(_delimiter, '\n')
                        .Aggregate(0, (total, value) =>
                        {
                            if (input.Contains('-'))
                            {
                                if (value.Contains('-'))
                                    _negativeNumbers.Add(Convert.ToInt32(value));
                                return total;
                            }
                            else
                            {
                                if (string.IsNullOrWhiteSpace(value) || Convert.ToInt32(value) > 1000)
                                    return total;
                                return total + Convert.ToInt32(value);
                            }
                        });
        }

    }
}


