using Riven.Modular;

using System;
using System.Collections.Generic;
using System.Text;

namespace Riven
{
    public class RivenListViewInfoDomainModule : AppModule
    {
        public override void OnPreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.RegisterAssemblyOf<RivenListViewInfoDomainModule>();
        }
    }
}
