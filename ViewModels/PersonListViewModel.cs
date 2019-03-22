using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using CSharpPractice4.Models;
using CSharpPractice4.Tools.Managers;

namespace CSharpPractice4.ViewModels
{
    internal class PersonListViewModel:INotifyPropertyChanged
    {
        #region Fields

        private static readonly List<string> SortFieldsList= new List<string>{"Name","Surname","Email","Birthday Date","Birthday","Adult","Western Sign", "Chinese Sign", "No sort"};
        private string _sortBy;
        private ObservableCollection<Person> _persons;
        private static Person _selectedPerson;

        #endregion

        #region Properties
        
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        public static Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
            }
        }

        public string SortBy
        {
            get { return _sortBy; }
            set
            {
                _sortBy = value;
                SortPersons();
            }
        }

        public static List<string> SortFields
        {
            get { return SortFieldsList; }
           
        }

        #endregion

        internal PersonListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
        }


        #region  INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        private void SortPersons()
        {
            switch (_sortBy)
            {
                case "Name":
                    Persons = new ObservableCollection<Person>(from person in _persons
                        orderby person.Name 
                        select person);
                    break;
                case "Surname":
                    Persons = new ObservableCollection<Person>(from person in _persons
                        orderby person.Surname
                        select person);
                    break;
                case "Email":
                    Persons = new ObservableCollection<Person>(from person in _persons
                        orderby person.Email
                        select person);
                    break;
                case "Birthday Date":
                    Persons = new ObservableCollection<Person>(from person in _persons
                        orderby person.Birthday
                        select person);
                    break;
                case "Birthday":
                    Persons = new ObservableCollection<Person>(from person in _persons
                        orderby person.IsBirthdayToday
                        select person);
                    break;
                case "Adult":
                    Persons = new ObservableCollection<Person>(from person in _persons
                        orderby person.IsAdult
                        select person);
                    break;
                case "Western Sign":
                    Persons = new ObservableCollection<Person>(from person in _persons
                        orderby person.WesternSign
                        select person);
                    break;
                case "Chinese Sign":
                    Persons = new ObservableCollection<Person>(from person in _persons
                        orderby person.ChineseSign
                        select person);
                    break;
                default:
                    _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
                    break;
            }

        }

    }
}
