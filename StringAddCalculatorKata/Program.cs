// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
bool _Negative = false;
bool _Next = false;
List<int> _NegativeNumbers = new List<int>();
string a="1,2,-3";
if(a.Contains("-")) _Negative=true;
a.Split(',')
  .Aggregate(0, (total, value) =>
  {
     
      if (value.Contains('-'))
          Console.WriteLine(value[1]);
    
      return total;


  });



