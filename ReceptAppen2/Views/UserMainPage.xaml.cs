namespace ReceptAppen2.Views;

public partial class UserMainPage : ContentPage
{
    static readonly UserSingleton host = UserSingleton.GetUser();
    public UserMainPage()
	{
		InitializeComponent();
		BindingContext = new UserMainPageViewModel();
	}

    private async void OnClickedGoToRecipeSearchPage(object sender, EventArgs e)
    {
        host.FromUserRecipePage = false;
		await Navigation.PushAsync(new RecipeSearchPage());
    }

    private async void OnClickedGoToUserRecipePage(object sender, EventArgs e)
    {
        host.FromUserRecipePage = true;
        await Navigation.PushAsync(new UserRecipePage());
    }

    private async void OnClickLogOut(object sender, EventArgs e)
    {
        host.LogOut();
        await Navigation.PushAsync(new StartPage());
    }
}