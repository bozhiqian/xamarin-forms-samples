using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using WorkingWithListview.Model;

namespace WorkingWithListview.ViewModels
{
    public class BasicListPageViewModel : BindableBase
    {
        private string _title;

        public BasicListPageViewModel()
        {
            Title = "Basic list";
            Lists = new ObservableCollection<ListItem>(new List<ListItem>
            {
                new ListItem {Name = "a"},
                new ListItem {Name = "b"},
                new ListItem {Name = "c"}
            });
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ObservableCollection<ListItem> Lists { get; }
    }
}