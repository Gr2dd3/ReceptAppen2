﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Components
{
    internal interface IAuthentication
    {
        public Task<bool> IsAuthenticated();
    }
}
