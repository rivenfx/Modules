using Riven.Modular;
using Riven.Extensions;
using Riven;

namespace Riven
{
    public class RivenDomainSharedModule : AppModule
    {
        public override void OnPreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.RegisterAssemblyOf<RivenDomainSharedModule>();
        }
    }
}

