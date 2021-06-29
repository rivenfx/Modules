using Microsoft.Extensions.DependencyInjection;

using Riven.Dependency;
using Riven.Entities;
using Riven.Repositories;
using Riven.Uow;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Riven
{
    public interface IDomainService<TEntity, TPrimaryKey> : ITransientDependency
        where TEntity : class, IEntity<TPrimaryKey>
    {
        IUnitOfWorkManager UnitOfWorkManager { get; }

        IActiveUnitOfWork CurrentUnitOfWork { get; }

        IRepository<TEntity, TPrimaryKey> EntityRepo { get; }

        IQueryable<TEntity> Query { get; }

        IQueryable<TEntity> QueryAsNoTracking { get; }

        /// <summary>
        /// 根据id查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindById(TPrimaryKey id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="createAndGetId">是否获取id</param>
        /// <returns></returns>
        Task Create(TEntity entity, bool createAndGetId = false);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Update(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(TPrimaryKey id);

        /// <summary>
        /// 删除 - 按条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        Task Delete(List<TPrimaryKey> idList);

    }

    public interface IDomainService<TEntity> : IDomainService<TEntity, long>
         where TEntity : class, IEntity<long>
    {

    }

}

