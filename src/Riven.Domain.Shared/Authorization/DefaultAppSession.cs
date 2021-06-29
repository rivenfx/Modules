
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

        public LanguageInfo CurrentLanguage => this._currentLanguage.GetCurrentLanguage();


        protected readonly ICurrentUser _currentUser;
        protected readonly ICurrentLanguage _currentLanguage;
        protected readonly IMultiTenancyProvider _multiTenancyProvider;

        public DefaultAppSession(ICurrentUser currentUser, ICurrentLanguage currentLanguage, IMultiTenancyProvider multiTenancyProvider)
        {
            _currentUser = currentUser;
            _currentLanguage = currentLanguage;
            _multiTenancyProvider = multiTenancyProvider;
        }

        public T GetUserId<T>()
        {
            return this._currentUser.UserId.MapTo<T>();
        }
    }
}
