using ReceptAppen2.ApplicationFacade;

namespace ReceptAppen2.ViewModels
{
    public partial class LogInUserViewModel : ObservableObject
    {
        //[ObservableProperty]
        //string password;

        //[ObservableProperty]
        //string socialSecurityNumber;
        [ObservableProperty]
        string pass1;

        [ObservableProperty]
        string socsecnr;

        public LogInFacade TryLogIn { get; set; }

        public LogInUserViewModel()
        {
        }

        public async void LogIn()
        {
            TryLogIn = new LogInFacade();
            if (SessionsData.LoggedInUser == null)
            {
                if (await TryLogIn.CanLogIn(Socsecnr, Pass1))
                {
                    await UserService.GetUserAsync();
                }
            }
            string name = SessionsData.LoggedInUser.FirstName;
        }
    }
}
