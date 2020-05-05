using Schlupy.Model.Common.Models;

namespace Schlupy.Service.Common.Services.Authorization
{
    public interface IAuthorizationService
    {
        #region Methods

        IToken CreateToken(string usernName, string password);

        #endregion Methods
    }
}