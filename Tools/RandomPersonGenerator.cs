using System;
using CSharpPractice4.Models;

namespace CSharpPractice4.Tools
{
    internal static class RandomPersonGenerator
    {
        private static readonly string[] Names = {"Ann", "Brad", "Angelina", "Jennifer", "Charlize", "Tom", "Nicole", "Johnny", "Leonardo", "Woody", "Christian", "Tom", "Michael", "Homer", "Ryan", "Emma", "Blake", "Matthew", "Sandra", "Natalie" };
        private static readonly string[] Surnames = {"Hathaway","Pitt", "Jolie", "Aniston", "Theron", "Cruise", "Kidman", "Depp", "DiCaprio", "Harrelson", "Bale", "Hanks", "Fassbender", "Simpson", "Gosling", "Stone", "Lively", "McConaughey", "Bullock", "Portman"};
        private static readonly Random Rand = new Random();

        internal static Person GeneratePerson()
        {
            int name = Rand.Next(Names.Length);
            int surname = Rand.Next(Surnames.Length);
            string email = $"{Names[name].ToLower()}{Surnames[surname].ToLower()}@mail.com";
            int year = Rand.Next(1884,2019);
            int day = Rand.Next(1, 28);
            int month = Rand.Next(1,12);
            DateTime birthday =  new DateTime(year,month,day);
            if (birthday > DateTime.Today)
                birthday = DateTime.Today;
            return new Person(Names[name], Surnames[surname], email, birthday);

        }
    }
}
