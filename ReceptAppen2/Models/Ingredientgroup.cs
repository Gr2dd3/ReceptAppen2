using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
