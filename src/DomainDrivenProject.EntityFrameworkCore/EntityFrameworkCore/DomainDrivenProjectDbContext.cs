using Abp.Zero.EntityFrameworkCore;
using DomainDrivenProject.Authorization.Roles;
using DomainDrivenProject.Authorization.Users;
using DomainDrivenProject.Location;
using DomainDrivenProject.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenProject.EntityFrameworkCore
{
    public class DomainDrivenProjectDbContext : AbpZeroDbContext<Tenant, Role, User, DomainDrivenProjectDbContext>
    {
        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<CountryTranslation> CountryTranslations { get; set; }

        public DomainDrivenProjectDbContext(DbContextOptions<DomainDrivenProjectDbContext> options)
            : base(options)
        {
        }
    }
}
