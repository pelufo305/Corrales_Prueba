using System.Reflection;
using Autofac;
using MediatR;
using Siigo.Corrales.Api.SeedWork;

using Module = Autofac.Module;

namespace Siigo.Corrales.Api.Infrastructure.AutofacModules
{
    /// <summary>
    /// Register all necessary dependencies for the MediatR library
    /// </summary>
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Parte de esto lo podemos ignorar si registramos con IServiceCollection.AddMediatR(...)
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });
            
            // Add Command Validations
            builder.RegisterGeneric(typeof(RequestValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));

        }
    }
}
