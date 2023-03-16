using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Components
{
    internal class Authorization : IAuthorization
    {
        public bool GetAuthorizationKey(string socialSecurityNr, string passWord)
        {
            var plainText = socialSecurityNr + ":" + passWord;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            SessionsData.AuthorizationKey = System.Convert.ToBase64String(plainTextBytes);

            if (SessionsData.AuthorizationKey is not null)
                return true;
            else
                return false;
        }

    }
}
