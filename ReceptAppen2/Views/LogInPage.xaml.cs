namespace ReceptAppen2.Views;
public partial class LogInPage : ContentPage
{
    static readonly UserSingleton host = UserSingleton.GetUser();
    public LogInPage()
    {
        InitializeComponent();
    }

    private async void OnClickedGoToUserPage(object sender, EventArgs e)
    {
        await host.LogIn(SocSecNumber.Text, Password.Text);
        
        if (host.IsloggedIn)
        {
            await Navigation.PushAsync(new UserMainPage());
        }
    }
    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}