using static ReceptAppen2.Models.SessionsData;
namespace ReceptAppen2.Services
{
    internal class UserService
    {
        /// <summary>
        /// GetUserAsync
        /// </summary>
        /// <returns></returns>
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
            //SessionsData.AuthenticationTicket = SessionsData.Response.Content.Headers.Select(x => x.Key).Where(x => x.Key == "AuthenticationTicket").FirstOrDefault();

            var auth = SessionsData.Response.Content.Headers.Where(x => x.Key.Contains("AuthenticationTicket")).Select(x => x.Value).FirstOrDefault();

        }
    }
}
