namespace ReceptAppen2.ViewModels
{
    public partial class DetailsRecipeViewModel : ObservableObject
    {
        [ObservableProperty]
        Recipe recipe1;

        [ObservableProperty]
        List<string> cookingsteps;

        [ObservableProperty]
        string imageUrl;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string cookingTime;

        [ObservableProperty]
        int portions;

        [ObservableProperty]
        ObservableCollection<string> ingredients;

        public DetailsRecipeViewModel(Recipe recipe)
        {
            Ingredients = new ObservableCollection<string>();
            recipe1 = recipe;
            GetRecipeDetails();
            GetCookingsteps();
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

                    foreach (var ingredient in (item.Ingredients))
                    {
                        if (ingredient is not null)
                            Ingredients.Add(ingredient.Text);
                    }
                }
            }
        }

        private void GetCookingsteps()
        {
            Cookingsteps = new List<string>();

            int count = 1;
            Recipe1.CookingSteps?.ForEach(x => Cookingsteps.Add($"{count++}. " + EncodeHtml(x.ToString())));
        }

        private string EncodeHtml(string text)
        {
            string encodedText = text.Replace("&auml;", "ä")
                .Replace("&aring;", "å")
                .Replace("&egrave;", "è")
                .Replace("&deg;", " °")
                .Replace("&eacute;", "é")
                .Replace("&nbsp;", " ")
                .Replace("&ouml;", "ö")
                .Replace("&ecir;", "ê")
                .Replace("&ndash;", "-")
                .Replace("<strong>", "")
                .Replace("</strong>", "");
            return encodedText;
        }


        [RelayCommand]
        private async void SaveRecipe()
        {
            var saveRecipe = new RecipeDb()
            {
                UserId = SessionsData.LoggedInUser.Id,
                RecipeId = Recipe1.Id
            };

            await MongoDBService.GetDbCollection().InsertOneAsync(saveRecipe);
        }
    }
}

