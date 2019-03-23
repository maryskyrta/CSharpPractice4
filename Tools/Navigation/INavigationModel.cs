
namespace CSharpPractice4.Tools.Navigation
{
    internal enum ViewType
    {
        List,
        AddPerson,
    }

    internal interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
