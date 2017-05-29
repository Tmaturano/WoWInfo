using WoWInfo.Helpers;
using System.Threading.Tasks;
using WoWInfo.Services;
using Xamarin.Forms;

namespace WoWInfo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly AzureService _azureService;
        public ImageSource FacebookLogo
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return ImageSource.FromFile("Resources/face.jpg");
                    case Device.Android:
                        return ImageSource.FromFile("Resources/drawable/facebook.png");
                    default:
                        return ImageSource.FromFile("Assets/face.jpg");
                }
            }
        }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            IsBusy = false;
            Title = "Login";

            _azureService = DependencyService.Get<AzureService>();
            _navigationService = DependencyService.Get<INavigationService>();
            LoginCommand = new Command(ExecuteLoginCommandAsync);

        }

        private async void ExecuteLoginCommandAsync()
        {
            if (IsBusy || !(await LoginAsync()))
                return;
            else
            {
                await _navigationService.NavigateToMainView();

                _navigationService.RemovePageFromStack();
            }         
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return _azureService.LoginAsync();
        }
    }
}
