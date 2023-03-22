using System.Linq;

namespace StringAddCalculatorKata
{
    public static class StringAddition
    {
        public static int AddNumbersInString(this string Input)
        {
            if (string.IsNullOrWhiteSpace(Input))
                return 0;
            if (Input.Contains(",\n") || Input.Contains("\n,"))
                throw new ArgumentException("Not Valid String", nameof(Input));
            return Input.Split(',', '\n')
                         .Aggregate(0, (total, value) =>
                             string.IsNullOrWhiteSpace(value) ?
                                total : total + Convert.ToInt32(value));

        }
       

       

     
     

    }

}

