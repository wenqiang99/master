using Abp.Application.Navigation;
using Abp.Application.Services;
using Abp.Runtime.Session;
using Abp.UI;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using MyPractice.Common;
using MyPractice.Util;
using Abp.Extensions;
using ABBMASWeld.Utility;

namespace MyPractice.SysMenus
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class SysMenusAppService : ApplicationService, ISysMenusAppService
    {
        private readonly INavigationManager _navigationManager;
        private readonly IUserNavigationManager _userNavigationManager;
        public SysMenusAppService(IUserNavigationManager userNavigationManager,
            INavigationManager navigationManager
             )
        {
            _userNavigationManager = userNavigationManager;
            _navigationManager = navigationManager;
        }

        /// <summary>
        /// 获取当前登录人的菜单
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<UserMenu>> GetMenusAsync()
        {
            if (AbpSession.UserId.HasValue)
            {
                var menus = await _userNavigationManager.GetMenusAsync(AbpSession.ToUserIdentifier());
                return menus;
            }
            throw new UserFriendlyException("未检测到用户登录！");
        }
    }
}
