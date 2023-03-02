using CommunityToolkit.Mvvm.Input;
using ReceptAppen2.Models;
using ReceptAppen2.ViewModels;
using ReceptAppen2.Views;
using System.Runtime.InteropServices.ObjectiveC;

namespace ReceptAppen2;

public partial class RandomRecipePageStart : ContentPage
{
	public RandomRecipePageStart()
	{
		InitializeComponent();
		BindingContext = new RandomRecipeViewModel().RandomRecipes;
	}


    private async void OnListViewitemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var recipe = ((ListView)sender).SelectedItem as Recipe;
		if (recipe != null)
		{
			SessionsData.OneRecipe = recipe;
			var page = new RecipeDetailsPage();
			page.BindingContext = recipe;
			await Navigation.PushAsync(page);


		}
	}

}

