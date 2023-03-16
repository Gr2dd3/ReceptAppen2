using System;
using System.Collections.Generic;
using System.Linq;
namespace ReceptAppen2.ViewModels
{
    internal partial class UserMainPageViewModel : ObservableObject
    {
        static readonly UserSingleton host = UserSingleton.GetUser();

        [ObservableProperty]
        User user;

        public UserMainPageViewModel()
        {
            User = host.LoggedInUser;
        }
    }
}
