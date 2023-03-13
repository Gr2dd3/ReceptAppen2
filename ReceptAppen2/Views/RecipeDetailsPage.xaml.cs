namespace ReceptAppen2.Views;

public partial class RecipeDetailsPage : ContentPage
{
    public RecipeDetailsPage(Recipe recipe)
    {
        InitializeComponent();

        if (SessionsData.LoggedInUser is null || SessionsData.FromUserRecipePage)
        {
            SaveBtn.IsVisible = false;
        }
        BindingContext = new DetailsRecipeViewModel(recipe);
    }

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}