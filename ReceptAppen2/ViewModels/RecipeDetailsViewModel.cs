
namespace ReceptAppen2.ViewModels
{
    public partial class RecipeDetailsViewModel : ObservableObject
    {
        //public ObservableCollection<Recipe> Recipes { get; } = new();
        [ObservableProperty]
        Recipe recipe1;


        // Class -> Recipe
        [ObservableProperty]
        string imageUrl;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string cookingTime;

        [ObservableProperty]
        ObservableCollection<string> ingredientgroups;


        // Class -> Ingredientgroup
        [ObservableProperty]
        int portions;

        [ObservableProperty]
        ObservableCollection<string> ingredients;

        // Class -> Ingredient
        [ObservableProperty]
        string text;

        [ObservableProperty]
        float quantity;

        [ObservableProperty]
        string unit;

        [ObservableProperty]
        string ingredientName;

        public RecipeDetailsViewModel(Recipe recipe)
        {
            Ingredientgroups = new ObservableCollection<string>();
            Ingredients = new ObservableCollection<string>();
            recipe1 = recipe;
            GetRecipeDetails();
        }

        [RelayCommand]
        internal void GetRecipeDetails()
        {
            if (Recipe1 is not null)
            {
                if (Recipe1.ImageUrl is not null)
                    ImageUrl = Recipe1.ImageUrl;

                if (Recipe1.Title is not null)
                    Title = Recipe1.Title;

                if (Recipe1.CookingTime is not null)
                    CookingTime = Recipe1.CookingTime;

                foreach (var item in Recipe1.IngredientGroups)
                {
                    if (item is not null)
                        Portions = item.Portions;
                    if (item.GroupName is not null)
                        Ingredientgroups.Add(item.GroupName);

                    foreach (var ingredient in (item.Ingredients))
                    {
                        if (ingredient is not null)
                            Ingredients.Add(ingredient.Text);

                    }
                }
            }
        }




    }
}

