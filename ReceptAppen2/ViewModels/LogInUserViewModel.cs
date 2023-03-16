
namespace ReceptAppen2.ViewModels
{
    public partial class LogInUserViewModel : ObservableObject
    {

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string socSecNumber;

        public LogInFacade TryLogIn { get; set; }


        public async Task LogIn()
        {
            TryLogIn = new LogInFacade();

            if (!SessionsData.IsloggedIn)
            {
                if (await TryLogIn.CanLogIn(SocSecNumber, Password))
                {
                    SessionsData.LoggedInUser = await UserService.GetUserAsync();
                    if (SessionsData.LoggedInUser is not null)
                        SessionsData.IsloggedIn = true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Fel", $"Kan ej hämta användare", "OK");
                }
            }
        }
    }
}