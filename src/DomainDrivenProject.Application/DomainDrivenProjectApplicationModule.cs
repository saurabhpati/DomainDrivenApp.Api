using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AutoMapper;
using DomainDrivenProject.Authorization;
using DomainDrivenProject.Location;
using DomainDrivenProject.Location.Dto;

namespace DomainDrivenProject
{
    [DependsOn(
        typeof(DomainDrivenProjectCoreModule),
        typeof(AbpAutoMapperModule))]
    public class DomainDrivenProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DomainDrivenProjectAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                CustomDtoMapper.CreateMappings(configuration, new MultiLingualMapContext(
                    IocManager.Resolve<ISettingManager>()
                ));
            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DomainDrivenProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }

    internal static class CustomDtoMapper
    {
        internal static void CreateMappings(IMapperConfigurationExpression configuration, MultiLingualMapContext context)
        {
            configuration.CreateMultiLingualMap<Country, CountryTranslation, CountryDto>(context);
        }
    }
}
