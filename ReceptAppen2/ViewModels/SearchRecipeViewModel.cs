namespace ReceptAppen2.ViewModels
{
    internal partial class SearchRecipeViewModel : ObservableObject
    {
        [ObservableProperty]
        string searchPhrase;

        [ObservableProperty]
        ObservableCollection<Recipe> recipes;

        [ObservableProperty]
        RecipeSearch recipeSearch;

        [RelayCommand]
        private async void Search()
        {
            Recipes = new ObservableCollection<Recipe>();
            RecipeSearch = new RecipeSearch();
            RecipeSearch = await RecipeSearchService.GetRecipeSearchAsync(SearchPhrase);
            RecipeSearch.Recipes.ForEach(x => Recipes.Add(x));
        }

    }
}
