using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using DomainDrivenProject.Location.Dto;

namespace DomainDrivenProject.Location
{
    public class CountryAppService : ApplicationService, ICountryAppService
    {
        private readonly IRepository<Country, int> _countryRepository;
        private readonly IRepository<CountryTranslation, int> _translationRepository;
        private readonly IObjectMapper _mapper;

        public CountryAppService(
            IRepository<Country, int> countryRepository, 
            IRepository<CountryTranslation, int> translationRepository, 
            IObjectMapper mapper)
        {
            this._countryRepository = countryRepository;
            this._translationRepository = translationRepository;
            this._mapper = mapper;
        }

        public async Task<CountryDto> GetAsync(int id)
        {
            Country country = this._countryRepository.GetAllIncluding(c => c.Translations).FirstOrDefault(c => c.Id == id);
            CountryDto dto = this._mapper.Map<CountryDto>(country);
            return await Task.FromResult(dto).ConfigureAwait(false);
        }
    }
}
