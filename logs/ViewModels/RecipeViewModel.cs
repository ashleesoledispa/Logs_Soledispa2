using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using logs.Models;
using logs.Services;
using Microsoft.Maui.Storage;

namespace logs.ViewModels
{
    public partial class RecipeViewModel : ObservableObject
    {
        [ObservableProperty] private string nombre;
        [ObservableProperty] private string ingredientes;
        [ObservableProperty] private int tiempoPreparacionMinutos;
        [ObservableProperty] private bool esVegetariana;

        public ICommand SaveCommand { get; }
        private readonly RecipeDatabase db;

        public RecipeViewModel()
        {
            db = App.Database;
            SaveCommand = new AsyncRelayCommand(OnSaveAsync);
        }

        private async Task OnSaveAsync()
        {
            // Validar regla de 180 min
            if (TiempoPreparacionMinutos > 180 && !EsVegetariana)
            {
                await App.Current.MainPage.DisplayAlert(
                  "Error",
                  "No puede superar 180 minutos para recetas no vegetarianas.",
                  "OK");
                return;
            }

            var r = new Recipe
            {
                Nombre = Nombre,
                Ingredientes = Ingredientes,
                TiempoPreparacionMinutos = TiempoPreparacionMinutos,
                EsVegetariana = EsVegetariana
            };

            await db.SaveAsync(r);
            AppendLog(Nombre);

            await App.Current.MainPage.DisplayAlert(
              "OK", "Receta guardada correctamente.", "OK");

            // Limpiar
            Nombre = string.Empty;
            Ingredientes = string.Empty;
            TiempoPreparacionMinutos = 0;
            EsVegetariana = false;
        }

        private void AppendLog(string registro)
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "LOGS_SOLEDISPA.txt");
            var linea = $"Se incluyó el registro [{registro}] el {DateTime.Now:dd/MM/yyyy HH:mm}";
            File.AppendAllText(path, linea + Environment.NewLine);
        }
    }
}
