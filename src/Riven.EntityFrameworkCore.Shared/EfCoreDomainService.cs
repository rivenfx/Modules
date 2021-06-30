using Riven.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Riven
{
    public class EfCoreDomainService<TEntity, TPrimaryKey> : DomainService<TEntity, TPrimaryKey>
         where TEntity : class, IEntity<TPrimaryKey>
    {
        public EfCoreDomainService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public override IQueryable<TEntity> QueryAsNoTracking => base.Query.AsNoTracking();
    }


    public class EfCoreDomainService<TEntity> : EfCoreDomainService<TEntity, long>
         where TEntity : class, IEntity<long>
    {
        public EfCoreDomainService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

    }
}
