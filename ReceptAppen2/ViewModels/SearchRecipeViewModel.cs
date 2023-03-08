namespace ReceptAppen2.ViewModels
{
    internal partial class SearchRecipeViewModel : ObservableObject
    {
        [ObservableProperty]
        string searchPhrase;

        [ObservableProperty]
        List<Recipe> recipes;

        [ObservableProperty]
        RecipeSearch recipeSearch;

        [RelayCommand]
        private async void Search()
        {
            RecipeSearch = new RecipeSearch();
            RecipeSearch = await RecipeSearchService.GetRecipeSearchAsync(SearchPhrase);
        }

    }
}
