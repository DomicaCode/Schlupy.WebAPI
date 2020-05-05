using Schlupy.Model.Common.Models;
using Schlupy.Model.Models;

namespace Schlupy.Service.Common.Services.Authorization
{
    public interface IAuthorizationService
    {
        #region Methods

        IToken CreateToken(User user);

        #endregion Methods
    }
}