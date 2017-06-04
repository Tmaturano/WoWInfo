using Microsoft.WindowsAzure.MobileServices;
using WoWInfo.Helpers;
using System.Threading.Tasks;
using WoWInfo.Authentication;
using WoWInfo.Services;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Net.Http;
using WoWInfo.Models;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(AzureService))]
namespace WoWInfo.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "https://wowinfoapp.azurewebsites.net";

        public MobileServiceClient Client { get; set; }

        public AzureService()
        {
            Initialize();
        }

        private void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
            
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
            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;
                
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

            await SetUserInformationAsync();

            return true;
        }

        public async Task<bool> LogoutAsync()
        {
            var auth = DependencyService.Get<IAuthentication>();

            return await auth.LogoutAsync(Client);            
        }

        public async Task SetUserInformationAsync()
        {
            var identities = await Client.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");

            if (identities.Count <= 0)
                return;

            var name = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
            var userToken = identities[0].AccessToken;

            var requestUrl = $"https://graph.facebook.com/v2.9/me/?fields=picture&access_token={userToken}";
            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

            Settings.UserName = name;
            Settings.UserImageUrl = facebookProfile.Picture.Data.Url;            
        }
    }
}
