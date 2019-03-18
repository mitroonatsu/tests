using System;
using UnitTestExample;
using UnitTestExample.Models;

namespace CalculatorUi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //var x = double.MaxValue;
            //var y = double.MaxValue;
            //Console.WriteLine(Calculator.Add(x,y));
            //Console.ReadLine();

            PersonModel newPerson = new PersonModel { FirstName = "Pelle", LastName = "Peloton", Age = 90 };
            DataAccess.AddNewPerson(newPerson);

            var people = DataAccess.GetAllPeople();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName}-{person.LastName}-{person.Age}");
            }
            Console.ReadLine();
        }
    }
}
