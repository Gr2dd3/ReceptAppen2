
using DnsClient;

namespace ReceptAppen2.Components
{
    
    internal class Authentication : IAuthentication
    {
        // STEG 3
        public async Task<bool> IsAuthenticated()
        {
            bool isAuthenticated = false;

            var client = new HttpClient();

            if (SessionsData.AuthorizationKey != null)
            {
                //TODO: Ta bort kommentarer?
                ////Request
                //var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/login");
                //request.Headers.Add("Authorization", "Basic " + SessionsData.AuthorizationKey);

                ////Response
                //var response = await client.SendAsync(request);

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
