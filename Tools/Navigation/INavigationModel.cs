
namespace CSharpPractice4.Tools.Navigation
{
    internal enum ViewType
    {
        Main,
        AddPerson,
    }

    internal interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
