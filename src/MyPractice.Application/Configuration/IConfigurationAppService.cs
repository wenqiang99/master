using System.Threading.Tasks;
using MyPractice.Configuration.Dto;

namespace MyPractice.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
