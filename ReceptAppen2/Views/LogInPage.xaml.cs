using ReceptAppen2.ApplicationFacade;

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
        if (SessionsData.IsloggedIn)
        {
            await Navigation.PushAsync(new UserMainPage());
        }
    }

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}