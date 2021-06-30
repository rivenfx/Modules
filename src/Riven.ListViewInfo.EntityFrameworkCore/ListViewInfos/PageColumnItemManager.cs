using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Riven.Extensions;
using Riven.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Riven.ListViewInfos
{
    public class PageColumnItemManager : EfCoreDomainService<PageColumnItem, Guid>, IPageColumnItemManager
    {
        public PageColumnItemManager(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }



        public virtual async Task<IEnumerable<PageColumnItem>> FindAll(string name, string creater, string tenantName, bool hidden = false)
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
