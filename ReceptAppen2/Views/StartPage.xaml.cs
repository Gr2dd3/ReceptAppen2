namespace ReceptAppen2;

public partial class StartPage: ContentPage
{
    public StartPage()
    {
        InitializeComponent();
        BindingContext = new StartPageViewModel().RandomRecipes;
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

