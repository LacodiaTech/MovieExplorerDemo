using Prism.Unity;
using Microsoft.Practices.Unity;
using MovieExplorer.Views;
using Xamarin.Forms;
using MovieExplorer.Core.Interfaces;
using MovieExplorer.Core.Services;

namespace MovieExplorer
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterType<IMovieExplorerAPIService, MovieExplorerAPIService>();
            Container.RegisterTypeForNavigation<MovieDetailsPage>();
        }
    }
}
