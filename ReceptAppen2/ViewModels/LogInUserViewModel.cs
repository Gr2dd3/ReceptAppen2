
namespace ReceptAppen2.ViewModels
{
    public partial class LogInUserViewModel : ObservableObject
    {
        static readonly UserSingleton host = UserSingleton.GetUser();

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string socSecNumber;

        public LogInFacade TryLogIn { get; set; }


        public async Task LogIn()
        {
            TryLogIn = new LogInFacade();

            if (!host.IsloggedIn)
            {
                if (await TryLogIn.CanLogIn(SocSecNumber, Password))
                {
                    host.LoggedInUser = await UserService.GetUserAsync();
                    if (host.LoggedInUser is not null)
                        host.IsloggedIn = true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Fel", $"Kan ej hämta användare", "OK");
                }
            }
        }
    }
}