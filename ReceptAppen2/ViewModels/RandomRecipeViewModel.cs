namespace ReceptAppen2.ViewModels
{
    internal partial class RandomRecipeViewModel : ObservableObject
    {
        [ObservableProperty]
        RecipeSearch randomRecipes;
        public RandomRecipeViewModel()
        {
            RandomRecipes = new RecipeSearch(); 
            var task = Task.Run(() => RecipeSearchService.GetRandomRecipesAsync());
            task.Wait();
            RandomRecipes = task.Result;

        }
    }
}
