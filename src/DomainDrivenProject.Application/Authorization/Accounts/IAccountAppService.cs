using System.Threading.Tasks;
using Abp.Application.Services;
using DomainDrivenProject.Authorization.Accounts.Dto;

namespace DomainDrivenProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
