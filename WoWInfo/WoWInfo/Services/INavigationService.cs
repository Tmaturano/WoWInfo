using System.Threading.Tasks;

namespace WoWInfo.Services
{
    public interface INavigationService
    {
        void NavigateToLoginView();
        Task NavigateToMainView();
        Task NavigateToCharacterView();
        Task NavigateToItemView();
        Task NavigateToAboutView();
    }
}
