using System.Collections.ObjectModel;
using WoWInfo.Helpers;
using WoWInfo.Services;
using Xamarin.Forms;
using WoWInfo.Models;
using System.Threading.Tasks;

namespace WoWInfo.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public string UserName => $"Bem vindo {Settings.UserId}!";
        

        public ObservableCollection<ItemMenu> MenuList { get; }
        
        public Command <ItemMenu> OpenPageCommand { get; }

        public MasterViewModel()
        {            
            _navigationService = DependencyService.Get<INavigationService>();
            OpenPageCommand = new Command<ItemMenu>(ExecuteOpenPageCommand);

            MenuList = new ObservableCollection<ItemMenu>();
            LoadMenuList();
        }

        private void LoadMenuList()
        {
            MenuList.Add(new ItemMenu
            {
                Title = "Personagem",
                Icon = "worgen.png",
                ViewType = ViewType.Character

            });

            MenuList.Add(new ItemMenu
            {
                Title = "Item",
                Icon = "sword.png",
                ViewType = ViewType.Item
            });
        }

        public async void ExecuteOpenPageCommand(ItemMenu item)
        {
            switch (item.ViewType)
            {
                case ViewType.Character:
                     await OpenCharacterPage();
                    break;
                case ViewType.Item:
                     await OpenItemPage();
                    break;        
            }   
        }

        private async Task OpenCharacterPage()
        {
             await _navigationService.NavigateToCharacterView();
        }

        private async Task OpenItemPage()
        {
             await _navigationService.NavigateToItemView();
        }
    }
}
