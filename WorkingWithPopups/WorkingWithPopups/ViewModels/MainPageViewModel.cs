using Prism.Navigation;
using Prism.Events;

namespace WorkingWithPopups.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) 
            : base (navigationService, eventAggregator)
        {
            Title = "Displaying Pop-ups";
        }

    }
}
