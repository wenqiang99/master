using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyPractice.Roles.Dto;
using MyPractice.Users.Dto;

namespace MyPractice.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        /// <summary>
        /// «–ªª”Ô—‘
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
