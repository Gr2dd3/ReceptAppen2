namespace ReceptAppen2.ViewModels
{
    internal partial class SearchRecipeViewModel : ObservableObject
    {
        [ObservableProperty]
        string searchPhrase;

        [ObservableProperty]
        RecipeSearch recipeSearch;

        public SearchRecipeViewModel()
        {
            RecipeSearch = new RecipeSearch();
        }

        [RelayCommand]
        private async void Search()
        {
            try
            {
                RecipeSearch = await RecipeSearchService.GetRecipeSearchAsync(SearchPhrase);
            }
            catch (NullReferenceException ne)
            {
                await Shell.Current.DisplayAlert("Fel", $"Hittade inget recept!" +
                    $"Fel: {Environment.NewLine + ne.Message}", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Fel", $"Något gick fel: {ex.Message}", "OK");
            }
            
            if (RecipeSearch.Recipes.Count == 0)
                await Shell.Current.DisplayAlert("Här var det tomt!", "Du får söka bredare", "OK");
        }

    }
}
