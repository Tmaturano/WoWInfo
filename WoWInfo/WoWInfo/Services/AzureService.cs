using Microsoft.WindowsAzure.MobileServices;
using WoWInfo.Helpers;
using System.Threading.Tasks;
using WoWInfo.Authentication;
using WoWInfo.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AzureService))]
namespace WoWInfo.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "https://wowinfoapp.azurewebsites.net";

        public MobileServiceClient Client { get; set; }

        private void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            //Se o usuário já está logado no facebook, já preenche as informações do token no Client
            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                //se tem erro, avisa na tela
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar o seu login, tente novamente", "OK");
                });

                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
            }

            return true;
        }
    }
}
