using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using ResourceDictionaryDemo.Model;

namespace ResourceDictionaryDemo.ViewModels
{
    public class ListDataPageViewModel : BindableBase
    {
        private string _title;

        public ListDataPageViewModel()
        {
            Title = "List data";
            var people = new List<Person>
            {
                new Person("Steve", 21, "USA"),
                new Person("John", 37, "USA"),
                new Person("Tom", 42, "UK"),
                new Person("Lucas", 29, "Germany"),
                new Person("Tariq", 39, "UK"),
                new Person("Jane", 30, "USA")
            };

            Lists = new ObservableCollection<Person>(people);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ObservableCollection<Person> Lists { get; }
    }
}