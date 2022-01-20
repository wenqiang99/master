using MyPractice.Authorization;
using MyPractice.Common;
using Abp.Application.Navigation;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Authorization;

namespace MyPractice
{
    /// <summary>
    /// 菜单维护
    /// </summary>
    public class ABBMASWeldNavigationProvider : NavigationProvider
    {
        /// <summary>
        /// 加载系统导航菜单
        /// </summary>
        /// <param name="context"></param>
        public override void SetNavigation(INavigationProviderContext context)
        {
            this.SysNavigation(context);
        }

        /// <summary>
        /// 加载系统导航菜单
        /// </summary>
        /// <param name="context"></param>
        private void SysNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
            #region 订单
                  .AddItem(new MenuItemDefinition(
                   "TG", L("TG"),
                    icon: "database",
                    customData: "",
                    permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)));

            #endregion
        }


        /// <summary>
        /// 本地化
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyPracticeConsts.LocalizationSourceName);
        }
    }
}
