using SQLite;
using Microsoft.Maui.Storage;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using logs.Models;

namespace logs.Services
{
    public class RecipeDatabase
    {
        readonly SQLiteAsyncConnection db;

        public RecipeDatabase()
        {
            var ruta = Path.Combine(FileSystem.AppDataDirectory, "Recetas.db3");
            db = new SQLiteAsyncConnection(ruta);
            db.CreateTableAsync<Recipe>().Wait();
        }

        public Task<List<Recipe>> GetAllAsync()
          => db.Table<Recipe>().ToListAsync();

        public Task<int> SaveAsync(Recipe r)
          => db.InsertAsync(r);
    }
}
