using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithTriggers.ViewModels
{
	public class EventTriggerPageViewModel : BindableBase
	{
	    private string _title;
        public EventTriggerPageViewModel()
        {
            Title = "Event";
        }
        public string Title
	    {
	        get => _title;
	        set => SetProperty(ref _title, value);
	    }
    }
}
