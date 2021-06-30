using Microsoft.EntityFrameworkCore;

using Riven.ListViewInfos;

using System;
using System.Collections.Generic;
using System.Text;

namespace Riven
{
    public static class RivenListViewInfoDbContextExtensions
    {
        /// <summary>
        /// 配置ListView模块实体映射表信息
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public static ModelBuilder ConfiurationRivenListViewInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageFilterItem>((entityBuilder) =>
            {
                entityBuilder.HasIndex(o => new { o.Name, o.Creator, o.TenantName });
                entityBuilder.Property(o => o.Name).IsRequired().HasMaxLength(128);
                entityBuilder.Property(o => o.Field).IsRequired().HasMaxLength(128);

                entityBuilder.Property(o => o.Creator).IsRequired().HasMaxLength(256);
                entityBuilder.Property(o => o.TenantName).IsRequired().HasMaxLength(256);

                entityBuilder.Property(o => o.Hidden).HasConversion<byte>();
               
            });
            modelBuilder.Entity<PageColumnItem>((entityBuilder) =>
            {
                entityBuilder.HasIndex(o => new { o.Name, o.Creator, o.TenantName });

                entityBuilder.Property(o => o.Name).IsRequired().HasMaxLength(128);
                entityBuilder.Property(o => o.Field).IsRequired().HasMaxLength(128);

                entityBuilder.Property(o => o.Creator).IsRequired().HasMaxLength(256);
                entityBuilder.Property(o => o.TenantName).IsRequired().HasMaxLength(256);

                entityBuilder.Property(o => o.Hidden).HasConversion<byte>();
            });


            return modelBuilder;
        }
    }
}
