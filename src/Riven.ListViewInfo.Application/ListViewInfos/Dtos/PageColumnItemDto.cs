using System;
using System.Collections.Generic;
using System.Text;

namespace Riven.ListViewInfos.Dtos
{
    public class PageColumnItemDto
    {
        /// <summary>
        /// 列名
        /// </summary>
        public virtual string Field { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public virtual int? Order { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public virtual int? Width { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public virtual bool Hidden { get; set; }
    }
}
