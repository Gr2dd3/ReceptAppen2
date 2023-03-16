using ReceptAppen2.Singletons;

namespace ReceptAppen2.Views;

public partial class RecipeDetailsPage : ContentPage
{
    static readonly UserSingleton host = UserSingleton.GetUser();
    public RecipeDetailsPage(Recipe recipe)
    {
        InitializeComponent();

        if (host.LoggedInUser is null || host.FromUserRecipePage)
            SaveBtn.IsVisible = false;

        BindingContext = new DetailsRecipeViewModel(recipe);
    }

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}