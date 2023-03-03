
namespace ReceptAppen2.Models
{
    public class RecipeSearch
    {
        public int NumberOfPages { get; set; }
        public List<Recipe> Recipes { get; set; }
        public int TotalNumberOfRecipes { get; set; }
        public string Msg { get; set; }

        public RecipeSearch()
        {
            Recipes = new List<Recipe>();
        }
    }
}
