using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Contracts
{
    internal interface ILogInFacade
    {
        public Task<bool> CanLogIn(string socialSecurityNr, string passWord);
    }
}
