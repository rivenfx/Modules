using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Riven.Entities;
using Riven.Entities.Auditing;
using Riven.Extensions;
using Riven.Identity;
using Riven.MultiTenancy;
using Riven.Timing;
using Riven.Uow.Providers;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Riven.Database
{
    public abstract class RivenDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        : IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>, IRivenDbContext
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
    {
        [NotMapped]
        protected IRivenDbContext Self => this;

        [NotMapped]
        public virtual IServiceProvider ServiceProvider { get; protected set; }

        [NotMapped]
        public virtual ILogger Logger { get; protected set; }

        [NotMapped]
        public virtual IGuidGenerator GuidGenerator { get; protected set; }

        [NotMapped]
        public virtual bool AuditSuppressAutoSetTenantName { get; protected set; } = true;

        [NotMapped]
        public virtual string CurrentUserId { get; protected set; }

        [NotMapped]
        public virtual string CurrentTenantName => this.GetService<IMultiTenancyProvider>()?.CurrentTenantNameOrNull();

        [NotMapped]
        public virtual ICurrentUnitOfWorkProvider CurrentUnitOfWorkProvider => this.GetService<ICurrentUnitOfWorkProvider>();

        public RivenDbContext(DbContextOptions options, IServiceProvider serviceProvider = null)
           : base(options)
        {
            ServiceProvider = serviceProvider;

            this.CurrentUserId = this.GetService<ICurrentUser>()?.UserId;
            this.Logger = this.GetService<ILogger<IRivenDbContext>>();
            this.GuidGenerator = this.GetService<IGuidGenerator>();
        }

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.OnModelCreatingAfter(modelBuilder);
        }

        /// <summary>
        /// OnModelCreating 方法执行之后
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected virtual void OnModelCreatingAfter(ModelBuilder modelBuilder)
        {
            // 启用 Filter
            modelBuilder.ConfigureGlobalFilters(this);
        }

        #endregion

        #region 审计

        /// <summary>
        /// 启用审计
        /// </summary>
        /// <param name="changeTracker"></param>
        protected virtual void ApplyAudit(ChangeTracker changeTracker)
        {
            this.Self.ApplyAudit(ChangeTracker);
        }

        #endregion


        #region 重写SaveChange函数

        public override int SaveChanges()
        {
            this.ApplyAudit(ChangeTracker);
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAudit(ChangeTracker);
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ApplyAudit(ChangeTracker);
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAudit(ChangeTracker);
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion

        /// <summary>
        /// 从Ioc容器中获取一个服务实例
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <returns>服务实例</returns>
        protected virtual T GetService<T>()
        {
            if (this.ServiceProvider == null)
            {
                return default(T);
            }

            return this.ServiceProvider.GetService<T>();
        }
    }

}
