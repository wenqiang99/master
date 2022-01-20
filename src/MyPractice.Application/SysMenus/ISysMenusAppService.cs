using Abp.Application.Navigation;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPractice.SysMenus
{
    public interface ISysMenusAppService : IApplicationService
    {
        /// <summary>
        /// 获取当前登录人的菜单
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<UserMenu>> GetMenusAsync();
    }
}
