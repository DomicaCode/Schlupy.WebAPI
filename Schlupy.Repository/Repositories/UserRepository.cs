using Microsoft.EntityFrameworkCore;
using Schlupy.Common.Filters;
using Schlupy.Model.Models;
using Schlupy.Repository.Common.Repositories;
using System.Threading.Tasks;

namespace Schlupy.Repository.Repositories
{
    public class UserRepository : BaseRepository<User, UserFilter>, IUserRepository
    {
        #region Constructors

        public UserRepository(DAL.Context.SchlupyContext context, AutoMapper.IMapper mapper) : base(context, mapper)
        {
        }

        #endregion Constructors

        #region Methods

        public async override Task<User> GetAsync(UserFilter filter)
        {
            if (filter.Id != null)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == filter.Id);
            }
            else if (filter.Username != null)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Username == filter.Username);
            }
            else if (filter.Email != null)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == filter.Email);
            }

            return null;
        }

        #endregion Methods
    }
}