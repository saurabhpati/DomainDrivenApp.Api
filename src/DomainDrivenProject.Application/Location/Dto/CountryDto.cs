using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace DomainDrivenProject.Location.Dto
{
    [AutoMap(typeof(Country))]
    public class CountryDto : EntityDto
    {
        public string Name { get; set; }

        public ICollection<CountryTranslationDto> Translations { get; set; }
    }

    [AutoMap(typeof(CountryTranslation))]
    public class CountryTranslationDto : EntityDto
    {
        public string Name { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
