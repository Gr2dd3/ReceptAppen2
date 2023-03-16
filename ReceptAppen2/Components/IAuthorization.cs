namespace ReceptAppen2.Components
{
    internal interface IAuthorization
    {
        public bool GetAuthorizationKey(string socialSecurityNr, string passWord);
    }
}
