using Schlupy.Common.Filters;
using Schlupy.Model.Models;

namespace Schlupy.Repository.Common.Repositories
{
    public interface IUserRepository : IBaseRepository<User, UserFilter>
    {
    }
}