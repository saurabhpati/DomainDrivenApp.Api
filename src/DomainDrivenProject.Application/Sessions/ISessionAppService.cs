using System.Threading.Tasks;
using Abp.Application.Services;
using DomainDrivenProject.Sessions.Dto;

namespace DomainDrivenProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
