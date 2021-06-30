using System;
using System.Collections.Generic;
using System.Text;

namespace Riven.ListViewInfos.Dtos
{
    /// <summary>
    /// 更新页面过滤配置input
    /// </summary>
    public class UpdatePageFiltersInput
    {
        /// <summary>
        /// 配置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// filter 配置
        /// </summary>
        public virtual IList<PageFilterItemDto> Filters { get; set; }
    }

    /// <summary>
    /// 更新页面过滤配置input
    /// </summary>
    public class UpdatePageColumnsInput
    {
        /// <summary>
        /// 配置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 列 配置
        /// </summary>
        public virtual IList<PageColumnItemDto> Columns { get; set; }
    }
}
