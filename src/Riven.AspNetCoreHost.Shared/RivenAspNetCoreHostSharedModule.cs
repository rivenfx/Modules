using Riven.Modular;
using Riven.Extensions;
using Riven;

namespace Riven
{
    [DependsOn(
        typeof(RivenEntityFrameworkCoreSharedModule),
        typeof(RivenApplicationSharedModule)
        )]
    public class RivenAspNetCoreHostSharedModule : AppModule
    {
        public override void OnPreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.RegisterAssemblyOf<RivenAspNetCoreHostSharedModule>();
        }
    }
}


