using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DomainDrivenProject.MultiTenancy.Dto;

namespace DomainDrivenProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
