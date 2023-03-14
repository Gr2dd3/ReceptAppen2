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
            var recipe1 = await RecipeSearchService.GetOneRecipeAsync(recipe.Id);
            await Navigation.PushAsync(new RecipeDetailsPage(recipe1));
        }
    ((ListView)sender).SelectedItem = null;
    }

    private async void OnClickedGoToUserPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserMainPage());
        
    }
}