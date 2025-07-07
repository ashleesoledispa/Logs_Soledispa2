using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using logs.Models;
using logs.Services;

namespace logs.ViewModels
{
    public partial class ListViewModel : ObservableObject
    {
        public ObservableCollection<Recipe> Recipes { get; } = new();
        public ICommand LoadCommand { get; }
        private readonly RecipeDatabase db;

        public ListViewModel()
        {
            db = App.Database;
            LoadCommand = new AsyncRelayCommand(OnLoadAsync);
        }

        private async Task OnLoadAsync()
        {
            Recipes.Clear();
            var lista = await db.GetAllAsync();
            foreach (var r in lista)
                Recipes.Add(r);
        }
    }
}
