using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.ViewModels
{
    public partial class UserRecipeViewModel : ObservableObject
    {
        static readonly UserSingleton host = UserSingleton.GetUser();

        [ObservableProperty]
        ObservableCollection<Recipe> recipes;

        [ObservableProperty]
        User user;

        private List<RecipeDb> UserIdRecipeIdFromDb { get; set; }
        private List<int> RecipesId { get; set; }

        public UserRecipeViewModel()
        {
            RecipesId = new List<int>();
            Recipes = new ObservableCollection<Recipe>();
            if (host.IsloggedIn)
                User = host.LoggedInUser;
            GetUserRecipes();
        }

        [RelayCommand]
        private async void DeleteRecipe(object r)
        {
            var recipe = (Recipe)r;
            await MongoDBService.GetDbCollection()
                .DeleteOneAsync(x => x.RecipeId == recipe.Id && x.UserId == host.LoggedInUser.Id);
            Recipes.Remove(recipe);
        }

        private async Task GetRecipesIdFromDb()
        {
            UserIdRecipeIdFromDb = new List<RecipeDb>();
            UserIdRecipeIdFromDb = await MongoDBService.GetDbCollection().AsQueryable().ToListAsync();

            foreach (var item in UserIdRecipeIdFromDb)
            {
                if (item.UserId == host.LoggedInUser.Id)
                    RecipesId.Add(item.RecipeId);
            }
        }
        private async void GetUserRecipes()
        {
            await GetRecipesIdFromDb();
            
            if (RecipesId.Count > 0)
            {
                for (int savedRecipeId = 0; savedRecipeId < RecipesId.Count; savedRecipeId++)
                {
                    var usersRecipe = await RecipeSearchService.GetOneRecipeAsync(RecipesId[savedRecipeId]);
                    Recipes.Add(usersRecipe);
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Här var det tomt!", "Du har inga sparade recept ännu", "OK");
            }
        }

    }
}
