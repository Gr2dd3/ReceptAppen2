namespace ReceptAppen2.Views;

public partial class RecipeDetailsPage : ContentPage
{
    public RecipeDetailsPage(Recipe recipe)
	{
        InitializeComponent();
        BindingContext = new DetailsRecipeViewModel(recipe);
	}

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}