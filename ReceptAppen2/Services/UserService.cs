using static ReceptAppen2.Models.SessionsData;
namespace ReceptAppen2.Services
{
    internal class UserService
    {
        /// <summary>
        /// GetUserAsync
        /// </summary>
        /// <returns></returns>
        internal static async Task GetUserAsync()
        {
            if (Response.IsSuccessStatusCode)
            {
                string responseString = await Response.Content.ReadAsStringAsync();
                LoggedInUser = JsonSerializer.Deserialize<User>(responseString);
            }
        }
    }
}
