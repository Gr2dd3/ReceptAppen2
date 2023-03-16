
using DnsClient;

namespace ReceptAppen2.Components
{
    
    internal class Authentication : IAuthentication
    {
        public async Task<bool> IsAuthenticated()
        {
            bool isAuthenticated = false;

            var client = new HttpClient();

            if (SessionsData.AuthorizationKey != null)
            {
                var response = await RecipeSearchService.GetApiRequest("/api/login", false, true);

                if (response.IsSuccessStatusCode)
                {
                    isAuthenticated = true;
                    SessionsData.Response = response;
                }
                else
                {
                    isAuthenticated = false;
                }
            }
            return isAuthenticated;
        }
    }
}
