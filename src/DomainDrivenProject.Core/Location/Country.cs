using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace DomainDrivenProject.Location
{
    [Table("Countries")]
    public class Country : Entity, IMultiLingualEntity<CountryTranslation>
    {
        public string Name { get; set; }

        public ICollection<CountryTranslation> Translations { get; set; }
    }

    [Table("CountryTranslations")]
    public class CountryTranslation : Entity, IEntityTranslation<Country>
    {
        public string Name { get; set; }

        public Country Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
