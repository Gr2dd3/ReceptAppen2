namespace ReceptAppen2.Views;

public partial class RecipeSearchPage : ContentPage
{
	public RecipeSearchPage()
	{
		InitializeComponent();
		BindingContext = new RecipeSearchViewModel().RecipeSearch;
	}
}