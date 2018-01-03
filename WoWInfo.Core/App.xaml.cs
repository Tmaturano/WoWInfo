using System.Threading.Tasks;
using WoWInfo.Helpers;
using WoWInfo.Services;
using WoWInfo.Views;
using Xamarin.Forms;

namespace WoWInfo
{
    public partial class App : Application
    {
        /// <summary>
        /// Para ser possível navegar em alguns cenários.
        /// </summary>
        public static MasterDetailPage MasterDetail { get; set; }

        private void RegisterDependencies()
        {
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<IBattleNetApi, BattleNetApi>();
        }

        public App()
        {
            InitializeComponent();
            RegisterDependencies();

            if (Settings.IsLoggedIn)
                MainPage = new MainPage();
            else
                MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
