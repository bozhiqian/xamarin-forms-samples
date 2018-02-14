using System;
using Prism.Commands;
using Prism.Navigation;
using Todo.DependencyService;
using Todo.Models;

namespace Todo.ViewModels
{
    public class TodoItemPageViewModel : ViewModelBase
    {
        private TodoItem _todoItem;

        public TodoItemPageViewModel()
        {
            SaveCommand = new DelegateCommand(SaveAsync);
            DeleteCommand = new DelegateCommand(DeleteAsync);
            CancelCommand = new DelegateCommand(CancelAsync);
            SpeakCommand = new DelegateCommand(Speak);
        }

        public TodoItem TodoItem
        {
            get => _todoItem;
            set => SetProperty(ref _todoItem, value);
        }

        public DelegateCommand SaveCommand { get; }

        public DelegateCommand DeleteCommand { get; }

        public DelegateCommand CancelCommand { get; }

        public DelegateCommand SpeakCommand { get; }

        private void Speak()
        {
            Xamarin.Forms.DependencyService.Get<ITextToSpeech>().Speak(TodoItem.Name + " " + TodoItem.Notes);
        }

        private async void CancelAsync()
        {
            await NavigationService.GoBackToRootAsync();
        }

        private async void DeleteAsync()
        {
            await App.Connection.DeleteItemAsync(TodoItem);
            await NavigationService.GoBackToRootAsync();
        }

        private async void SaveAsync()
        {
            await App.Connection.SaveItemAsync(TodoItem);
            await NavigationService.GoBackToRootAsync();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("todoitem"))
            {
                TodoItem = parameters.GetValue<TodoItem>("todoitem");
            }
            base.OnNavigatedTo(parameters);
        }
    }
}