namespace ReceptAppen2.ViewModels
{
    internal partial class RecipeSearchViewModel : ObservableObject
    {
        [ObservableProperty]
        string searchPhrase;

        [ObservableProperty]
        List<Recipe> recipes;

        public RecipeSearch RecipeSearch { get; set; }

        [RelayCommand]
        private async void Search()
        {
            RecipeSearch = new RecipeSearch();
            RecipeSearch = await RecipeSearchService.GetRecipeSearchAsync(SearchPhrase);
        }

    }
}
