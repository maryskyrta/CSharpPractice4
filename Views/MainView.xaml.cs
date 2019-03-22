using System.Windows.Controls;
using CSharpPractice4.Tools.Navigation;
using CSharpPractice4.ViewModels;

namespace CSharpPractice4.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, INavigatable
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
