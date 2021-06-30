
using Riven.Localization;
using Riven.MultiTenancy;
using Riven.Extensions;
using Riven.Identity;

namespace Riven.Authorization
{
    public class DefaultAppSession : IAppSession
    {
        public string UserId => this._currentUser.UserId;

        public string UserName => this._currentUser.UserName;

        public string TenantName => this._multiTenancyProvider.CurrentTenantNameOrNull();



        protected readonly ICurrentUser _currentUser;
        protected readonly IMultiTenancyProvider _multiTenancyProvider;

        public DefaultAppSession(ICurrentUser currentUser, IMultiTenancyProvider multiTenancyProvider)
        {
            _currentUser = currentUser;
            _multiTenancyProvider = multiTenancyProvider;
        }

        public T GetUserId<T>()
        {
            return this._currentUser.UserId.MapTo<T>();
        }
    }
}
