namespace ReceptAppen2.Models
{
    //Using singleton since only one user is logged in and used on several places. (Keep calling only one instance a.k.a. same user)
    public class UserSingleton
    {
        private static readonly UserSingleton _instance = new UserSingleton();

        public User LoggedInUser { get; set; }
        public string AuthenticationTicket { get; set; }
        public string AuthorizationKey { get; set; }
        public string SessionTicket { get; set; }
        public bool IsloggedIn { get; set; }
        public bool FromUserRecipePage { get; set; }
        public HttpResponseMessage Response { get; set; }


        public static UserSingleton GetUser() { return _instance; }
        public async Task LogIn(string socSecNumber, string password)
        {
            LogInFacade tryLogIn = new LogInFacade();

            if (!IsloggedIn)
            {
                if (await tryLogIn.CanLogIn(socSecNumber, password))
                {
                    LoggedInUser = await UserService.GetUserAsync();
                    if (LoggedInUser is not null)
                        IsloggedIn = true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Fel", $"Kan ej hämta användare", "OK");
                }
            }
        }


        public void LogOut()
        {
            LoggedInUser = null;
            AuthenticationTicket = null;
            AuthorizationKey = null;
            Response = null;
            IsloggedIn = false;
            SessionTicket = null;
            FromUserRecipePage = false;
        }
    }
}
