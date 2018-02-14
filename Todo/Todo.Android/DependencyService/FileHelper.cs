using System;
using System.IO;
using Xamarin.Forms;
using Todo.DependencyService;
using Todo.Droid.DependencyService;

[assembly: Dependency(typeof(FileHelper))]
namespace Todo.Droid.DependencyService
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}