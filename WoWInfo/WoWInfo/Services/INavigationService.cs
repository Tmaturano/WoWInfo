using System.Threading.Tasks;

namespace WoWInfo.Services
{
    public interface INavigationService
    {
        Task NavigateToLoginView();
        Task NavigateToMainView();
        Task NavigateToCharacterView();
        Task NavigateToItemView();
        void RemovePageFromStack();
    }
}
