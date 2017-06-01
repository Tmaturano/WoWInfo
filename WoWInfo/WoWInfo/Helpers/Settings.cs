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

        public static string UrlRenderCharacter => "http://render-us.worldofwarcraft.com/character/";

        public static string BlizzardApiKey => "zeq6gebfq2z57zxqbnvfm5s7yz685nw5";
        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserId);


        const string AuthTokenKey = "authtoken";
        private static string AuthTokenDefault = string.Empty;                        

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

        const string UserIdKey = "userid";
        private static string UserIdDefault = string.Empty;

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

        const string UserNameKey = "username";
        private static string UserNameDefault = string.Empty;

        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserNameKey, UserNameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserNameKey, value);
            }
        }

        const string UserImageUrlKey = "userimg";
        private static string UserImageUrlDefault = string.Empty;

        public static string UserImageUrl
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserImageUrlKey, UserImageUrlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserImageUrlKey, value);
            }
        }
    }
}