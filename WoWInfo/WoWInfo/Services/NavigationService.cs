using System;
using System.Threading.Tasks;
using WoWInfo.Views;
using Xamarin.Forms;

namespace WoWInfo.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToLoginView()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
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

        public void RemovePageFromStack()
        {
            var existingPages = App.Current.MainPage.Navigation.NavigationStack;
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(NavigationPage))
                    App.Current.MainPage.Navigation.RemovePage(page);
            }
        }
    }
}
