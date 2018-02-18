using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace WorkingWithListview.ViewModels
{
    public class UnevenRowsPageViewModel : BindableBase
    {
        private string _title;
        private string _selectedItem;

        public UnevenRowsPageViewModel()
        {
            Title = "UnevenRows";

            Lists = new ObservableCollection<string>(new[]
            {
                "To be, or not to be,",
                "that is the question— Whether 'tis Nobler in the mind to suffer",
                @"The Slings and Arrows of outrageous Fortune, Or to take Arms against a Sea of troubles,",
                @"And by opposing end them? To die, to sleep—No more; and by a sleep, to say we end The Heart-ache, and the thousand Natural shocks",
                @"That Flesh is heir to? 'Tis a consummation Devoutly to be wished. To die, to sleep, To sleep, perchance to Dream; Aye, there's the rub, For in that sleep of death, what dreams may come,",
                @"When we have shuffled off this mortal coil, Must give us pause. "
            });
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ObservableCollection<string> Lists { get; }

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);

                if (SelectedItem != null)
                {
                    MessagingCenter.Send(this, "Tapped", SelectedItem + " row was tapped");
                    _selectedItem = null;
                }
            }
        }
    }
}
