using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Todo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Todo.Data;
using Todo.DependencyService;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
    public partial class App : PrismApplication
    {
        private static TodoItemDatabase _connection;

        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/TodoListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            //containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<TodoListPage>();
            containerRegistry.RegisterForNavigation<TodoItemPage>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
        }

        public static TodoItemDatabase Connection => _connection ?? (_connection = new TodoItemDatabase(
                                                         Xamarin.Forms.DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3")));

        public int ResumeAtTodoId { get; set; }
    }
}
