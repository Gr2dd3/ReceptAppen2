using ReceptAppen2.Components;
using ReceptAppen2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.ApplicationFacade
{
    internal class LogInFacade : ILogInFacade
    {

        private readonly IValidation _validationService;
        private readonly IAuthentication _authenticationService;
        private readonly IAuthorization _authorizationService;

        public string AuthorizationKey { get; set; }

        public LogInFacade()
        {
            _validationService = new Validation();
            _authorizationService = new Authorization();
            _authenticationService = new Authentication();
        }

        public async Task<bool> CanLogIn(string socialSecurityNr, string passWord)
        {
            bool canLogIn = false;

            if (_validationService.IsValidated(socialSecurityNr, passWord) is true)
            {
                AuthorizationKey = _authorizationService.GetAuthorizationKey(socialSecurityNr, passWord);
                if (AuthorizationKey is not null) 
                {
                    if (await _authenticationService.IsAuthenticated(AuthorizationKey) is true)
                    {
                        canLogIn = true;
                    }
                }
            }

            return canLogIn;
        }
    }
}
