using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReceptAppen2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.ViewModels
{
    internal partial class RecipeDetailsViewModel : ObservableObject
    {

        //public ObservableCollection<Recipe> Recipes { get; } = new();

        //Recipe Recipe = SessionsData.OneRecipe;


        // Class -> Recipe
        [ObservableProperty]
        string imageUrl;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string cookingTime;

        [ObservableProperty]
        ObservableCollection<Ingredientgroup> ingredientgroups;


        // Class -> Ingredientgroup
        [ObservableProperty]
        int portions;

        [ObservableProperty]
        ObservableCollection<Ingredient> ingredients;



        // Class -> Ingredient
        [ObservableProperty]
        string text;

        [ObservableProperty]
        float quantity;

        [ObservableProperty]
        string unit;

        [ObservableProperty]
        string ingredientName;


        public RecipeDetailsViewModel()
        {

            Ingredientgroups = new ObservableCollection<Ingredientgroup>();
            Ingredients = new ObservableCollection<Ingredient>();

            //GetRecipeDetails();

        }


        //internal void GetRecipeDetails()
        //{

        //        ImageUrl = Recipe.ImageUrl;
        //        Title = Recipe.Title;
        //        CookingTime = Recipe.CookingTime;

        //        foreach (var item in Recipe.IngredientGroups)
        //        {
        //            Portions = item.Portions;

        //            foreach (var ingredient in item.Ingredients)
        //            {
        //                Text = ingredient.Text;
        //                Quantity = ingredient.Quantity;
        //                Unit = ingredient.Unit;
        //                IngredientName = ingredient.IngredientName;
        //            }
        //        }
            
        //}
    }
}

