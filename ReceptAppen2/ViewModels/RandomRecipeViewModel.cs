using CommunityToolkit.Mvvm.ComponentModel;
using ReceptAppen2.Models;
using ReceptAppen2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
