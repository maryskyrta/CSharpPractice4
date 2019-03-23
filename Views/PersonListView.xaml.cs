using System.Windows.Controls;
using CSharpPractice4.Tools.Navigation;
using CSharpPractice4.ViewModels;

namespace CSharpPractice4.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonListView.xaml
    /// </summary>
    public partial class PersonListView : UserControl,INavigatable
    {
        public PersonListView()
        {
            InitializeComponent();
            DataContext = new PersonListViewModel();
        }

        
    }
}
