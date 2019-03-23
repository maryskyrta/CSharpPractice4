using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpPractice4.Models;
using CSharpPractice4.Tools.Managers;
using CSharpPractice4.Tools.Navigation;

namespace CSharpPractice4.ViewModels
{
    internal class PersonListViewModel:INotifyPropertyChanged
    {
        #region Fields

        private string _sortBy;
        private ObservableCollection<Person> _persons;
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

        public Person SelectedPerson { get; set; }

        public string SortBy
        {
            get { return _sortBy; }
            set
            {
                _sortBy = value;
                SortPersons();
            }
        }

        public static List<string> SortFields { get; } = new List<string>{"Name","Surname","Email","Birthday Date","Birthday","Adult","Western Sign", "Chinese Sign", "No sort"};

        public bool IsAdultSelected { get; set; }

        public bool IsBirthdayTodaySelected { get; set; }

        public static List<string> WesternSigns { get; } = new List<string>{ "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn","Default" };

        public static List<string> ChineseSigns { get; } = new List<string>{ "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Default" };

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

        

        public string WesternSignSelected { get; set; }

        public string ChineseSignSelected { get; set; }

        #endregion

        #region Constructor

        internal PersonListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
        }

        #endregion



        #region  INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region Helping methods

        private bool CanRemoveExecute(object obj)
        {
            return SelectedPerson != null;
        }

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
            if (IsAdultSelected)
            {
                Persons = new ObservableCollection<Person>(from person in _persons
                    where (person.IsAdult == "Adult")
                    select person);
            }

            if (IsBirthdayTodaySelected)
            {
                Persons = new ObservableCollection<Person>(from person in _persons
                    where (person.IsBirthdayToday == "Today")
                    select person);
            }

            if (WesternSignSelected != "Default"&& WesternSignSelected != null)
            {
                Persons = new ObservableCollection<Person>(from person in _persons
                    where person.WesternSign == WesternSignSelected
                    select person);
            }
            if (ChineseSignSelected != "Default" && ChineseSignSelected != null)
            {
                Persons = new ObservableCollection<Person>(from person in _persons
                    where person.ChineseSign == ChineseSignSelected
                    select person);
            }
        }

        private void RemovePerson(object obj)
        {
            StationManager.DataStorage.RemovePerson(SelectedPerson);
            _persons.Remove(SelectedPerson);
            OnPropertyChanged(nameof(_persons));
        }

        #endregion
    }
}
