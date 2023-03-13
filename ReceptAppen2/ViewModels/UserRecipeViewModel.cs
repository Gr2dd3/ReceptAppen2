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
        public List<RecipeDb> RecipeUserID { get; set; }


        public UserRecipeViewModel()
        {
            Recipes = new ObservableCollection<Recipe>();
            User = SessionsData.LoggedInUser;
        }

        [RelayCommand]
        private async void DeleteRecipe(object r)
        {
            var recipe = (RecipeDb)r;
            await MongoDBService.GetDbCollection()
                .DeleteOneAsync(x => x.RecipeId == recipe.RecipeId && x.UserId == SessionsData.LoggedInUser.Id);
        }


        private async Task GetRecipes()
        {
            RecipeUserID = await MongoDBService.GetDbCollection().AsQueryable().ToListAsync();
            List<int> RecipesId = new();

            foreach (var item in RecipeUserID)
            {
                if (item.UserId == SessionsData.LoggedInUser.Id)
                {
                    RecipesId.Add(item.RecipeId);
                }
                else
                {
                    //TODO: Meddelande?
                    await Shell.Current.DisplayAlert("Oj då", "Något blev fel", "OK");
                }
            }
            for (int i = 0; i < RecipesId.Count; i++)
            {
                Recipes.Add(await RecipeSearchService.GetOneRecipeAsync(RecipesId[i]));
            }
        }


    }
}
