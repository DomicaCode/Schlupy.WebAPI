using Autofac;
using Schlupy.Repository;
using Schlupy.Repository.Common;
using System.Linq;

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

            #region Services

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
               .Where(t => t.Name.EndsWith("Services"))
               .AsImplementedInterfaces();

            #endregion Services

            #region Filters

            //builder.RegisterAggregateService<IFilterFacade>();

            #endregion Filters
        }

        #endregion Methods
    }
}