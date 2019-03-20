using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSharpPractice4.Models;

namespace CSharpPractice4.ViewModels
{
    internal class PersonListViewModel:INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Person> _persons;

        #endregion

        #region Properties
        
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region  INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
