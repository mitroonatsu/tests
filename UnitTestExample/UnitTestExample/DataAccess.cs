using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnitTestExample.Models;

namespace UnitTestExample
{
    public class DataAccess
    {
        private static string personDataFile = @"C:\Windows\temp\PersonTextFile.txt";

        public static void AddNewPerson(PersonModel person)
        {
           
            List<PersonModel> people = GetAllPeople();
            AddPersonToPeopleList(people, person);
           
            var lines = ConvertModelsToCsv(people);
            File.WriteAllLines(personDataFile, lines);
        }
        public static void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
        {
            if (string.IsNullOrEmpty(person.FirstName))
            {
                throw new ArgumentException("Etunimi puuttuu", "FirstName");
            }
            if (string.IsNullOrEmpty(person.LastName))
            {
                throw new ArgumentException("Sukunimi puuttuu", "LastName");
            }
            if (person.Age <= 0)
            {
                throw new ArgumentException("Ikä puuttuu", "Age");
            }
            people.Add(person);
        }
        public static List<string> ConvertModelsToCsv(List<PersonModel> people)
        {
            List<string> output = new List<string>();
            foreach (var user in people)
            {
                output.Add($"{user.FirstName}, {user.LastName}, {user.Age}");
            }
            return output;
        }

        public static List<PersonModel> GetAllPeople()
        {

            List<PersonModel> output = new List<PersonModel>();
            try
            {
                string[] content = File.ReadAllLines(personDataFile);

                foreach (var line in content)
                {
                    string[] data = line.Split(',');
                    output.Add(new PersonModel { FirstName = data[0].Trim(), LastName = data[1].Trim(), Age = int.Parse(data[2]) });
                    //output.Add(new PersonModel(data[0], data[1]));
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }
    }
}
