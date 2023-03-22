namespace StringAddCalculatorKata
{
    public static class StringAddition
    {
        public static int AddNumbersInString(this string Number)
        {
            if (string.IsNullOrWhiteSpace(Number))
                return 0;

            return Number.Split(",")
                         .Aggregate(0, (total, value) =>
                             string.IsNullOrWhiteSpace(value) ?
                                total : total + Convert.ToInt32(value));

        }
    }

}

