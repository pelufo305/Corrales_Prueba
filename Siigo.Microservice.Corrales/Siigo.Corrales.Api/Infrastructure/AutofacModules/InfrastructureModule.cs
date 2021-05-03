using Autofac;
using Microsoft.Extensions.Configuration;
using Siigo.Corrales.Infrastructure;
using Serilog;
using Serilog.Core;
using Siigo.Core.Interface;
using Siigo.Core.Provider;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
using Siigo.Corrales.Infrastructure.Finder;
using Siigo.Corrales.Infrastructure.Repository;
using Siigo.Corrales.Domain.AggregatesModel.AnimalAggregate;

namespace Siigo.Corrales.Api.Infrastructure.AutofacModules
{
    /// <summary>
    /// Register all infrastructure related objects
    /// </summary>
    public class InfrastructureModule : Module
    {
        private readonly string _databaseConnectionString;
        private readonly IConfiguration _configuration; 
        

        public InfrastructureModule(IConfiguration configuration)
        {
            _configuration = configuration;
            _databaseConnectionString = _configuration["SqlServerConnection"];
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            //  Repository’s lifetime should usually be set as scoped

            builder.RegisterInstance(_configuration).As<IConfiguration>();
            builder.RegisterType<TenantProvider>()
                .As<ITenantProvider>()
                .SingleInstance();

            builder
                .RegisterType<CorralFinder>()
                .As<ICorralFinder>()
                .SingleInstance();

            builder
                .RegisterType<CorralRepository>()
                .As<ICorralRepository>()
                .SingleInstance();

            builder
               .RegisterType<AnimalFinder>()
               .As<IAnimalFinder>()
               .SingleInstance();


            builder
              .RegisterType<AnimalRepository>()
              .As<IAnimalRepository>()
              .SingleInstance();


        }
    }
}
