using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CSharpPractice4.Models;
using CSharpPractice4.Tools.Exceptions;
using CSharpPractice4.Tools.Managers;
using CSharpPractice4.Tools.Navigation;

namespace CSharpPractice4.ViewModels
{
    internal class AddPersonViewModel
    {

        #region Fields

        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _returnCommand;

        #endregion

        #region Properties

        public string Name { set; get; }

        public string Surname { set; get; }

        public string Email { set; get; }

        public DateTime Birthday { set; get; }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(ProceedInput, CanProceedExecute));
            }
        }

        public RelayCommand<object> ReturnCommand
        {
            get
            {
                return _returnCommand ?? (_returnCommand = new RelayCommand<object>((obj) =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.List);
                           }));
            }
           
        }

        private bool CanProceedExecute(object obj)
        {

            return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Surname) && !String.IsNullOrWhiteSpace(Email) && !(Birthday == default(DateTime));
        }

        

        #endregion




        

        private async void ProceedInput(object obj)
        {
            Person person = null;
            //LoaderManager.Instance.ShowLoader();
            //var result =
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                try
                {
                    person = new Person(Name,Surname,Email,Birthday);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                   // return false;
                }
                //return true;
            });
            //LoaderManager.Instance.HideLoader();
            //if (!result) return;
            if (person != null)
            {
                StationManager.DataStorage.AddPerson(person);
                NavigationManager.Instance.Navigate(ViewType.List);
            }

            //NavigationManager.Instance.Navigate(ViewType.Output);
        }



        internal AddPersonViewModel()
        {
            //LoaderManager.Instance.Initialize(this);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
