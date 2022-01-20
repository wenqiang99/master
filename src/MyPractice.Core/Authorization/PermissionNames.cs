namespace MyPractice.Authorization
{
    /// <summary>
    /// 权限定义
    /// </summary>
    public static class PermissionNames
    {
        #region 初始
        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Users = "Pages.Users";
        public const string Pages_Roles = "Pages.Roles";
        #endregion

        //通用权限(适用于租户和主机)
        public const string Pages = "Pages";
        //订单系统
        public const string Pages_Orders = "Pages.Orders";
        public const string Pages_Orders_Administration = "Pages.Orders.Administration"; //订单管理系统权限
        public const string Pages_Orders_Administration_BasicData = "Pages.Orders.Administration.BasicData"; //基础数据
    }
}
