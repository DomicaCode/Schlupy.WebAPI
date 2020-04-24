using Schlupy.Common.Filters;
using Schlupy.Model.Models;
using Schlupy.Repository.Common.Repositories;
using Schlupy.Service.Common.Services.Membership;
using Schlupy.Service.Handlers;
using System;
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
            var filter = new UserFilter
            {
                Username = user.Username
            };

            var currentUser = await GetUserAsync(filter);

            if (currentUser != null)
            {
                throw new Exception("User already exists");
            }

            var hashedPassword = PasswordHandler.GenerateSaltedHash(64, user.Password);

            user.HashedPassword = hashedPassword.Hash;
            user.PasswordSalt = hashedPassword.Salt;

            try
            {
                return await UserRepository.InsertAsync(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods
    }
}