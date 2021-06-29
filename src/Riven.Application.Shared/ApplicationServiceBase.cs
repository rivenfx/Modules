using Riven.Application;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Riven.Uow;
using Microsoft.Extensions.Configuration;
using Riven.Localization;

namespace Riven
{
    public abstract class ApplicationServiceBase : IApplicationService
    {
        protected readonly IServiceProvider _serviceProvider;

        protected ApplicationServiceBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            this.UnitOfWorkManager = this.GetService<IUnitOfWorkManager>();
            this.Configuration = this.GetService<IConfiguration>();
            this.LanguageManager = this.GetService<ILanguageManager>();
            this.CurrentLanguage = this.GetService<ICurrentLanguage>();
        }

        protected virtual IUnitOfWorkManager UnitOfWorkManager { get; }
        protected virtual IActiveUnitOfWork CurrentUnitOfWork => UnitOfWorkManager.Current;
        protected virtual IConfiguration Configuration { get; }
        protected virtual ILanguageManager LanguageManager { get; }
        protected virtual ICurrentLanguage CurrentLanguage { get; }


        protected virtual TService GetService<TService>()
        {
            return this._serviceProvider.GetRequiredService<TService>();
        }
    }
}
