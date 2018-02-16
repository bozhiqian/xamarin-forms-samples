using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithImages.ViewModels
{
	public class EmbeddedImagesPageViewModel : BindableBase
	{
	    private string _title;
        public EmbeddedImagesPageViewModel()
        {
            Title = "Embedded";
        }
        public string Title
	    {
	        get => _title;
	        set => SetProperty(ref _title, value);
	    }
    }
}
