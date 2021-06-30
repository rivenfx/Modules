using Riven.Modular;
using Riven.Extensions;
using Riven;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Riven
{
    [DependsOn(
       typeof(RivenDomainSharedModule)
       )]
    public class RivenEntityFrameworkCoreSharedModule : AppModule
    {
        public override void OnPreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.RegisterAssemblyOf<RivenEntityFrameworkCoreSharedModule>();

            context.Services.Replace(new ServiceDescriptor(
                typeof(IDomainService<>),
                typeof(EfCoreDomainService<>),
                ServiceLifetime.Transient
                ));
            context.Services.Replace(new ServiceDescriptor(
               typeof(IDomainService<,>),
               typeof(EfCoreDomainService<,>),
               ServiceLifetime.Transient
               ));
        }
    }
}

