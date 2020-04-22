using Autofac;
using Schlupy.Repository;
using Schlupy.Repository.Common;

namespace Schlupy.Infrastructure
{
    public class DIModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            #region Repositories

            builder.RegisterGeneric(typeof(BaseRepository<,>))
                .As(typeof(IBaseRepository<,>));
            ;

            #endregion Repositories

            #region Filters

            //builder.RegisterAggregateService<IFilterFacade>();

            #endregion Filters
        }

        #endregion Methods
    }
}