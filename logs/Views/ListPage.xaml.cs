using Microsoft.Maui.Controls;
using logs.ViewModels;

namespace logs.Views
{
    public partial class ListPage : ContentPage
    {
        ListViewModel vm;

        public ListPage()
        {
            InitializeComponent();
            vm = BindingContext as ListViewModel;
            Title = "Recetas";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Carga los datos una sola vez al aparecer
            vm.LoadCommand.Execute(null);
        }
    }
}
