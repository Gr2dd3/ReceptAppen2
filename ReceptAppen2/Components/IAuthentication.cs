namespace ReceptAppen2.Components
{
    internal interface IAuthentication
    {
        public Task<bool> IsAuthenticated();
    }
}
