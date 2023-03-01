using ReceptAppen2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReceptAppen2.Services
{
    internal class RecipeSearchService
    {
        public static async Task<RecipeSearch> GetRecipeSearchAsync()
        {
            // Mattias
            string hardCodedUser = "ODYxMjMwMDI3MDo0ODQzMTE=";

            // Request
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/searchwithfilters?phrase=pizza&recordsPerPage=3&pageNumber=1&sorting=0");
            request.Headers.Add("AuthenticationTicket", "B14B0F7B17528C02A93AB6FA98FDF5BF8599F30BA078B905C98961635F3A755EA22589E3C3F219EF0C0EB3DD20D4F369DB47341CF2B890231F2E2D2200448476CABE602ADCFAA7B72E0EBDF8EEA3842567660BFEB148E18C4A717B86C1C7704AA145FFC8CB0E482FB2C0B3F97D1D269CACA3F1AA61634D6F58A849625AA81D34A99A1AFC79CB1C70D9D57FD7A4A845F0F8D38A1439DF2E59A0428CF73A1C71D386918B3109F56F9656BCD6065BBB64820E4E61AED1595320B41DF5B1273B82C7A51B6EB7DBC70F212FBC83C8E8B396DFE7B659500167F7555DD3A1EF8942C830F19B3D3CA9A2047559AB399C05FD348D798B85C4788C9E6E6E0D483DA765757C525D81961D59F2169A43A9A2A7E4BA8D8D9B64313A84757FE7D1235AA7B89E385917CE7C7634F276E80DB0FDEA7AA18BCE9EFC2C9F32C2FDC26A45BC2D1F6989E2CB9EAE275CB1F1D9F6F8F4070BD6C64F966F4CB745BACF8BDA9FB12C04109A79E80C9668DF2437BB45FFDFACB6F52350A764340D109FE4B7CE72F888864B58C5371E6E486AF375CC31DECF61C424E5164B8A91997B4B269E997C39750817E64AFDEADE62744549AD244A8CE1BC9DF96BD222DC7B83D8DE873AD2F78F8FBC61F427F91C2B413BE698264D74C3947FBD1B74F7E21C42673A174B6E7CECC79B98279B038BFECF6DB8AEF75C6AB1D58968F3E86E1A");
            request.Headers.Add("Authorization", "Basic " + hardCodedUser);
            request.Headers.Add("Cookie", "TS01841c8a=01f0ddaba3d8350c1fb6ba1df9d83fd8213e1caf6fba9885e24b95e6b73f963098e3c47119ef650d4a13359c20fadf293c0de6b861");

            // Response
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            RecipeSearch recipeSearch = new();
            if (response is not null)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                recipeSearch = JsonSerializer.Deserialize<RecipeSearch>(responseString);
            }
            return recipeSearch;
        }

        public static async Task<RecipeSearch> GetRandomRecipesAsync()
        {
            // Request
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/random?numberofrecipes=6");
            
            // Response
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            RecipeSearch recipeSearch = new();
            if (response is not null)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                recipeSearch = JsonSerializer.Deserialize<RecipeSearch>(responseString);
            }
            return recipeSearch;
        }
    }
}
