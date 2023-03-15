using static ReceptAppen2.Models.SessionsData;
namespace ReceptAppen2.Services
{
    internal class UserService
    {
        internal static async Task<User> GetUserAsync()
        {
            User user = null;
            if (Response.IsSuccessStatusCode)
            {
                string responseString = await Response.Content.ReadAsStringAsync();
                user = JsonSerializer.Deserialize<User>(responseString);
                SetAuthenticationTicket();
            }
            return user;
        }

        private static void SetAuthenticationTicket()
        {
            SessionsData.AuthenticationTicket = SessionsData.Response.Headers
             .Where(x => x.Key.Contains("AuthenticationTicket"))
             .Select(x => x.Value.FirstOrDefault()).FirstOrDefault().ToString();    

        }
    }
}
