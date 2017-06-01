using Microsoft.WindowsAzure.MobileServices;
using WoWInfo.Authentication;
using WoWInfo.Droid.Authentication;
using WoWInfo.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Android.Webkit;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace WoWInfo.Droid.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
                                                        MobileServiceAuthenticationProvider provider,
                                                        IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;                

                return user;
            }
            catch (Exception ex)
            {
                //TODO: Log error
                throw;
            }
        }

        public async Task<bool> LogoutAsync(MobileServiceClient client)
        {
            try
            {
                CookieManager.Instance.RemoveAllCookie();
                await client.LogoutAsync();

                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log error
                return false;                
            }
        }
    }
}