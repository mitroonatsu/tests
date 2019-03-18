using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using UnitTestExample.Models;
using UnitTestExample;


namespace DemoTests
{
    public class DataAccessTests
    {
        [Theory]
        [InlineData("", "Bond", 55, "FirstName")]
        [InlineData("James", "", 55, "LastName")]
        [InlineData("James", "Bond", null, "Age")]
        [InlineData("James", "Bond", 0, "Age")]
        [InlineData("James", "Bond", -55, "Age")]
        [InlineData(null, "Bond", 55, "FirstName")]
        [InlineData("James", null, 55, "LastName")]
        
        public void AddPersonToPeopleList_ShouldAddNewPerson_ReturnThrows(
            string firstName, string lastName, int age, string param)
        {
            //Arrange
            PersonModel newPerson = new PersonModel {
                FirstName = firstName, LastName = lastName, Age = age };
            List<PersonModel> people = new List<PersonModel>();
            //Act
            //DataAccess.AddPersonToPeopleList(people, newPerson);
            //Assert
            Assert.Throws<ArgumentException>(param, () =>
            DataAccess.AddPersonToPeopleList(people, newPerson));
            //Assert.Contains<PersonModel>(newPerson, people);
        }

        [Fact]
        public void ConvertModelsToCsv_ShouldWork_ReturnEqual()
        {
            PersonModel newPerson0 = new PersonModel
            {
                FirstName = "James",
                LastName = "Bond",
                Age = 55
            };
            PersonModel newPerson1 = new PersonModel
            {
                FirstName = "Henri",
                LastName = "XXX",
                Age = 60
            };
            List<PersonModel> people = new List<PersonModel>();
            people.Add(newPerson0);
            people.Add(newPerson1);
            List<string> expected = new List<string> { "James, Bond, 55", "Henri, XXX, 60" };
            var actual = DataAccess.ConvertModelsToCsv(people);
            Assert.Equal(expected, actual);
        }
    }
}
