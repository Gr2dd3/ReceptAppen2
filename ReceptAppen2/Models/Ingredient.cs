using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReceptAppen2.Models
{
    public class Ingredient
    {
        public string Text { get; set; }
        public int IngredientId { get; set; }
        public float Quantity { get; set; }
        public float MinQuantity { get; set; }
        public string QuantityFraction { get; set; }
        public string Unit { get; set; }

        [JsonPropertyName("Ingredient")]
        public string IngredientName { get; set; }
    }
}
