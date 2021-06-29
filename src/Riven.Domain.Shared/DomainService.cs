using Microsoft.Extensions.DependencyInjection;

using Riven.Entities;
using Riven.Repositories;
using Riven.Uow;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Riven
{
    public abstract class DomainService<TEntity, TPrimaryKey> : IDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected readonly IServiceProvider _serviceProvider;

        protected DomainService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            UnitOfWorkManager = this.GetService<IUnitOfWorkManager>();

            EntityRepo = this.GetService<IRepository<TEntity, TPrimaryKey>>();
        }

        public virtual IUnitOfWorkManager UnitOfWorkManager { get; }

        public virtual IActiveUnitOfWork CurrentUnitOfWork => UnitOfWorkManager.Current;

        public virtual IRepository<TEntity, TPrimaryKey> EntityRepo { get; protected set; }

        public virtual IQueryable<TEntity> Query => EntityRepo.GetAll();

        public virtual IQueryable<TEntity> QueryAsNoTracking => Query;


        public virtual async Task<TEntity> FindById(TPrimaryKey id)
        {
            return await this.EntityRepo.FirstOrDefaultAsync(id);
        }

        public virtual async Task Create(TEntity entity, bool createAndGetId = false)
        {
            switch (createAndGetId)
            {
                case true:
                    await this.EntityRepo.InsertAndGetIdAsync(entity);
                    break;
                case false:
                    await this.EntityRepo.InsertAsync(entity);
                    break;
            }

        }

        public virtual async Task Update(TEntity entity)
        {
            await this.EntityRepo.UpdateAsync(entity);
        }

        public virtual async Task Delete(TPrimaryKey id)
        {
            await this.EntityRepo.DeleteAsync(id);
        }

        public virtual async Task Delete(List<TPrimaryKey> idList)
        {
            if (idList == null || idList.Count == 0)
            {
                return;
            }

            await this.EntityRepo.DeleteAsync(o => idList.Contains(o.Id));
        }

        public async Task Delete(Expression<Func<TEntity, bool>> predicate)
        {
            await this.EntityRepo.DeleteAsync(predicate);
        }

        public async Task<bool> Exist(TPrimaryKey id)
        {
            var entity = await FindById(id);
            return entity != null;
        }


        protected virtual TService GetService<TService>()
        {
            return this._serviceProvider.GetRequiredService<TService>();
        }
    }


    public abstract class DomainService<TEntity> : DomainService<TEntity, long>
        where TEntity : class, IEntity<long>
    {
        protected DomainService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }

    }
}

