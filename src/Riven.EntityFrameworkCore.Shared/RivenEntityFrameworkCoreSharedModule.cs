using Riven.Modular;
using Riven.Extensions;
using Riven;

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
        }
    }
}

