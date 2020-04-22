using Schlupy.Common;
using Schlupy.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schlupy.Repository.Common
{
    public interface IBaseRepository<TEntity, in TFilter> where TEntity : class, IBaseModel, new() where TFilter : class, IGenericFilter
    {
        #region Methods

        Task<bool> DeleteAsync(Guid foodId);

        Task<bool> EditAsync(TEntity entity);

        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(TFilter filter);

        Task<bool> InsertAsync(TEntity entity);

        #endregion Methods
    }
}