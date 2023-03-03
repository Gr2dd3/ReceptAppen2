namespace ReceptAppen2.ViewModels
{
    internal class RecipeSearchViewModel : ObservableObject
    {
        public RecipeSearch RecipeSearch { get; set; }


        public RecipeSearchViewModel()
        {
            if (SessionsData.User is not null)
            {
                //TODO: Skicka med login
                RecipeSearch = new RecipeSearch();
                var task = Task.Run(() => RecipeSearchService.GetRecipeSearchAsync());
                task.Wait();
                RecipeSearch = task.Result;
            }
        }
    }
}
