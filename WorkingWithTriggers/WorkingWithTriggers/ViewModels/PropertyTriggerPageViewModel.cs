using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithTriggers.ViewModels
{
	public class PropertyTriggerPageViewModel : BindableBase
	{
	    private string _title;
        public PropertyTriggerPageViewModel()
        {
            Title = "Property";
        }
	    public string Title
	    {
	        get => _title;
	        set => SetProperty(ref _title, value);
	    }
    }
}
