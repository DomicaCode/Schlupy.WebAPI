using Schlupy.Common.Filters;
using Schlupy.Model.Models;
using Schlupy.Model.Response;
using System.Threading.Tasks;

namespace Schlupy.Service.Common.Services.Membership
{
    public interface IUserService
    {
        #region Methods

        Task<User> GetUserAsync(UserFilter filter);

        Task<BaseResponse> RegisterAsync(User user);

        #endregion Methods
    }
}