using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace WorkingWithListview.ViewModels
{
    public class ContextActionsPageViewModel : BindableBase
    {
        private string _title;
        private string _selectedItem;
        public ContextActionsPageViewModel()
        {
            Title = "ContextActions";

            Lists = new ObservableCollection<string> { "alpha", "beta", "gamma", "delta", "epsilon" };

            OnMoreCommand = new DelegateCommand<string>(OnMore);
            OnDeleteCommand = new DelegateCommand(OnDelete);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private void OnDelete()
        {
            if (SelectedItem != null)
            {
                Lists.Remove(SelectedItem);
            }
        }

        private void OnMore(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                MessagingCenter.Send(this, "More Context Action", SelectedItem + " more context action");
            }
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

        public DelegateCommand<string> OnMoreCommand { get; }

        public DelegateCommand OnDeleteCommand { get; }
    }
}
