using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace DomainDrivenProject.Localization
{
    public static class DomainDrivenProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(DomainDrivenProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DomainDrivenProjectLocalizationConfigurer).GetAssembly(),
                        "DomainDrivenProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
