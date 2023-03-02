using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Models
{
    internal class RecipeSearch
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
