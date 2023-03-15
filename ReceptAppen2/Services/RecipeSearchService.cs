﻿namespace ReceptAppen2.Services
{
    public class RecipeSearchService
    {

        public static async Task<RecipeSearch> GetRecipeSearchAsync(string searchPhrase)
        {
            //TODO: Ta bort kommentarer?
            //// Request
            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, $"https://handla.api.ica.se/api/recipes/searchwithfilters?phrase={searchPhrase}&recordsPerPage=20&pageNumber=1&sorting=0");
            //request.Headers.Add("Authorization", "Basic " + SessionsData.AuthorizationKey);
            //request.Headers.Add("AuthenticationTicket", SessionsData.AuthenticationTicket);

            //// Response
            //var response = await client.SendAsync(request);

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
            //TODO: Ta bort kommentarer?
            //// Request
            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/random?numberofrecipes=6");

            //// Response
            //var response = await client.SendAsync(request);

            var response = await GetApiRequest("/api/recipes/random?numberofrecipes=6", false, false);
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
            //TODO: Ta bort kommentarer?
            //// Request
            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/recipe/" + recipeId);

            //// Response
            //var response = await client.SendAsync(request);


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
            var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se" + uri);

            if (HasHeaders)
            {
                request.Headers.Add("Authorization", "Basic " + SessionsData.AuthorizationKey);
                request.Headers.Add("AuthenticationTicket", SessionsData.AuthenticationTicket);
            }
            else if (HasOneHeaderOnly)
            {
                request.Headers.Add("Authorization", "Basic " + SessionsData.AuthorizationKey);
            }
            var response = await client.SendAsync(request);

            return response;
        }
    }
}
