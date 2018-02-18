using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace UsingMessagingCenter.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool _subscribed;

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Using Messaging Center";

            Button1Command = new DelegateCommand(OnButton1Clicked);
            Button2Command = new DelegateCommand(OnButton2Clicked);
            Button3Command = new DelegateCommand(OnButton3Clicked, () => Subscribed);

            Greetings = new ObservableCollection<string>();
            Subscribed = true;
        }

        public bool Subscribed
        {
            get => _subscribed;
            set
            {
                SetProperty(ref _subscribed, value);
                Button3Command.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<string> Greetings { get; }
        private void OnButton3Clicked()
        {
            MessagingCenter.Unsubscribe<string>(this, "Hi");

            MessagingCenter.Send(this, "Unsubscribed", "This page has stopped listening, so no more alerts; however the ViewModel is still receiving messages.");
        }

        private void OnButton2Clicked()
        {
            MessagingCenter.Send(this, "Hi", "John");
            Greetings.Add("Hi John");
        }

        private void OnButton1Clicked()
        {
            MessagingCenter.Send(this, "Hi", "");
            Greetings.Add("Hi");
        }

        public DelegateCommand Button1Command { get; }
        public DelegateCommand Button2Command { get; }
        public DelegateCommand Button3Command { get; }

    }
}
