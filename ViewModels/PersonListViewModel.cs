using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using CSharpPractice4.Models;
using CSharpPractice4.Tools.Managers;
using CSharpPractice4.Tools.Navigation;

namespace CSharpPractice4.ViewModels
{
    internal class PersonListViewModel:INotifyPropertyChanged
    {
        #region Fields
        private static readonly List<string> WesternSignsList = new List<string>{ "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn","Default" };
        private static readonly List<string> ChineseSignsList = new List<string>{ "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Default" };
        private static readonly List<string> SortFieldsList= new List<string>{"Name","Surname","Email","Birthday Date","Birthday","Adult","Western Sign", "Chinese Sign", "No sort"};
        private string _sortBy;
        private ObservableCollection<Person> _persons;
        private Person _selectedPerson;
        private bool _isAdultSelected;
        private bool _isBirthdayTodaySelected;
        private string _westernSignSelected;
        private string _chineseSignSelected;
        private RelayCommand<object> _applyFilters;
        private RelayCommand<object> _discardFilters;
        private RelayCommand<object> _removePersonCommand;
        private RelayCommand<object> _addPersonCommand;


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

        public Person SelectedPerson
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

        public bool IsAdultSelected
        {
            get { return _isAdultSelected; }
            set { _isAdultSelected = value; }
        }

        public bool IsBirthdayTodaySelected
        {
            get { return _isBirthdayTodaySelected; }
            set { _isBirthdayTodaySelected = value; }
        }

        public static List<string> WesternSigns
        {
            get { return WesternSignsList; }
            
        }

        public static List<string> ChineseSigns
        {
            get { return ChineseSignsList; }
        }

        public RelayCommand<object> ApplyFilters
        {
            get
            {
                return _applyFilters ?? (_applyFilters = new RelayCommand<object>((obj) => {
                    FilterPersons();
                }));
            }
        }

        public RelayCommand<object> DiscardFilters
        {
            get
            {
                return _discardFilters ?? (_discardFilters = new RelayCommand<object>((obj) => {
                    Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
                    //WesternSignSelected = "Default";
                    //ChineseSignSelected = "Default";
                    //IsAdultSelected = false;
                    //IsBirthdayTodaySelected = false;
                }));
            }
        }

        public RelayCommand<object> RemovePersonCommand
        {
            get
            {
                return _removePersonCommand ?? (_removePersonCommand = new RelayCommand<object>(RemovePerson, CanRemoveExecute));
            }
        }

        public RelayCommand<object> AddPersonCommand
        {
            get
            {
                return _addPersonCommand ?? (_addPersonCommand = new RelayCommand<object>((obj) => {
                    NavigationManager.Instance.Navigate(ViewType.AddPerson);
                }));
            }

        }

        private bool CanRemoveExecute(object obj)
        {
            return _selectedPerson != null;
        }

        

        public string WesternSignSelected
        {
            get { return _westernSignSelected; }
            set { _westernSignSelected = value; }
        }

        public string ChineseSignSelected
        {
            get { return _chineseSignSelected; }
            set { _chineseSignSelected = value; }
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


        #region Helping methods

      

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
                    Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
                    break;
            }

        }

        private void FilterPersons()
        {
            Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            if (_isAdultSelected)
            {
                Persons = new ObservableCollection<Person>(from person in _persons
                    where (person.IsAdult == "Adult")
                    select person);
            }

            if (_isBirthdayTodaySelected)
            {
                Persons = new ObservableCollection<Person>(from person in _persons
                    where (person.IsBirthdayToday == "Today")
                    select person);
            }

            if (_westernSignSelected != "Default"&& _westernSignSelected != null)
            {
                Persons = new ObservableCollection<Person>(from person in _persons
                    where person.WesternSign == WesternSignSelected
                    select person);
            }
            if (_chineseSignSelected != "Default" && _chineseSignSelected != null)
            {
                Persons = new ObservableCollection<Person>(from person in _persons
                    where person.ChineseSign == ChineseSignSelected
                    select person);
            }
        }

        private void RemovePerson(object obj)
        {
            StationManager.DataStorage.RemovePerson(_selectedPerson);
            _persons.Remove(_selectedPerson);
            OnPropertyChanged(nameof(_persons));
        }

        #endregion
    }
}
