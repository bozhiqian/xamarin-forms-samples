using System.IO;
using System.Threading.Tasks;

namespace DependencyServiceSample.DependencyService
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
