namespace ReceptAppen2.Views;

public partial class RecipeSearchPage : ContentPage
{
	public RecipeSearchPage()
	{
		InitializeComponent();
		BindingContext = new SearchRecipeViewModel();
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