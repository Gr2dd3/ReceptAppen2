namespace ReceptAppen2.Views;

public partial class UserRecipePage : ContentPage
{
    public UserRecipePage()
    {
        InitializeComponent();
        BindingContext = new UserRecipeViewModel();
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
}