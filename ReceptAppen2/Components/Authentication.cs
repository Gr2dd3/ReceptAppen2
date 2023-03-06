
namespace ReceptAppen2.Components
{
    
    internal class Authentication : IAuthentication
    {
        // STEG 3
        public async Task<bool> IsAuthenticated()
        {
            bool isAuthenticated = false;
            // REQUEST - KOLLA ATT RESPONSE ÄR GODKÄNT
            //Authorization
            var client = new HttpClient();

            if (SessionsData.AuthorizationKey != null)
            {
                //Request
                var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/login");
                request.Headers.Add("Authorization", "Basic " + SessionsData.AuthorizationKey);

                //Response
                var response = await client.SendAsync(request);
                // TRY IF WE GET A RESPONSE
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
