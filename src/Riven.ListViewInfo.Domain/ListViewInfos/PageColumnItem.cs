using Riven.Entities;
using Riven.Entities.Auditing;

using System;
using System.Collections;
using System.Linq;

namespace Riven.ListViewInfos
{
    /// <summary>
    /// 页面列信息
    /// </summary>
    public class PageColumnItem : CreationAuditedEntity<Guid>, IMayHaveTenant
    {
        /// <summary>
        /// 配置名称
        /// </summary>
        public virtual string Name { get; set; }

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


        public virtual string TenantName { get; set; }
    }
}
