using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithMaps.ViewModels
{
	public class CustomMapPageViewModel : BindableBase
	{
	    private string _title;

        public CustomMapPageViewModel()
        {
            Title = "Polyline Map Overlay";
        }
        public string Title
	    {
	        get => _title;
	        set => SetProperty(ref _title, value);
	    }
    }
}
