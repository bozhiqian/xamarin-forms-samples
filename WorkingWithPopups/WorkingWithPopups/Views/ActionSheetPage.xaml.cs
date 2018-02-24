using System.Diagnostics;
using WorkingWithPopups.Events;
using WorkingWithPopups.ViewModels;
using Xamarin.Forms;

namespace WorkingWithPopups.Views
{
    public partial class ActionSheetPage : ContentPage
    {
        public ActionSheetPage()
        {
            InitializeComponent();
            ViewModel.EventAggregator.GetEvent<ActionSheetEvent>().Subscribe(OnActionSheet);
        }

        private async void OnActionSheet(ActionSheetEventArgs args)
        {
            var action = await DisplayActionSheet(args.Title, args.Cancel, args.Destruction, args.Buttons);
            ViewModel.Action = action;

            Debug.WriteLine("Action: " + action);
        }

        public ActionSheetPageViewModel ViewModel => this.BindingContext as ActionSheetPageViewModel;
    }
}
