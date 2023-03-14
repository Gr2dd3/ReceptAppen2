using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.ViewModels
{
    internal partial class UserMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        User user;


        public UserMainPageViewModel()
        {
            User = SessionsData.LoggedInUser;
        }

        public static void LogOut()
        { 
            SessionsData.LoggedInUser = null;
            SessionsData.AuthenticationTicket = null;
            SessionsData.AuthorizationKey = null;
            SessionsData.Response = null;
            SessionsData.IsloggedIn = false;
            SessionsData.SessionTicket = null;
            SessionsData.FromUserRecipePage = false;
        }
    }
}
