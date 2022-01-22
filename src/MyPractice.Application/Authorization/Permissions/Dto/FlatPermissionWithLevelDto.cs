using Abp.Authorization;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Authorization.Permissions.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class FlatPermissionWithLevelDto : FlatPermissionDto
    {
        public int Level { get; set; }
    }
}
