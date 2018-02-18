using System;
using System.IO;
using System.Threading.Tasks;
using DependencyServiceSample.DependencyService;
using DependencyServiceSample.iOS.DependencyService;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PicturePickerImplementation))]

namespace DependencyServiceSample.iOS.DependencyService
{
    public class PicturePickerImplementation : IPicturePicker
    {
        private UIImagePickerController _imagePicker;
        private TaskCompletionSource<Stream> _taskCompletionSource;

        public Task<Stream> GetImageStreamAsync()
        {
            // Create and define UIImagePickerController
            _imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            // Set event handlers
            _imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            _imagePicker.Canceled += OnImagePickerCancelled;

            // Present UIImagePickerController;
            var window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(_imagePicker, true);

            // Return Task object
            _taskCompletionSource = new TaskCompletionSource<Stream>();
            return _taskCompletionSource.Task;
        }

        private void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            var image = args.EditedImage ?? args.OriginalImage;

            if (image != null)
            {
                // Convert UIImage to .NET Stream object
                var data = image.AsJPEG(1);
                var stream = data.AsStream();

                // Set the Stream as the completion of the Task
                _taskCompletionSource.SetResult(stream);
            }
            else
            {
                _taskCompletionSource.SetResult(null);
            }

            _imagePicker.DismissModalViewController(true);
        }

        private void OnImagePickerCancelled(object sender, EventArgs args)
        {
            _taskCompletionSource.SetResult(null);
            _imagePicker.DismissModalViewController(true);
        }
    }
}