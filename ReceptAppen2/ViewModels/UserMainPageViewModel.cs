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
    }
}
