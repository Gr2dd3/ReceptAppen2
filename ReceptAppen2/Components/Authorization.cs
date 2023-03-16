using ReceptAppen2.Singletons;

namespace ReceptAppen2.Components
{
    internal class Authorization : IAuthorization
    {
        static readonly UserSingleton host = UserSingleton.GetUser();
        public bool GetAuthorizationKey(string socialSecurityNr, string passWord)
        {
            var plainText = socialSecurityNr + ":" + passWord;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            host.AuthorizationKey = System.Convert.ToBase64String(plainTextBytes);

            if (host.AuthorizationKey is not null)
                return true;
            else
                return false;
        }

    }
}
