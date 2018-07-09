using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DomainDrivenProject.Configuration;
using DomainDrivenProject.Web;

namespace DomainDrivenProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DomainDrivenProjectDbContextFactory : IDesignTimeDbContextFactory<DomainDrivenProjectDbContext>
    {
        public DomainDrivenProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DomainDrivenProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DomainDrivenProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DomainDrivenProjectConsts.ConnectionStringName));

            return new DomainDrivenProjectDbContext(builder.Options);
        }
    }
}
