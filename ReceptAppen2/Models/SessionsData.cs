using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Models
{
    public static class SessionsData
    {
        public static User LoggedInUser { get; set; }
        public static string AuthorizationKey { get; set; }

        public static HttpResponseMessage Response { get; set; }

    }
}
