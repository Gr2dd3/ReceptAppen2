using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Components
{
    internal interface IValidation
    {
        public bool IsValidated(string socialSecurityNr, string passWord);
    }
}
