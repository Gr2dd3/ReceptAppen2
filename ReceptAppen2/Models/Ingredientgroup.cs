using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Models
{
    internal class Ingredientgroup
    {
        public int Portions { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public string GroupName { get; set; }
    }
}
