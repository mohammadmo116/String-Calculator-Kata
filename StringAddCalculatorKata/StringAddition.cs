using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAddCalculatorKata
{
    public static class StringAddition
    {
        public static int AddNumbersInString(this string Number)
        {
            if(string.IsNullOrWhiteSpace(Number))
                return 0;

            return Number.Split(",")
                         .Aggregate(0,(total, value) =>
                                      total + Convert.ToInt32(value));
               
        }
    }

}

