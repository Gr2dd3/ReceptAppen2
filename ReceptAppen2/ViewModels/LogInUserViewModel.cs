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



        [RelayCommand]
        public async void LogIn()
        {
            TryLogIn = new LogInFacade();
            SessionsData.LoggedInUser = null;
            if (SessionsData.LoggedInUser == null)
            {
                if (await TryLogIn.CanLogIn(Socsecnr, Pass1))
                {
                    try
                    {
                        SessionsData.LoggedInUser = await UserService.GetUserAsync();
                        if (SessionsData.LoggedInUser is not null)
                        {
                            SessionsData.IsloggedIn = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        await Shell.Current.DisplayAlert("Fel", $"Kan ej hämta användare: {ex.Message}", "OK");
                    }
                }
            }
        }
    }
}