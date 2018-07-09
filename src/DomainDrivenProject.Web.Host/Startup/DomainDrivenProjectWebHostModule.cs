using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DomainDrivenProject.Configuration;

namespace DomainDrivenProject.Web.Host.Startup
{
    [DependsOn(
       typeof(DomainDrivenProjectWebCoreModule))]
    public class DomainDrivenProjectWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public DomainDrivenProjectWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DomainDrivenProjectWebHostModule).GetAssembly());
        }
    }
}
