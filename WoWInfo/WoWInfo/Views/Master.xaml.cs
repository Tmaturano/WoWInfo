using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWInfo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WoWInfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
            BindingContext = new MasterViewModel();
            
        }
    }
}