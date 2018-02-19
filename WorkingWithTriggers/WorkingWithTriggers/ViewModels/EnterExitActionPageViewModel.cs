using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithTriggers.ViewModels
{
	public class EnterExitActionPageViewModel : BindableBase
	{
	    private string _title;

        public EnterExitActionPageViewModel()
        {
            Title = "Enter Exit";
        }
        public string Title
	    {
	        get => _title;
	        set => SetProperty(ref _title, value);
	    }
    }
}
