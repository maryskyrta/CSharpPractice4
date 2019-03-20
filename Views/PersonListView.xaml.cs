using System.Windows.Controls;
using CSharpPractice4.ViewModels;

namespace CSharpPractice4.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonListView.xaml
    /// </summary>
    public partial class PersonListView : UserControl
    {
        public PersonListView()
        {
            InitializeComponent();
            DataContext = new PersonListViewModel();
        }
    }
}
