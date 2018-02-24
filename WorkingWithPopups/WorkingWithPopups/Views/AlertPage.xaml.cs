using WorkingWithPopups.Events;
using WorkingWithPopups.ViewModels;
using Xamarin.Forms;

namespace WorkingWithPopups.Views
{
    public partial class AlertPage : ContentPage
    {
        public AlertPage()
        {
            InitializeComponent();
            ViewModel.EventAggregator.GetEvent<AlertEvent>().Subscribe(OnAlertEvent);
        }

        public AlertPageViewModel ViewModel => this.BindingContext as AlertPageViewModel;

        private async void OnAlertEvent(AlertEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Accept))
            {
                await DisplayAlert(args.Title, args.Message, args.Cancel);
            }
            else
            {
                await DisplayAlert(args.Title, args.Message, args.Accept, args.Cancel);
            }
        }
    }
}
