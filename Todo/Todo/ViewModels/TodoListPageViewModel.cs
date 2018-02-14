using Prism.Commands;
using System.Collections.ObjectModel;
using Prism.Navigation;
using Todo.Models;

namespace Todo.ViewModels
{
    public class TodoListPageViewModel : ViewModelBase
    {
        private TodoItem _selectedTodoItem;

        public TodoListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Todo list application";
            AddItemCommand = new DelegateCommand(AddItemAsync);
            TodoItems = new ObservableCollection<TodoItem>();
        }

        public ObservableCollection<TodoItem> TodoItems { get; }

        public TodoItem SelectedTodoItem
        {
            get => _selectedTodoItem;
            set
            {
                SetProperty(ref _selectedTodoItem, value);

                if (_selectedTodoItem != null)
                {
                    var parameter = new NavigationParameters { { "todoitem", _selectedTodoItem } };
                    NavigationService.NavigateAsync("TodoItemPage", parameter);
                }
            }
        }

        public DelegateCommand AddItemCommand { get; }

        public async void AddItemAsync()
        {
            var parameter = new NavigationParameters { { "todoitem", new TodoItem() } };
            await NavigationService.NavigateAsync("TodoItemPage", parameter);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            // Reset the 'resume' id, since we just want to re-start here
            ((App)Xamarin.Forms.Application.Current).ResumeAtTodoId = -1;
            var todoItems = await App.Connection.GetItemsAsync();

            TodoItems.Clear();
            foreach (var todoItem in todoItems)
            {
                TodoItems.Add(todoItem);
            }
        }
    }
}
