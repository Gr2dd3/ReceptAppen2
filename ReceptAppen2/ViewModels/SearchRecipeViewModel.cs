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
            RecipeSearch = await RecipeSearchService.GetRecipeSearchAsync(SearchPhrase);
        }

    }
}
