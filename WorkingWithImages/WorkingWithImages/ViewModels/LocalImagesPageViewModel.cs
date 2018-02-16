using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithImages.ViewModels
{
	public class LocalImagesPageViewModel : BindableBase
	{
	    private string _title;

	    public LocalImagesPageViewModel()
	    {
	        Title = "Local";
	    }

	    public string Title
	    {
	        get => _title;
	        set => SetProperty(ref _title, value);
	    }

    }
}
