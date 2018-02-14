using Prism.Mvvm;
using Prism.Navigation;

namespace Todo.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        private string _title;

        public ViewModelBase() : this(null)
        {

        }
        public ViewModelBase(INavigationService navigationService)
        {
            if (NavigationService == null && navigationService != null)
            {
                NavigationService = navigationService;
            }
        }

        protected static INavigationService NavigationService { get; set; }

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
