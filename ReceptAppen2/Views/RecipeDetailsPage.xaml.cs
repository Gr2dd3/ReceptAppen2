namespace ReceptAppen2.Views;

public partial class RecipeDetailsPage : ContentPage
{
    public RecipeDetailsPage(Recipe recipe)
    {
        InitializeComponent();
        BindingContext = new DetailsRecipeViewModel(recipe);

        if (SessionsData.LoggedInUser is null)
            SaveBtn.IsVisible = false;

    }

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}