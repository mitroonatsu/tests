using System;
using UnitTestExample;

namespace CalculatorUi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var x = double.MaxValue;
            var y = double.MaxValue;
            Console.WriteLine(Calculator.Add(x,y));
            Console.ReadLine();
        }
    }
}
