using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Auditing;
using MyPractice.Sessions.Dto;

namespace MyPractice.Sessions
{
    /// <summary>
    /// Session服务
    /// </summary>
    public class SessionAppService : MyPracticeAppServiceBase, ISessionAppService
    {
        /// <summary>
        /// 获取当前登录信息
        /// </summary>
        /// <returns></returns>
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput
            {
                Application = new ApplicationInfoDto
                {
                    Version = AppVersionHelper.Version,
                    ReleaseDate = AppVersionHelper.ReleaseDate,
                    Features = new Dictionary<string, bool>()
                }
            };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            if (AbpSession.UserId.HasValue)
            {
                output.User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync());
            }

            return output;
        }
    }
}
