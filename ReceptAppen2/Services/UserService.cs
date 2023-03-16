using ReceptAppen2.Singletons;

namespace ReceptAppen2.Services
{
    internal class UserService
    {
        static readonly UserSingleton host = UserSingleton.GetUser();
        internal static async Task<User> GetUserAsync()
        {
            User user = null;
            if (host.Response.IsSuccessStatusCode)
            {
                string responseString = await host.Response.Content.ReadAsStringAsync();
                user = JsonSerializer.Deserialize<User>(responseString);
                SetAuthenticationTicket();
            }
            return user;
        }

        private static void SetAuthenticationTicket()
        {
            host.AuthenticationTicket = host.Response.Headers
             .Where(x => x.Key.Contains("AuthenticationTicket"))
             .Select(x => x.Value.FirstOrDefault()).FirstOrDefault().ToString();    

        }
    }
}
