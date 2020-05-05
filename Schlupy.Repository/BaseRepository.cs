using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schlupy.Common;
using Schlupy.DAL.Context;
using Schlupy.Model.Common;
using Schlupy.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schlupy.Repository
{
    public class BaseRepository<TEntity, TFilter> : IBaseRepository<TEntity, TFilter>
        where TEntity : class, IBaseModel, new()
        where TFilter : class, IGenericFilter, new()
    {
        #region Fields

        protected readonly DbSet<TEntity> DbSet;
        private readonly SchlupyContext _context;

        #endregion Fields

        #region Constructors

        protected BaseRepository(SchlupyContext context, IMapper mapper)
        {
            Mapper = mapper;
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        #endregion Constructors

        #region Properties

        private IMapper Mapper { get; }

        #endregion Properties

        #region Methods

        public virtual async Task<bool> DeleteAsync(Guid entityId)
        {
            var filter = new TFilter
            {
                Id = entityId
            };
            var entity = await GetAsync(filter);

            var result = DbSet.Remove(entity);

            if (result.State != EntityState.Deleted) return false;

            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> EditAsync(TEntity entity)
        {
            var filter = new TFilter
            {
                Id = entity.Id
            };

            var currentEntity = await GetAsync(filter);

            var foodItemToEdit = Mapper.Map(entity, currentEntity);

            var result = DbSet.Update(foodItemToEdit);

            if (result.State != EntityState.Modified) return false;

            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(TFilter filter)
        {
            if (filter.Id != null)
            {
                return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == filter.Id);
            }

            return null;
        }

        public virtual async Task<bool> InsertAsync(TEntity entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.DateUpdated = DateTime.UtcNow;

            var result = await DbSet.AddAsync(entity);

            if (result.State != EntityState.Added) return false;

            await _context.SaveChangesAsync();

            return true;
        }

        #endregion Methods
    }
}