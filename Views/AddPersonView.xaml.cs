
using System.Windows.Controls;
using CSharpPractice4.Tools.Navigation;
using CSharpPractice4.ViewModels;

namespace CSharpPractice4.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPersonView.xaml
    /// </summary>
    public partial class AddPersonView : UserControl, INavigatable
    {
        public AddPersonView()
        {
            InitializeComponent();
            DataContext = new AddPersonViewModel();
        }
    }
}
