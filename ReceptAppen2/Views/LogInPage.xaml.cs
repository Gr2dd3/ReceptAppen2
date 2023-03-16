using ReceptAppen2.ApplicationFacade;

namespace ReceptAppen2.Views;
public partial class LogInPage : ContentPage
{
    LogInUserViewModel vm = new();
    static readonly UserSingleton host = UserSingleton.GetUser();
    public LogInPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnClickedGoToUserPage(object sender, EventArgs e)
    {
        await vm.LogIn();
        
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