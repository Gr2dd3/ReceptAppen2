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

        private List<RecipeDb> RecipeUserID { get; set; }

        //private List<int> RecipesId { get; set; }
        public UserRecipeViewModel()
        {
            Recipes = new ObservableCollection<Recipe>();
            if (SessionsData.IsloggedIn)
                User = SessionsData.LoggedInUser;
            GetUserRecipes();
        }

        [RelayCommand]
        private async void DeleteRecipe(object r)
        {
            var recipe = (RecipeDb)r;
            await MongoDBService.GetDbCollection()
                .DeleteOneAsync(x => x.RecipeId == recipe.RecipeId && x.UserId == SessionsData.LoggedInUser.Id);
        }


        private async Task<List<int>> GetRecipesIdFromDb()
        {
            RecipeUserID = new List<RecipeDb>();
            RecipeUserID = await MongoDBService.GetDbCollection().AsQueryable().ToListAsync();
            List<int> recipesId = new();

            foreach (var item in RecipeUserID)
            {
                if (item.UserId == SessionsData.LoggedInUser.Id)
                {
                    recipesId.Add(item.RecipeId);
                }
                else
                {
                    //TODO: Meddelande?
                    await Shell.Current.DisplayAlert("Oj då", "Något blev fel", "OK");
                }
            }
            return recipesId;
        }

        private async void GetUserRecipes()
        {
            //TODO: Kolla så att recept hämtas från rätt användare
            var task = Task.Run(() => GetRecipesIdFromDb());
            task.Wait();
            var result = task.Result;
            
            if (result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    Recipes.Add(await RecipeSearchService.GetOneRecipeAsync(result[i]));
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Här var det tomt!", "Du har inga sparade recept ännu", "OK");
            }
        }

    }
}
