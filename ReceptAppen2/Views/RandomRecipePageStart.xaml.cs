namespace ReceptAppen2;

public partial class RandomRecipePageStart : ContentPage
{
    public RandomRecipePageStart()
    {
        InitializeComponent();
        BindingContext = new RandomRecipeViewModel().RandomRecipes;
    }

    public async void OnItemSelectedChanged(object sender, SelectedItemChangedEventArgs e)
    {
        var recipe = ((ListView)sender).SelectedItem as Recipe;
        if (recipe != null)
        {
            await Navigation.PushAsync(new RecipeDetailsPage(recipe));
        }
        ((ListView)sender).SelectedItem = null;
    }
}

