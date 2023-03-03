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
    public partial class RecipeDetailsViewModel : ObservableObject
    {

        //public ObservableCollection<Recipe> Recipes { get; } = new();

        [ObservableProperty]
        Recipe recipe1;


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



        [ObservableProperty]
        RecipeSearch recipeSearch;

        [ObservableProperty]
        Recipe recipe;

        [ObservableProperty]
        Ingredientgroup ingredientgroup;

        [ObservableProperty]
        Ingredient ingredient;


        public RecipeDetailsViewModel(Recipe recipe)
        {

            //Ingredientgroups = new ObservableCollection<Ingredientgroup>();
            //Ingredients = new ObservableCollection<Ingredient>();

            //GetRecipeDetails();
            recipe1 = recipe;
            GetRecipeDetails();
        }

        [RelayCommand]
        internal void GetRecipeDetails()
        {
            if (Recipe1 != null)
            {
                ImageUrl = Recipe1.ImageUrl;
                Title = Recipe1.Title;
                CookingTime = Recipe1.CookingTime;

                foreach (var item in Recipe1.IngredientGroups)
                {
                    Portions = item.Portions;

                    foreach (var ingredient in item.Ingredients)
                    {
                        Text = ingredient.Text;
                        Quantity = ingredient.Quantity;
                        Unit = ingredient.Unit;
                        IngredientName = ingredient.IngredientName;
                    }
                }
            }
        }




    }
}

