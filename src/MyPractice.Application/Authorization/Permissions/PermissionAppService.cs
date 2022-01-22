using MyPractice.Authorization.Permissions.Dto;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPractice.Authorization.Permissions
{
    /// <summary>
    /// 权限应用服务
    /// </summary>
    [AbpAuthorize]
    public class PermissionAppService: MyPracticeAppServiceBase, IPermissionAppService
    {
        /// <summary>
        /// 获取所有权限树
        /// </summary>
        /// <returns></returns>
        public ListResultDto<FlatPermissionTreeOutPut> GetAllPermissionsTree()
        {
            var permissions = PermissionManager.GetAllPermissions().Where(p => p.Parent == null);

            #region 
            //string platformtype
            //var permissions = PermissionManager.GetAllPermissions()
            //    .WhereIf(!string.IsNullOrWhiteSpace(platformtype), p => p.Name == platformtype)
            //    .WhereIf(string.IsNullOrWhiteSpace(platformtype), p => p.Parent == null);
            #endregion

            return new ListResultDto<FlatPermissionTreeOutPut>(
                ObjectMapper.Map<List<FlatPermissionTreeOutPut>>(permissions)
            );
        }

        /// <summary>
        /// 获取当前登录人拥有的权限
        /// </summary>
        /// <returns></returns>
        public FlatPermissionTreeDto GetCurrentUserAllPermissionsTree()
        {
            FlatPermissionTreeDto treeDtos = new FlatPermissionTreeDto();
            var userPermissions = UserManager.GetGrantedPermissionsAsync(GetCurrentUserAsync().Result).Result;
            var parents = userPermissions.FirstOrDefault(t => t.Parent == null);
            ObjectMapper.Map(parents, treeDtos);
            treeDtos.Children = new List<FlatPermissionTreeDto>();
            GetPermissionTree(userPermissions, treeDtos);
            return treeDtos;
        }

        /// <summary>
        /// 获取权限树
        /// </summary>
        /// <param name="userPermissions"></param>
        /// <param name="treeDtos"></param>
        /// <returns></returns>
        private FlatPermissionTreeDto GetPermissionTree(IReadOnlyList<Permission> userPermissions, FlatPermissionTreeDto treeDtos)
        {
            try
            {
                var permissions = userPermissions.Where(t => t.Parent != null && t.Parent.Name == treeDtos.Name).ToList();

                foreach (var i in permissions)
                {
                    var tree = ObjectMapper.Map<FlatPermissionTreeDto>(i);
                    GetPermissionTree(userPermissions, tree);
                    treeDtos.Children.Add(tree);
                }
                return treeDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        public ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions()
        {
            var permissions = PermissionManager.GetAllPermissions();
            var rootPermissions = permissions.Where(p => p.Parent == null);
            var result = new List<FlatPermissionWithLevelDto>();
            foreach (var rootPermission in rootPermissions)
            {
                var level = 0;
                AddPermission(rootPermission, permissions, result, level);
            }
            return new ListResultDto<FlatPermissionWithLevelDto>
            {
                Items = result
            };
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="allPermissions"></param>
        /// <param name="result"></param>
        /// <param name="level"></param>
        private void AddPermission(Permission permission, IReadOnlyList<Permission> allPermissions, List<FlatPermissionWithLevelDto> result, int level)
        {
            var flatPermission = ObjectMapper.Map<FlatPermissionWithLevelDto>(permission);
            flatPermission.Level = level;
            result.Add(flatPermission);

            if (permission.Children == null)
            {
                return;
            }

            var children = allPermissions.Where(p => p.Parent != null && p.Parent.Name == permission.Name).ToList();

            foreach (var childPermission in children)
            {
                AddPermission(childPermission, allPermissions, result, level + 1);
            }
        }
    }
}
