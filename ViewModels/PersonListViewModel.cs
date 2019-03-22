using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CSharpPractice4.Models;
using CSharpPractice4.Tools.Managers;

namespace CSharpPractice4.ViewModels
{
    internal class PersonListViewModel:INotifyPropertyChanged
    {
        #region Fields

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
    }
}
