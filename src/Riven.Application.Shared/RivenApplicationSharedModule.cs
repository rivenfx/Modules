using Riven.Modular;
using Riven.Extensions;
using Riven;

namespace Riven
{
    [DependsOn(
        typeof(RivenDomainSharedModule)
        )]
    public class RivenApplicationSharedModule : AppModule
    {
        public override void OnPreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.RegisterAssemblyOf<RivenApplicationSharedModule>();
        }
    }
}

