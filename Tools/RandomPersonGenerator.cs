using System;
using CSharpPractice4.Models;

namespace CSharpPractice4.Tools
{
    internal static class RandomPersonGenerator
    {
        private static readonly string[] Names = {"Ann", "Brad", "Angelina", "Jennifer", "Charlize", "Tom", "Nicole", "Johnny", "Leonardo", "Woody", "Christian", "Tom", "Michael", "Homer", "Ryan", "Emma", "Blake", "Matthew", "Sandra", "Natalie" };
        private static readonly string[] Surnames = {"Hathaway","Pitt", "Jolie", "Aniston", "Theron", "Cruise", "Kidman", "Depp", "DiCaprio", "Harrelson", "Bale", "Hanks", "Fassbender", "Simpson", "Gosling", "Stone", "Lively", "McConaughey", "Bullock", "Portman"};

        internal static Person GeneratePerson()
        {
            Random rand = new Random();
            int name = rand.Next(Names.Length);
            int surname = rand.Next(Surnames.Length);
            string email = $"{name}{surname}@mymail.com";
            int year = rand.Next(1884,2019);
            int month = rand.Next(1,12);
            int day = rand.Next(1, 365);
            DateTime birthday =  new DateTime(year, month,day);
            if (birthday > DateTime.Today)
                birthday = DateTime.Today;
            return new Person(Names[name], Surnames[surname], email, birthday);

        }
    }
}
