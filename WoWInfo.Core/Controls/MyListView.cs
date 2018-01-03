using System.Windows.Input;
using Xamarin.Forms;

namespace WoWInfo.Controls
{
    public class MyListView : ListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create("ItemTappedCommand",
                typeof(ICommand), //retorno da propriedade
                typeof(MyListView), //Tipo da classe, declaração
                null);

        public ICommand ItemTappedCommand
        {
            get
            {
                return (ICommand)GetValue(ItemTappedCommandProperty);
            }
            set
            {
                SetValue(ItemTappedCommandProperty, value);
            }
        }

        public MyListView(ListViewCachingStrategy strategy) : base(strategy)
        {
            Initialize();
        }

        //ListViewCachingStrategy.RecycleElement atualiza o conteudo de cada celula
        //ListViewCachingStrategy.RetainElement mantém
        public MyListView() : this(ListViewCachingStrategy.RecycleElement){ }

        private void Initialize()
        {
            ItemSelected += (sender, e) =>
            {
                if (ItemTappedCommand == null)
                    return;

                //se tem binding, executa se puder.
                if (ItemTappedCommand.CanExecute(e.SelectedItem))
                    ItemTappedCommand.Execute(e.SelectedItem);
            };
        }
    }
}
