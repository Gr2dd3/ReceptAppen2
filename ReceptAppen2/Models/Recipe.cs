
namespace ReceptAppen2.Models
{
    public class Recipe
    {
        //public List<ExtraPortion> ExtraPortions { get; set; }
        //public GroceryBags GroceryBags { get; set; }
        //public NutritionPerPortion NutritionPerPortion { get; set; }
        //public List<CookingStepsWithTimer> CookingStepsWithTimers { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string YouTubeId { get; set; }
        public List<Ingredientgroup> IngredientGroups { get; set; }
        public string PreambleHTML { get; set; }
        public string PreparationAdvice { get; set; }
        public string DietaryInfo { get; set; }
        public bool IsGoodClimateChoice { get; set; }
        public bool IsKeyHole { get; set; }
        public List<string> CookingSteps { get; set; }
        public string CurrentUsersRating { get; set; }
        public string AverageRating { get; set; }
        public string CookingTime { get; set; }
        public string CookingTimeAbbreviated { get; set; }
        public int Portions { get; set; }
        public string PortionsDescription { get; set; }
        public List<object> Categories { get; set; }
        public List<string> MdsaCategories { get; set; }
        public List<int> MoreLikeThis { get; set; }
        public int OfferCount { get; set; }
        public int CommentCount { get; set; }
        public string Difficulty { get; set; }
        public int CookingTimeMinutes { get; set; }
        public int IngredientCount { get; set; }
        public string NumberOfUserRatings { get; set; }

        public Recipe()
        {
            IngredientGroups = new List<Ingredientgroup>();
        }
    }

   
}
