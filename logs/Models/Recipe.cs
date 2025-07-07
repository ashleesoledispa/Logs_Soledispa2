using SQLite;

namespace logs.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Ingredientes { get; set; }
        public int TiempoPreparacionMinutos { get; set; }
        public bool EsVegetariana { get; set; }
    }
}
