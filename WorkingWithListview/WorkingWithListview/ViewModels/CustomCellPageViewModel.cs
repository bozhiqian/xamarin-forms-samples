using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace WorkingWithListview.ViewModels
{
	public class CustomCellPageViewModel : BindableBase
	{
	    private string _title;
        private string _selectedItem;

        public CustomCellPageViewModel()
        {
            Title = "CustomCell";
            Lists = new ObservableCollection<string> { "a", "b", "c" };
            CellClickCommand = new DelegateCommand<string>(OnCellClicked);
        }

	    public string Title
	    {
	        get => _title;
	        set => SetProperty(ref _title, value);
	    }

        private void OnCellClicked(string item)
	    {
	        if (!string.IsNullOrEmpty(item))
	        {
	            MessagingCenter.Send(this, "Clicked", SelectedItem + " button was clicked");
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

        public DelegateCommand<string> CellClickCommand { get; }
    }
}
