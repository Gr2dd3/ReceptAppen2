using ReceptAppen2.ViewModels;

namespace ReceptAppen2;

public partial class RandomRecipePageStart : ContentPage
{
	public RandomRecipePageStart()
	{
		InitializeComponent();
		BindingContext = new RandomRecipeViewModel().RandomRecipes;
	}

}

