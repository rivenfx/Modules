using Riven.Modular;

using System;
using System.Collections.Generic;
using System.Text;

namespace Riven
{
    [DependsOn(
      typeof(RivenListViewInfoDomainModule)
      )]
    public class RivenListViewInfoApplicationModule : AppModule
    {
        public override void OnPreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.RegisterAssemblyOf<RivenListViewInfoApplicationModule>();
        }
    }
}
