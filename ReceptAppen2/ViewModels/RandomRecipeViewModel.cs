using ReceptAppen2.Models;
using ReceptAppen2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.ViewModels
{
    internal class RandomRecipeViewModel
    {
        public RecipeSearch RandomRecipes{ get; set; }

        public RandomRecipeViewModel()
        {
            RandomRecipes = new RecipeSearch(); 
            var task = Task.Run(() => RecipeSearchService.GetRandomRecipesAsync());
            task.Wait();
            RandomRecipes = task.Result;
        }
    }
}
