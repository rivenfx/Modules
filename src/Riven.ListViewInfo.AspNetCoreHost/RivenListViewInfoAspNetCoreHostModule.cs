using Riven.Modular;

using System;
using System.Collections.Generic;
using System.Text;

namespace Riven
{
    [DependsOn(
        typeof(RivenListViewInfoEntityFrameworkCoreModule),
        typeof(RivenListViewInfoApplicationModule),
        typeof(RivenAspNetCoreHostSharedModule)

        )]
    public class RivenListViewInfoAspNetCoreHostModule : AppModule
    {
        public override void OnPreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.RegisterAssemblyOf<RivenListViewInfoAspNetCoreHostModule>();
        }
    }
}
