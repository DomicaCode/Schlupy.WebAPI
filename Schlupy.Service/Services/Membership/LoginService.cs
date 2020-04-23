using Schlupy.Model.Common;
using Schlupy.Service.Common.Services.Authorization;
using Schlupy.Service.Common.Services.Membership;
using System.Threading.Tasks;

namespace Schlupy.Service.Services.Membership
{
    public class LoginService : ILoginService
    {
        #region Constructors

        public LoginService(IAuthorizationService authorizationService)
        {
            AuthorizationService = authorizationService;
        }

        #endregion Constructors

        #region Properties

        protected IAuthorizationService AuthorizationService { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<IToken> LoginAsync(string username, string password)
        {
            if (username == "domica" && password == "domica")
            {
                return AuthorizationService.CreateToken(username, password);
            }
            return default;
        }

        #endregion Methods
    }
}