using System.Text.RegularExpressions;

namespace StringAddCalculatorKata
{
    public class StringAddition
    {
        private char _Delimiter;
        private List<int> _NegativeNumbers;

        public StringAddition()
        {
            _Delimiter = ',';
            _NegativeNumbers = new List<int>();

        }

        public int AddNumbersInString(string Input)
        {
            if (string.IsNullOrWhiteSpace(Input))
                return 0;

            if (Input.Length > 4)
                CheckCustomDelimiter(ref Input);

            if (_Delimiter == '-')
                throw new ArgumentException($"Negative Separator '-' is Not Allowed");

            if (HasInvalidDelimiter(Input))
                throw new ArgumentException("Not Valid Separator", nameof(Input));

            int total = SumOfNumbers(Input);
            if (_NegativeNumbers.Any())
                throw new ArgumentException($"Negatives Are Not Allowed: {string.Join(',', _NegativeNumbers)}");
            return total;
        }

        public string CheckCustomDelimiter(ref string Input)
        {
            Regex rx = new("//[\\s\\S]\\n");
            if (rx.IsMatch(Input[..4]))
            {
                _Delimiter = Input[2];
                Input = Input[4..];
            }

            return Input;
        }


        public bool HasInvalidDelimiter(string Input)
        {
            return Input.Contains($"{_Delimiter}\n") || Input.Contains($"\n{_Delimiter}");
        }

        private int SumOfNumbers(string Input)
        {
            return Input.Split(_Delimiter, '\n')
                        .Aggregate(0, (total, value) =>
                        {
                            if (Input.Contains('-'))
                            {
                                if (value.Contains('-'))
                                    _NegativeNumbers.Add(Convert.ToInt32(value));
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


