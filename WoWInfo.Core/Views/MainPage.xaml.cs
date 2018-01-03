using Xamarin.Forms;

namespace WoWInfo.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            Master = new Master();

            //O detalhe tem que ser navegável. 
            Detail = new NavigationPage(new Detail());

            //Para informar que ela mesma é a master detail
            App.MasterDetail = this;
        }
    }
}
