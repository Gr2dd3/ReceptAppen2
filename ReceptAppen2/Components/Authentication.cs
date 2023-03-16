namespace ReceptAppen2.Components
{
    internal class Authentication : IAuthentication
    {
        static readonly UserSingleton host = UserSingleton.GetUser();

        public async Task<bool> IsAuthenticated()
        {
            bool isAuthenticated = false;

            var client = new HttpClient();

            if (host.AuthorizationKey != null)
            {
                var response = await RecipeSearchService.GetApiRequest("/api/login", false, true);

                if (response.IsSuccessStatusCode)
                {
                    isAuthenticated = true;
                    host.Response = response;
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
