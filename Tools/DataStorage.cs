
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpPractice4.Models;
using CSharpPractice4.Tools.Managers;

namespace CSharpPractice4.Tools
{

    internal class DataStorage
    {
        private readonly List<Person> _persons;

        internal DataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
                for (int i = 0; i < 50; i++)
                {
                    _persons.Add(RandomPersonGenerator.GeneratePerson());
                }
                SaveChanges();
            }
        }

        public void AddUser(Person person)
        {
            _persons.Add(person);
            SaveChanges();
        }

        public List<Person> UsersList
        {
            get { return _persons.ToList(); }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }

        private void GeneratePersons()
        {

        }
    }
}
