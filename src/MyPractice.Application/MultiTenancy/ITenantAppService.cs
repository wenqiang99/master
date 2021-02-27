using Abp.Application.Services;
using MyPractice.MultiTenancy.Dto;

namespace MyPractice.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

