﻿namespace ReceptAppen2;

public partial class RandomRecipePageStart : ContentPage
{
    public RandomRecipePageStart()
    {
        InitializeComponent();
        BindingContext = new RandomRecipeViewModel().RandomRecipes;
    }

    private async void OnItemSelectedChanged(object sender, SelectedItemChangedEventArgs e)
    {
        var recipe = ((ListView)sender).SelectedItem as Recipe;
        if (recipe != null)
        {
            await Navigation.PushAsync(new RecipeDetailsPage(recipe));
        }
        ((ListView)sender).SelectedItem = null;
    }

    private async void GoToLogInPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LogInPage());
    }
}
