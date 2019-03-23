using System;
using CSharpPractice4.Views;

namespace CSharpPractice4.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.List:
                    ViewsDictionary.Add(viewType, new PersonListView());
                    break;
                case ViewType.AddPerson:
                    ViewsDictionary.Add(viewType, new AddPersonView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
