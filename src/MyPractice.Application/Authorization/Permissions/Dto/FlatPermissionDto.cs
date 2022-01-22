using Abp.Authorization;
using Abp.AutoMapper;

namespace MyPractice.Authorization.Permissions.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class FlatPermissionDto
    {
        /// <summary>
        /// 父节点名称
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 权限唯一标识
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否授权
        /// </summary>
        public bool IsGrantedByDefault { get; set; }
    }
}
