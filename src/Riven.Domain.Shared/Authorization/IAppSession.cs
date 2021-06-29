using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using Riven.Localization;

using System;
using System.Collections.Generic;
using System.Text;
using Riven.Dependency;
using System.Security.Claims;

namespace Riven.Authorization
{
    /// <summary>
    /// 当前
    /// </summary>
    public interface IAppSession : ITransientDependency
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// 用户账号
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// 租户Id - 字符串类型
        /// </summary>
        string TenantName { get; }

        /// <summary>
        /// 指定类型的用户id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetUserId<T>();
    }
}
