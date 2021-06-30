using System;
using System.Collections.Generic;
using System.Text;

namespace Riven.ListViewInfos.Dtos
{
    public class ListViewInfoDto
    {
        /// <summary>
        /// filter 配置
        /// </summary>
        public virtual IList<PageFilterItemDto> Filters { get; set; }

        /// <summary>
        /// 列配置
        /// </summary>
        public virtual IList<PageColumnItemDto> Columns { get; set; }

    }
}
