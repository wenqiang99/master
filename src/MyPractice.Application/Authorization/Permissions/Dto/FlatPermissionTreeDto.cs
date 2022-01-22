using Abp.Authorization;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Authorization.Permissions.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class FlatPermissionTreeDto
    {
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
        /// 权限子集
        /// </summary>
        public List<FlatPermissionTreeDto> Children { get; set; } = new List<FlatPermissionTreeDto>();
    }
}
