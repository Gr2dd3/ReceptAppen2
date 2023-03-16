

namespace ReceptAppen2.ApplicationFacade
{
    public class LogInFacade : ILogInFacade
    {

        private readonly IValidation _validationService;
        private readonly IAuthentication _authenticationService;
        private readonly IAuthorization _authorizationService;


        public LogInFacade()
        {
            _validationService = new Validation();
            _authorizationService = new Authorization();
            _authenticationService = new Authentication();
        }

        public async Task<bool> CanLogIn(string socialSecurityNr, string passWord)
        {
            if (_validationService.IsValidated(socialSecurityNr, passWord) &&
                _authorizationService.GetAuthorizationKey(socialSecurityNr, passWord) &&
                await _authenticationService.IsAuthenticated())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
