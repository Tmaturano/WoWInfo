// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace WoWInfo.Helpers
{
    /// <summary>
    /// Install-package Xam.Plugins.Settings (para todos os projetos)  
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        const string UserIdKey = "userid";
        private static string UserIdDefault = string.Empty;

        const string AuthTokenKey = "authtoken";
        private static string AuthTokenDefault = string.Empty;
        
        public static string UrlRenderCharacter => "http://render-us.worldofwarcraft.com/character/";

        public static string AuthToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(AuthTokenKey, AuthTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AuthTokenKey, value);
            }
        }

        public static string UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserIdKey, UserIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserIdKey, value);
            }
        }

        //TODO: Verificar como pega o nome do usuário que acabou de logar
        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault("", string.Empty);
            }
            set
            {
                AppSettings.AddOrUpdateValue("", value);
            }
        }

        public static string BlizzardApiKey => "zeq6gebfq2z57zxqbnvfm5s7yz685nw5";        

        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserId);


    }
}