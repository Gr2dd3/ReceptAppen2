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
            }
            return user;
        }
    }
}
