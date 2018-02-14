using Prism;
using Prism.Ioc;
using Todo.DependencyService;
using Todo.UWP.DependencyService;

namespace Todo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new Todo.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterSingleton<IFileHelper, FileHelper>();
            container.RegisterSingleton<ITextToSpeech, TextToSpeechUwp>();
        }
    }
}
