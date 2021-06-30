using Riven.Application;
using System.Collections.Generic;
using System.Text;
using Riven;
using System.Threading.Tasks;
using Riven.ListViewInfos.Dtos;

namespace Riven.ListViewInfos
{
    /// <summary>
    /// 视图信息服务
    /// </summary>
    public interface IListViewInfoAppService : IApplicationService
    {
        /// <summary>
        /// 获取视图信息
        /// </summary>
        /// <param name="name">视图配置名称</param>
        /// <returns></returns>
        Task<ListViewInfoDto> GetListViewInfo(string name);


        /// <summary>
        /// 获取filter信息
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <returns></returns>
        Task<IList<PageFilterItemDto>> GetFilters(string name);

        /// <summary>
        /// 获取列信息
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <returns></returns>
        Task<IList<PageColumnItemDto>> GetColumns(string name);

        /// <summary>
        /// 更新filter配置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateFilter(UpdatePageFiltersInput input);


        /// <summary>
        /// 更新列配置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateColumns(UpdatePageColumnsInput input);

    }
}
