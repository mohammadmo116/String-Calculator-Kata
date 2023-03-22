using System.Linq;

namespace StringAddCalculatorKata
{
    public static class StringAddition
    {
        public static int AddNumbersInString(this string Input)
        {
            if (string.IsNullOrWhiteSpace(Input))
                return 0;
            if (Input.HasNotValidSeparator())
                throw new ArgumentException("Not Valid Separator", nameof(Input));
            return SumOfNumbers(Input);

        }

        private static bool HasNotValidSeparator(this string Input)
        {
            return Input.Contains(",\n") || Input.Contains("\n,");
        }
        private static int SumOfNumbers(string Input)
        {
            return Input.Split(',', '\n')
                         .Aggregate(0, (total, value) =>
                             string.IsNullOrWhiteSpace(value) ?
                                total : total + Convert.ToInt32(value));
        }

    }

}

