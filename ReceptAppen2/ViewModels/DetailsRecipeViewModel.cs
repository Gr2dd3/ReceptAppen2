namespace ReceptAppen2.ViewModels
{
    public partial class DetailsRecipeViewModel : ObservableObject
    {
        static readonly UserSingleton host = UserSingleton.GetUser();

        [ObservableProperty]
        Recipe fetchedRecipe;

        [ObservableProperty]
        List<string> cookingsteps;

        [ObservableProperty]
        string imageUrl;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string cookingTime;

        [ObservableProperty]
        ObservableCollection<string> ingredients;

        public DetailsRecipeViewModel(Recipe recipe)
        {
            Ingredients = new ObservableCollection<string>();
            FetchedRecipe = recipe;
            GetRecipeDetails();
            GetCookingsteps();
        }

        [RelayCommand]
        private async void SaveRecipe()
        {
            try
            {
                var saveRecipe = new RecipeDb()
                {
                    Id = new Guid(),
                    UserId = host.LoggedInUser.Id,
                    RecipeId = FetchedRecipe.Id
                };

                await MongoDBService.GetDbCollection().InsertOneAsync(saveRecipe);

                await Shell.Current.DisplayAlert("Klart!", "Recept tillagt", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Oops", $" Något blev fel: {ex.Message}", "OK");
            }
        }

        private void GetRecipeDetails()
        {
            if (FetchedRecipe is not null)
            {
                if (FetchedRecipe.ImageUrl is not null)
                    ImageUrl = FetchedRecipe.ImageUrl;

                if (FetchedRecipe.Title is not null)
                    Title = FetchedRecipe.Title;

                if (FetchedRecipe.CookingTime is not null)
                    CookingTime = FetchedRecipe.CookingTime;

                foreach (var item in FetchedRecipe.IngredientGroups)
                {
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

            int numberOfSteps = 1;
            FetchedRecipe.CookingSteps?.ForEach(x => Cookingsteps.Add($"{numberOfSteps++}. " + DecodeHtml(x.ToString())));
        }
        private string DecodeHtml(string textToDecode)
        {
            string decodedHtmlText = textToDecode.Replace("&auml;", "ä")
                .Replace("&aring;", "å")
                .Replace("&egrave;", "è")
                .Replace("&deg;", " °")
                .Replace("&eacute;", "é")
                .Replace("&nbsp;", " ")
                .Replace("&ouml;", "ö")
                .Replace("&ecirc;", "ê")
                .Replace("&ndash;", "-")
                .Replace("<strong>", "")
                .Replace("</strong>", "");
            return decodedHtmlText;
        }
    }
}

