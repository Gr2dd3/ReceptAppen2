namespace ReceptAppen2.Views;

public partial class UserMainPage : ContentPage
{
	public UserMainPage()
	{
		InitializeComponent();
		BindingContext = new UserMainPageViewModel();
	}

    private async void OnClickedGoToRecipeSearchPage(object sender, EventArgs e)
    {
        SessionsData.FromUserRecipePage = false;
		await Navigation.PushAsync(new RecipeSearchPage());
    }

    private async void OnClickedGoToUserRecipePage(object sender, EventArgs e)
    {
        SessionsData.FromUserRecipePage = true;
        await Navigation.PushAsync(new UserRecipePage());
    }
}