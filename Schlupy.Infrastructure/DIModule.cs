using Autofac;
using Schlupy.Repository;
using Schlupy.Repository.Common;
using Schlupy.Repository.Common.Repositories;
using Schlupy.Repository.Repositories;
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

            builder.RegisterType<UserRepository>().As<IUserRepository>();

            #endregion Repositories

            #region Services

            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
            //   .Where(t => t.Name.EndsWith("Service"))
            //   .AsImplementedInterfaces();

            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();
            builder.RegisterType<UserService>().As<IUserService>();

            #endregion Services

            #region Filters

            //builder.RegisterAggregateService<IFilterFacade>();

            #endregion Filters
        }

        #endregion Methods
    }
}