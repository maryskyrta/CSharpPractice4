using CSharpPractice4.Tools.Managers;
using CSharpPractice4.Tools.Navigation;
using CSharpPractice4.Views;

namespace CSharpPractice4.ViewModels
{
    internal class MainViewModel
    {
        private RelayCommand<object> _removePersonCommand;
        private RelayCommand<object> _addPersonCommand;

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
                return _addPersonCommand ?? (_addPersonCommand =  new RelayCommand<object>((obj)=>{
                    NavigationManager.Instance.Navigate(ViewType.AddPerson);
                }));
            }
            
        }

        private static bool CanRemoveExecute(object obj)
        {
            return PersonListViewModel.SelectedPerson != null;
        }

        private void RemovePerson(object obj)
        {
            StationManager.DataStorage.RemovePerson(PersonListViewModel.SelectedPerson);
            
            //PersonList.
            //NavigationManager.Instance.Navigate(ViewType.Main);
        }

        

    }
}
