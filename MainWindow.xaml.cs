using System.Windows;
using System.Windows.Controls;
using CSharpPractice4.Tools;
using CSharpPractice4.Tools.Managers;
using CSharpPractice4.Tools.Navigation;
using CSharpPractice4.ViewModels;

namespace CSharpPractice4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            StationManager.Initialize(new DataStorage());
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.List);
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
