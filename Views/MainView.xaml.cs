using System.Windows.Controls;
using CSharpPractice4.Tools.Navigation;

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
        }
    }
}
