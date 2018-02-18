using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using WorkingWithListview.Model;

namespace WorkingWithListview.ViewModels
{
    public class HeaderFooterPageViewModel : BindableBase
    {
        private string _title;
        public HeaderFooterPageViewModel()
        {
            Title = "HeaderFooter";

            var monkeys = new List<Monkey>
            {
                new Monkey {Name = "Xander", Description = "Writer"},
                new Monkey {Name = "Rupert", Description = "Engineer"},
                new Monkey {Name = "Tammy", Description = "Designer"},
                new Monkey {Name = "Blue", Description = "Speaker"}
            };
            Monkeys = new ObservableCollection<Monkey>(monkeys);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ObservableCollection<Monkey> Monkeys { get; }
        public string Intro => "Monkey Header";
        public string Summary => " There were " + Monkeys.Count + " monkeys";
    }
}