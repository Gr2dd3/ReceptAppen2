using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.ViewModels
{
    public partial class UserRecipeViewModel : ObservableObject
    {

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
            if (SessionsData.IsloggedIn)
                User = SessionsData.LoggedInUser;
            GetUserRecipes();
        }

        [RelayCommand]
        private async void DeleteRecipe(object r)
        {
            var recipe = (Recipe)r;
            await MongoDBService.GetDbCollection()
                .DeleteOneAsync(x => x.RecipeId == recipe.Id && x.UserId == SessionsData.LoggedInUser.Id);
            Recipes.Remove(recipe);
        }


        private async Task GetRecipesIdFromDb()
        {
            UserIdRecipeIdFromDb = new List<RecipeDb>();
            UserIdRecipeIdFromDb = await MongoDBService.GetDbCollection().AsQueryable().ToListAsync();

            foreach (var item in UserIdRecipeIdFromDb)
            {
                if (item.UserId == SessionsData.LoggedInUser.Id)
                {
                    RecipesId.Add(item.RecipeId);
                }
            }
        }

        private async void GetUserRecipes()
        {
            await GetRecipesIdFromDb();
            
            if (RecipesId.Count > 0)
            {
                for (int i = 0; i < RecipesId.Count; i++)
                {
                    var result = await RecipeSearchService.GetOneRecipeAsync(RecipesId[i]);
                    Recipes.Add(result);
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Här var det tomt!", "Du har inga sparade recept ännu", "OK");
            }
        }

    }
}
