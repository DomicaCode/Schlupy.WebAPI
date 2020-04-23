using Schlupy.Common.Filters;
using Schlupy.Model.Models;
using Schlupy.Repository.Common.Repositories;
using Schlupy.Service.Common.Services.Membership;
using Schlupy.Service.Handlers;
using System.Threading.Tasks;

namespace Schlupy.Service.Services.Membership
{
    public class UserService : IUserService
    {
        #region Constructors

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        #endregion Constructors

        #region Properties

        public IUserRepository UserRepository { get; }

        #endregion Properties

        #region Methods

        public async Task<User> GetUserAsync(UserFilter filter)
        {
            return await UserRepository.GetAsync(filter);
        }

        public async Task<bool> RegisterAsync(User user)
        {
            var hashedPassword = PasswordHandler.GenerateSaltedHash(64, user.Password);

            user.HashedPassword = hashedPassword.Hash;
            user.PasswordSalt = hashedPassword.Salt;

            return await UserRepository.InsertAsync(user);
        }

        #endregion Methods
    }
}