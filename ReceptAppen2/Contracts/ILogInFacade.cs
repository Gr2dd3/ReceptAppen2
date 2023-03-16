namespace ReceptAppen2.Contracts
{
    internal interface ILogInFacade
    {
        public Task<bool> CanLogIn(string socialSecurityNr, string passWord);
    }
}
