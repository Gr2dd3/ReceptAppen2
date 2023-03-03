namespace ReceptAppen2.Models
{
    public class Ingredientgroup
    {
        public int Portions { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string GroupName { get; set; }

        public Ingredientgroup()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
