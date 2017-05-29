using WoWInfo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WoWInfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterPage : ContentPage
    {
        public CharacterPage()
        {
            InitializeComponent();
            BindingContext = new CharacterViewModel();
        }
    }
}