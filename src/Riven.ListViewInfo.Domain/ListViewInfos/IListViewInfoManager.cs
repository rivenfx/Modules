using System;
using System.Collections.Generic;
using System.Text;

using Riven.Dependency;

namespace Riven.ListViewInfos
{
    public interface IListViewInfoManager : ITransientDependency
    {
        IPageColumnItemManager PageColumnItemManager { get; }

        IPageFilterItemManager PageFilterItemManager { get; }

    }


    public class ListViewInfoManager : IListViewInfoManager
    {
        public ListViewInfoManager(IPageColumnItemManager pageColumnItemManager, IPageFilterItemManager pageFilterItemManager)
        {
            PageColumnItemManager = pageColumnItemManager;
            PageFilterItemManager = pageFilterItemManager;
        }

        public virtual IPageColumnItemManager PageColumnItemManager { get; protected set; }

        public virtual IPageFilterItemManager PageFilterItemManager { get; protected set; }
    }
}
