using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Components
{
    internal class Authorization : IAuthorization
    {
        // STEG 2
        public string GetAuthorizationKey(string socialSecurityNr, string passWord)
        {
            string authorizationKey = string.Empty;

            // STEG 2 HÄR
            var plainText = socialSecurityNr + ":" + passWord;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            authorizationKey = System.Convert.ToBase64String(plainTextBytes);

            return authorizationKey;
        }
    }
}
