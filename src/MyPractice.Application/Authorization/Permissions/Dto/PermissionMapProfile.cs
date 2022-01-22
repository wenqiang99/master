using Abp.Authorization;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Authorization.Permissions.Dto
{
    public class PermissionMapProfile : Profile
    {
        public PermissionMapProfile()
        {
            CreateMap<Permission, FlatPermissionTreeDto>().ForMember(t => t.Children, opt => opt.Ignore());
        }
    }
}
