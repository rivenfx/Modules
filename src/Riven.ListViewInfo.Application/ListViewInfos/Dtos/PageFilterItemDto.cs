using System;
using System.Collections.Generic;
using System.Text;

namespace Riven.ListViewInfos.Dtos
{
    public class PageFilterItemDto
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
        /// 隐藏
        /// </summary>
        public virtual bool Hidden { get; set; }


        /// <summary>
        /// 默认宽度
        /// </summary>
        public virtual int Width { get; set; }


        #region 扩展宽度

        /// <summary>
        ///  宽度, 当屏幕宽度: <576px, 一行24
        /// </summary>
        public virtual int? XsWidth { get; set; }
        /// <summary>
        /// 宽度 当屏幕宽度: ≥576px, 一行24
        /// </summary>
        public virtual int? SmWidth { get; set; }
        /// <summary>
        /// 宽度, 当屏幕宽度: ≥768px, 一行24
        /// </summary>
        public virtual int? MdWidth { get; set; }
        /// <summary>
        /// 宽度, 当屏幕宽度: ≥992px, 一行24
        /// </summary>
        public virtual int? LgWidth { get; set; }
        /// <summary>
        /// 宽度, 当屏幕宽度: ≥1200px, 一行24
        /// </summary>
        public virtual int? XlWidth { get; set; }
        /// <summary>
        /// 宽度, 当屏幕宽度: ≥1600px, 一行24
        /// </summary>
        public virtual int? XxlWidth { get; set; }


        #endregion
    }
}
