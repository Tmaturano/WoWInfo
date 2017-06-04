using System;
using System.Threading.Tasks;
using WoWInfo.Views;
using Xamarin.Forms;
using System.Linq;

namespace WoWInfo.Services
{
    public class NavigationService : INavigationService
    {
        public void NavigateToLoginView()
        {
            App.Current.MainPage = new LoginPage();
        }

        public async Task NavigateToMainView()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new MainPage());            
        }

        public async Task NavigateToCharacterView()
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(new CharacterPage());           
        }

        public async Task NavigateToItemView()
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(new ItemPage());          
        }

        public async Task NavigateToAboutView()
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(new AboutPage());            
        }
    }
}
