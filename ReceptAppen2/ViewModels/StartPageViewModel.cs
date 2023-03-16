namespace ReceptAppen2.ViewModels
{
    internal partial class StartPageViewModel : ObservableObject
    {
        [ObservableProperty]
        RecipeSearch randomRecipes;
        public StartPageViewModel()
        {
            try
            {
                RandomRecipes = new RecipeSearch();
                var task = Task.Run(() => RecipeSearchService.GetRandomRecipesAsync());
                task.Wait();
                RandomRecipes = task.Result;
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Fel", $"Meddelande: {ex.Message}", "OK");
            }

        }
    }
}
