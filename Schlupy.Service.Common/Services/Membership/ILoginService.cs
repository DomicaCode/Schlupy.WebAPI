using Schlupy.Model.Common.Models;
using System.Threading.Tasks;

namespace Schlupy.Service.Common.Services.Membership
{
    public interface ILoginService
    {
        #region Methods

        Task<IToken> LoginAsync(string username, string password);

        #endregion Methods
    }
}