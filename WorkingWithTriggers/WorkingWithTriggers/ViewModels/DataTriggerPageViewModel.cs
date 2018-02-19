using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithTriggers.ViewModels
{
	public class DataTriggerPageViewModel : BindableBase
	{
	    private string _title;

        public DataTriggerPageViewModel()
        {
            Title = "Data";
        }
	    public string Title
	    {
	        get => _title;
	        set => SetProperty(ref _title, value);
	    }
    }
}
