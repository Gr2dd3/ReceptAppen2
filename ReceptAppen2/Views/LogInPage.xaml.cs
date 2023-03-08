using ReceptAppen2.ApplicationFacade;

namespace ReceptAppen2.Views;
public partial class LogInPage : ContentPage
{
    LogInUserViewModel vm = new();
    public LogInPage()
    {
        BindingContext = vm;
        InitializeComponent();
    }

    private async void OnClickedGoToUserPage(object sender, EventArgs e)
    {
        //TODO: Finns bättre lösning?
        await vm.LogIn();
        
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