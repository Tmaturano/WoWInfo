using WoWInfo.Services;
using Xamarin.Forms;

namespace WoWInfo.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        
        public Command AboutCommand { get; }

        public DetailViewModel()
        {            
            _navigationService = DependencyService.Get<INavigationService>();
            AboutCommand = new Command(ExecuteAboutCommand);
        }

        async void ExecuteAboutCommand()
        {
            await _navigationService.NavigateToAboutView();
        }
    }
}
