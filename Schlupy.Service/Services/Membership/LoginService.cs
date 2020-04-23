using Schlupy.Common.Filters;
using Schlupy.Model.Common;
using Schlupy.Service.Common.Services.Authorization;
using Schlupy.Service.Common.Services.Membership;
using Schlupy.Service.Handlers;
using System;
using System.Threading.Tasks;

namespace Schlupy.Service.Services.Membership
{
    public class LoginService : ILoginService
    {
        #region Constructors

        public LoginService(IAuthorizationService authorizationService, IUserService userService)
        {
            AuthorizationService = authorizationService;
            UserService = userService;
        }

        #endregion Constructors

        #region Properties

        public IUserService UserService { get; }
        protected IAuthorizationService AuthorizationService { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<IToken> LoginAsync(string username, string password)
        {
            var filter = new UserFilter
            {
                Username = username
            };

            try
            {
                var user = await UserService.GetUserAsync(filter);
                if (user == null)
                {
                    //todo response handling
                    return default;
                }

                if (PasswordHandler.VerifyPassword(password, user.HashedPassword, user.PasswordSalt))
                {
                    return AuthorizationService.CreateToken(username, password);
                }

                //todo response handling
                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods
    }
}