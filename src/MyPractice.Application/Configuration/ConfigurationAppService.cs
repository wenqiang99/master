using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyPractice.Configuration.Dto;

namespace MyPractice.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyPracticeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
