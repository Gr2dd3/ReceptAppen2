using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Models
{
    public class UserSingleton
    {
        private static readonly UserSingleton _instance = new UserSingleton();

        public User LoggedInUser { get; set; }
        public string AuthorizationKey { get; set; }
        public HttpResponseMessage Response { get; set; }
        public string AuthenticationTicket { get; set; }
        public string SessionTicket { get; set; }
        public bool IsloggedIn { get; set; }
        public bool FromUserRecipePage { get; set; }

        public static UserSingleton GetUser() { return _instance; }
        public void LogOut()
        {
            LoggedInUser = null;
            AuthenticationTicket = null;
            AuthorizationKey = null;
            Response = null;
            IsloggedIn = false;
            SessionTicket = null;
            FromUserRecipePage = false;
        }
    }
}
