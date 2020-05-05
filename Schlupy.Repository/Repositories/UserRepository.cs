using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schlupy.Common.Filters;
using Schlupy.DAL.Context;
using Schlupy.Model.Models;
using Schlupy.Repository.Common.Repositories;
using System.Threading.Tasks;

namespace Schlupy.Repository.Repositories
{
    public class UserRepository : BaseRepository<User, UserFilter>, IUserRepository
    {
        #region Constructors

        public UserRepository(SchlupyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        #endregion Constructors

        #region Methods

        public override async Task<User> GetAsync(UserFilter filter)
        {
            User result = default;

            if (filter.Id != null)
            {
                result = await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == filter.Id);
            }

            if (filter.Username != null)
            {
                result = await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Username == filter.Username);
            }

            if (filter.Email != null)
            {
                result = await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == filter.Email);
            }

            return result;
        }

        #endregion Methods
    }
}