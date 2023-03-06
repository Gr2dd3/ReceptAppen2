using ReceptAppen2.ApplicationFacade;
using System.Diagnostics;

namespace ReceptAppen2.ViewModels
{
    public partial class LogInUserViewModel : ObservableObject
    {

        [ObservableProperty]
        string pass1;

        [ObservableProperty]
        string socsecnr;

        public LogInFacade TryLogIn { get; set; }

        public LogInUserViewModel()
        {

        }

        [RelayCommand]
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
        }
    }
}