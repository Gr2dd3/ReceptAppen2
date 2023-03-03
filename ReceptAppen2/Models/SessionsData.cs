using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Models
{
    public static class SessionsData
    {
        public static long SocialSecurityNumber { get; set; }
        public static int Password { get; set; }
        public static User User { get; set; }

        public static Recipe OneRecipe { get; set; }
    }
}
