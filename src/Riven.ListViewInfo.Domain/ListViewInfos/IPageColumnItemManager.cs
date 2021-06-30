
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Riven.ListViewInfos
{
    public interface IPageColumnItemManager : IDomainService<PageColumnItem, Guid>
    {
        /// <summary>
        /// 根据信息查找所有的列配置
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <param name="creater">创建人</param>
        /// <param name="tenantName">租户名称</param>
        /// <param name="hidden">是否禁用，默认为false</param>
        /// <returns></returns>
        Task<IEnumerable<PageColumnItem>> FindAll(string name, string creater, string tenantName, bool hidden = false);

        /// <summary>
        /// 根据信息删除所有配置
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <param name="creater">创建人</param>
        /// <param name="tenantName">租户名称</param>
        /// <returns></returns>
        Task Delete(string name, string creater, string tenantName);
    }
}
