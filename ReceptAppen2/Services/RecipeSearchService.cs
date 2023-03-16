using ReceptAppen2.Singletons;

namespace ReceptAppen2.Services
{
    public class RecipeSearchService
    {
        private static string _apiBaseAddress = "https://handla.api.ica.se";
        static readonly UserSingleton host = UserSingleton.GetUser();
        public static async Task<RecipeSearch> GetRecipeSearchAsync(string searchPhrase)
        {
            var response = await GetApiRequest($"/api/recipes/searchwithfilters?phrase={searchPhrase}&recordsPerPage=20&pageNumber=1&sorting=0", true, false);
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
            var response = await GetApiRequest("/api/recipes/random?numberofrecipes=10", false, false);
            response.EnsureSuccessStatusCode();
            RecipeSearch recipeSearch = new();
            if (response is not null)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                recipeSearch = JsonSerializer.Deserialize<RecipeSearch>(responseString);
            }
            return recipeSearch;

        }

        public static async Task<Recipe> GetOneRecipeAsync(int recipeId)
        {
            var response = await GetApiRequest("/api/recipes/recipe/" + recipeId, false, false);
            response.EnsureSuccessStatusCode();

            Recipe recipe = new();
            if (response is not null)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                recipe = JsonSerializer.Deserialize<Recipe>(responseString);
            }
            return recipe;
        }

        public static async Task<HttpResponseMessage> GetApiRequest(string uri, bool HasHeaders, bool HasOneHeaderOnly)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, _apiBaseAddress + uri);

            if (HasHeaders)
            {
                request.Headers.Add("Authorization", "Basic " + host.AuthorizationKey);
                request.Headers.Add("AuthenticationTicket", host.AuthenticationTicket);
            }
            else if (HasOneHeaderOnly)
            {
                request.Headers.Add("Authorization", "Basic " + host.AuthorizationKey);
            }
            var response = await client.SendAsync(request);

            return response;
        }
    }
}
