using Prism.Navigation;

namespace WorkingWithImages.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Working with Images";
        }
    }
}
