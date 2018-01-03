using Version.Plugin;
using WoWInfo.ViewModels;

namespace MonkeyHubApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        //Install-Package Xam.Plugin.Version
        public string Version => CrossVersion.Current.Version;
        public string Developer => "Developed by Thiago Maturana de Oliveira";
    }
}
