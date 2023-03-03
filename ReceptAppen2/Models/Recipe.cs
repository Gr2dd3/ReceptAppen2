using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string PreambleHTML { get; set; }
        public string Difficulty { get; set; }
        public string CookingTime { get; set; }
        public string CookingTimeAbbreviated { get; set; }
        public int CookingTimeMinutes { get; set; }
        public int CommentCount { get; set; }
        public string AverageRating { get; set; }
        public int IngredientCount { get; set; }
        public int OfferCount { get; set; }
        public bool IsGoodClimateChoice { get; set; }
        public bool IsKeyHole { get; set; }
        public string NumberOfUserRatings { get; set; }
        public List<Ingredientgroup> IngredientGroups { get; set; }

        public Recipe()
        {
            IngredientGroups = new List<Ingredientgroup>();
        }
    }

   
}
