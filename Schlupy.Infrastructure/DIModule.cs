using Autofac;
using Schlupy.Repository;
using Schlupy.Repository.Common;
using Schlupy.Service.Common.Services.Authorization;
using Schlupy.Service.Common.Services.Membership;
using Schlupy.Service.Services.Authorization;
using Schlupy.Service.Services.Membership;

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

            #endregion Repositories

            #region Services

            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
            //   .Where(t => t.Name.EndsWith("Service"))
            //   .AsImplementedInterfaces();

            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();

            #endregion Services

            #region Filters

            //builder.RegisterAggregateService<IFilterFacade>();

            #endregion Filters
        }

        #endregion Methods
    }
}