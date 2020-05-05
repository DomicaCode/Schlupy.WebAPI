using Schlupy.Common.Filters;
using Schlupy.Model.Common.Models;
using Schlupy.Service.Common.Services.Authorization;
using Schlupy.Service.Common.Services.Membership;
using Schlupy.Service.Handlers.Password;
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

        private IAuthorizationService AuthorizationService { get; set; }
        private IUserService UserService { get; }

        #endregion Properties

        #region Methods

        public async Task<IToken> LoginAsync(string username, string password)
        {
            var filter = new UserFilter
            {
                Username = username
            };

            var user = await UserService.GetUserAsync(filter);
            if (user == null)
            {
                return default;
            }

            return PasswordHandler.VerifyPassword(password, user.HashedPassword, user.PasswordSalt) ?
                AuthorizationService.CreateToken(user)
                : default;
        }

        #endregion Methods
    }
}