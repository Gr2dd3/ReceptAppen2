using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using ReceptAppen2.Models;
using ReceptAppen2.Services;

namespace ReceptAppen2.ViewModels
{
    internal class RecipeSearchViewModel : ObservableObject
    {
        public RecipeSearch RecipeSearch { get; set; }


        public RecipeSearchViewModel()
        {
            RecipeSearch = new RecipeSearch();
            var task = Task.Run(() => RecipeSearchService.GetRecipeSearchAsync());
            task.Wait();
            RecipeSearch = task.Result;
        }
    }
}
