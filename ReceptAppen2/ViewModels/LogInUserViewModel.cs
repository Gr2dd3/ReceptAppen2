
namespace ReceptAppen2.ViewModels
{
    public partial class LogInUserViewModel : ObservableObject
    {

        [ObservableProperty]
        string pass1;

        [ObservableProperty]
        string socsecnr;

        public LogInFacade TryLogIn { get; set; }


        public async Task LogIn()
        {
            TryLogIn = new LogInFacade();

            if (SessionsData.LoggedInUser == null)
            {
                if (await TryLogIn.CanLogIn(Socsecnr, Pass1))
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