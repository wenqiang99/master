using System.Threading.Tasks;
using Abp.Application.Services;
using MyPractice.Sessions.Dto;

namespace MyPractice.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
