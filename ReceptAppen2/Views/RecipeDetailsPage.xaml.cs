namespace ReceptAppen2.Views;

public partial class RecipeDetailsPage : ContentPage
{
    public RecipeDetailsPage(Recipe recipe)
	{
        InitializeComponent();
        BindingContext = new RecipeDetailsViewModel(recipe);
	}

}