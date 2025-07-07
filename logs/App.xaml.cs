using Microsoft.Maui.Controls;
using logs.Services;

namespace logs
{
    public partial class App : Application
    {
        // Servicio SQLite accesible desde cualquier parte de la app
        public static RecipeDatabase Database { get; private set; }

        public App()
        {
            Database = new RecipeDatabase();
            InitializeComponent();
            MainPage = new AppShell();
        }

    }
}
