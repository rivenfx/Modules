using Riven.Modular;

using System;
using System.Collections.Generic;
using System.Text;

namespace Riven
{
    [DependsOn(
        typeof(RivenListViewInfoDomainModule),
        typeof(RivenEntityFrameworkCoreSharedModule)
        )]
    public class RivenListViewInfoEntityFrameworkCoreModule : AppModule
    {
        public override void OnPreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.RegisterAssemblyOf<RivenListViewInfoEntityFrameworkCoreModule>();
        }
    }
}
