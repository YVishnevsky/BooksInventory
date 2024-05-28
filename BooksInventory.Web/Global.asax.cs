using Autofac;
using Autofac.Integration.Web;
using Autofac.Integration.WebApi;
using BooksInventory.Data.EF;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace BooksInventory.Web
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[nameof(BookInventoryDbContext)].ConnectionString;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookInventoryDbContext, BooksInventory.DataAccess.EF6.Migrations.Configuration>(true));
            //using var ctx = new BookInventoryDbContext(connectionString);
            //ctx.Database.Migrate();

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(_ => new BookInventoryDbContext(connectionString))
                .InstancePerRequest();

            var configuration = MediatRConfigurationBuilder
            .Create(Assembly.GetExecutingAssembly())
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

            builder.RegisterMediatR(configuration);

            var container = builder.Build();

            _containerProvider = new ContainerProvider(container);

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}