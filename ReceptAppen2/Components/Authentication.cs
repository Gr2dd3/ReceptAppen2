using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Components
{
    
    internal class Authentication : IAuthentication
    {
        // STEG 3
        public HttpResponseMessage Response { get; set; }


        public async Task<bool> IsAuthenticated(string authorizationKey)
        {
            bool isAuthenticated = false;

            // REQUEST - KOLLA ATT RESPONSE ÄR GODKÄNT

            //Authorization
            var client = new HttpClient();

            //Request
            var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/login");
            request.Headers.Add("Authorization", "Basic " + authorizationKey);

            //Response
            var response = await client.SendAsync(request);


            // TRY IF WE GET A RESPONSE

            if (response.IsSuccessStatusCode)
            {
                isAuthenticated = true;
                Response = response;
            }
            else
            {
                isAuthenticated = false;
            }


            return isAuthenticated;
        }
    }
}
