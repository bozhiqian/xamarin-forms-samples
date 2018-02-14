using System.IO;
using Windows.Storage;
using Todo.DependencyService;
using Todo.UWP.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Todo.UWP.DependencyService
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}