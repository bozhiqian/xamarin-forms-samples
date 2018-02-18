using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace InteractivityListView.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool _isRefreshing;
        private string _selectedItem;

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Interactivity ListView";
            var list = new List<string>
            {
                "speaker",
                "pen",
                "lamp",
                "monitor",
                "bag",
                "book",
                "cap",
                "tote",
                "floss",
                "phone"
            };
            Lists = new ObservableCollection<string>(list.OrderBy(p => p));
            
            RefreshCommand = new DelegateCommand(OnRefresh);
            MoreCommand = new DelegateCommand(OnMore, () => SelectedItem != null);
            DeleteCommand = new DelegateCommand(OnDelete, () => SelectedItem != null);
        }

        public ObservableCollection<string> Lists { get; }

        public DelegateCommand RefreshCommand { get; }
        public DelegateCommand MoreCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);

                if (SelectedItem != null)
                {
                    MessagingCenter.Send(this, "Tapped", SelectedItem + " row was tapped");
                    MoreCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private void OnRefresh()
        {
            //put your refreshing logic here
            var itemList = Lists.Reverse().ToList();
            Lists.Clear();
            foreach (var s in itemList) Lists.Add(s);
            //make sure to end the refresh state
            IsRefreshing = false;
        }

        private void OnDelete()
        {
            if (SelectedItem != null) Lists.Remove(SelectedItem);
        }

        private void OnMore()
        {
            if (!string.IsNullOrEmpty(SelectedItem))
                MessagingCenter.Send(this, "More Context Action", SelectedItem + " more context action");
        }
    }
}