using Prism.Commands;
using Prism.Navigation;

namespace ResourceDictionaryDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base (navigationService)
        {
            Title = "Resource Dictionaries";

            NavigateToListDataPageCommand = new DelegateCommand(NavigateToListDataPage);
        }

        private async void NavigateToListDataPage()
        {
            await NavigationService.NavigateAsync("NavigationPage/ListDataPage");
        }

        public DelegateCommand NavigateToListDataPageCommand { get; }
    }
}
