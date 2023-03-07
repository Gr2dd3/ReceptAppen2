namespace ReceptAppen2.ViewModels
{
    internal partial class RecipeSearchViewModel : ObservableObject
    {
        [ObservableProperty]
        string searchPhrase;
        public RecipeSearch RecipeSearch { get; set; }
        public RecipeSearchViewModel()
        {
            if (SessionsData.LoggedInUser is not null)
            {
                //TODO:
                if (SessionsData.IsloggedIn)
                {
                    RecipeSearch = new RecipeSearch();
                    var task = Task.Run(() => RecipeSearchService.GetRecipeSearchAsync(SearchPhrase));
                    task.Wait();
                    RecipeSearch = task.Result;
                }
            }
        }
    }
}
