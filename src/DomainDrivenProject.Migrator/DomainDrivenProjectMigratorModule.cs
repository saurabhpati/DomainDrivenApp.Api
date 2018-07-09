using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DomainDrivenProject.Configuration;
using DomainDrivenProject.EntityFrameworkCore;
using DomainDrivenProject.Migrator.DependencyInjection;

namespace DomainDrivenProject.Migrator
{
    [DependsOn(typeof(DomainDrivenProjectEntityFrameworkModule))]
    public class DomainDrivenProjectMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public DomainDrivenProjectMigratorModule(DomainDrivenProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(DomainDrivenProjectMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                DomainDrivenProjectConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DomainDrivenProjectMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
