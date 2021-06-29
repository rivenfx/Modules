using Microsoft.EntityFrameworkCore;
using Riven.Uow.Providers;
using Riven.Extensions;

namespace Riven.Identity
{
    public class UowIdentityDbContextAccessor : IIdentityDbContextAccessor
    {
        public virtual DbContext Context => _currentUnitOfWorkProvider.Current?.GetDbContext();

        protected readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;

        public UowIdentityDbContextAccessor(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
        }
    }
}
