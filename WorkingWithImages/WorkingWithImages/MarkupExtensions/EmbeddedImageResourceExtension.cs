using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace WorkingWithImages.MarkupExtensions
{
	// You exclude the 'Extension' suffix when using in Xaml markup
	[Preserve(AllMembers = true)]
	[ContentProperty ("Source")]
	public class ImageResourceExtension : IMarkupExtension
	{
		public string Source { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;

			// Do your translation lookup here, using whatever method you require
			var imageSource = ImageSource.FromResource(Source); 

			return imageSource;
		}
	}
}

/*
 https://developer.xamarin.com/guides/xamarin-forms/user-interface/images/
 Because there is no built-in type converter from string to ResourceImageSource, these types of images cannot be natively loaded by XAML. 
 Instead, a simple custom XAML markup extension can be written to load images using a Resource ID specified in XAML

 */
