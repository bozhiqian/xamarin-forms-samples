using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TheBusinessTumble.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _selecteItem;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Xamarin.Forms Layout Sample: The Business Tumble";

            Lists = new ObservableCollection<string>(new List<string>() { "StackLayoutPage", "AbsoluteLayoutPage", "RelativeLayoutPage" });
        }

        public ObservableCollection<string> Lists { get; }

        public string SelecteItem
        {
            get => _selecteItem;
            set
            {
                SetProperty(ref _selecteItem, value);
                if (_selecteItem != null)
                {
                    NavigationService.NavigateAsync($"NavigationPage/{_selecteItem}");
                }
            }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            SelecteItem = null;
        }
    }
}
