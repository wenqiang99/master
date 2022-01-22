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
            //context.Manager.MainMenu
            //#region 订单
            //      .AddItem(new MenuItemDefinition(
            //       "Pages", L("Pages"),
            //        icon: "database",
            //        customData: "",
            //        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages))
            //          .AddItem(new MenuItemDefinition(
            //              "Orders", L("Pages_Orders"),
            //               icon: "database",
            //               customData: "",
            //               permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Orders)))
            //                  .AddItem(new MenuItemDefinition(
            //                  "Administration", L("Pages_Orders_Administration"),
            //                   icon: "database",
            //                   customData: "",
            //                   permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Orders_Administration)))
            //                       .AddItem(new MenuItemDefinition(
            //                       "BasicData", L("Pages_Orders_Administration_BasicData"),
            //                        icon: "database",
            //                        customData: "",
            //                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Orders_Administration_BasicData)))
            //      );

            //#endregion
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
