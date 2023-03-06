namespace ReceptAppen2.Views;
public partial class LogInPage : ContentPage
{
    public LogInPage()
    {
        InitializeComponent();
       BindingContext = new LogInUserViewModel();
    }

    private async void OnClickedGoToUserPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserMainPage());
    }

}