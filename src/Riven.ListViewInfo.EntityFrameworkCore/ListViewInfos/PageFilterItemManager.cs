using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Riven.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Riven.ListViewInfos
{
    public class PageFilterItemManager : EfCoreDomainService<PageFilterItem, Guid>, IPageFilterItemManager
    {
        public PageFilterItemManager(IServiceProvider serviceProvider)
           : base(serviceProvider)
        {
        }

        public virtual async Task<IEnumerable<PageFilterItem>> FindAll(string name, string creater, string tenantName, bool hidden = false)
        {

                return await this.QueryAsNoTracking
                          .Where(o => o.Name == name
                              && o.Creator == creater
                              && o.TenantName == tenantName
                              && o.Hidden == hidden
                          )
                          .ToListAsync()
                          ;
  
        }

        public async Task Delete(string name, string creater, string tenantName)
        {

                var entitys = await this.QueryAsNoTracking
                          .Where(o => o.Name == name
                              && o.Creator == creater
                              && o.TenantName == tenantName
                          ).ToListAsync();

                await this.EntityRepo.DeleteAsync(entitys);

        }
    }
}
