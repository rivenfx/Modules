using Microsoft.EntityFrameworkCore;

using Riven.ListViewInfos;

using System;
using System.Collections.Generic;
using System.Text;

namespace Riven
{
    public static class RivenListViewInfoDbContextExtensions
    {
        public static ModelBuilder ConfigRivenListViewInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageFilterItem>((entityBuilder) =>
            {
                entityBuilder.HasIndex(o => new { o.Name, o.Creator, o.TenantName });
            });
            modelBuilder.Entity<PageColumnItem>((entityBuilder) =>
            {
                entityBuilder.HasIndex(o => new { o.Name, o.Creator, o.TenantName });
            });


            return modelBuilder;
        }
    }
}
