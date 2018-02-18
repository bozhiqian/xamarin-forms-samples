using Prism.Mvvm;
using Prism.Navigation;

namespace InteractivityListView.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        private string _title;

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        protected INavigationService NavigationService { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public virtual void Destroy()
        {
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}