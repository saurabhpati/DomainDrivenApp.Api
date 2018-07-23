using System.Threading.Tasks;
using Abp.Application.Services;
using DomainDrivenProject.Location.Dto;

namespace DomainDrivenProject.Location
{
    public interface ICountryAppService : IApplicationService
    {
        Task<CountryDto> GetAsync(int id);
    }
}