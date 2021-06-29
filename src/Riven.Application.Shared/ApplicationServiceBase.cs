using Riven.Application;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Riven.Uow;
using Microsoft.Extensions.Configuration;
using Riven.Localization;
using Riven.Authorization;

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
            this.CurrentLanguage = this.GetService<ICurrentLanguage>().GetCurrentLanguage();
            this.AppSession = this.GetService<IAppSession>();
        }

        /// <summary>
        /// 工作单元管理器
        /// </summary>
        protected virtual IUnitOfWorkManager UnitOfWorkManager { get; }
        /// <summary>
        /// 当前工作单元
        /// </summary>
        protected virtual IActiveUnitOfWork CurrentUnitOfWork => UnitOfWorkManager.Current;
        /// <summary>
        /// 配置信息
        /// </summary>
        protected virtual IConfiguration Configuration { get; }
        /// <summary>
        /// 语言管理器
        /// </summary>
        protected virtual ILanguageManager LanguageManager { get; }
        /// <summary>
        /// 当前语言
        /// </summary>
        protected virtual LanguageInfo CurrentLanguage { get; }
        /// <summary>
        /// 当前登录信息
        /// </summary>
        protected virtual IAppSession AppSession { get; }

        /// <summary>
        /// 从Ioc容器中获取服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>服务实例</returns>
        protected virtual TService GetService<TService>()
        {
            return this._serviceProvider.GetRequiredService<TService>();
        }
    }
}
