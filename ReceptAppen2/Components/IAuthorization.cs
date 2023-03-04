using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Components
{
    internal interface IAuthorization
    {
        public string GetAuthorizationKey(string socialSecurityNr, string passWord);
    }
}
