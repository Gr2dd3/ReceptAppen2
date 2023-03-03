namespace ReceptAppen2.Services
{
    internal class RecipeSearchService
    {
        public static async Task<RecipeSearch> GetRecipeSearchAsync(/*string apiKey*/)
        {
            // Mattias
            string hardCodedUser = "ODYxMjMwMDI3MDo0ODQzMTE=";

            // Request
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/searchwithfilters?phrase=pizza&recordsPerPage=3&pageNumber=1&sorting=0");
            request.Headers.Add("Authorization", "Basic " + hardCodedUser);

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
