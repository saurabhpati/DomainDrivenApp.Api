using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DomainDrivenProject.Authorization.Roles;
using DomainDrivenProject.Authorization.Users;
using DomainDrivenProject.MultiTenancy;

namespace DomainDrivenProject.EntityFrameworkCore
{
    public class DomainDrivenProjectDbContext : AbpZeroDbContext<Tenant, Role, User, DomainDrivenProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DomainDrivenProjectDbContext(DbContextOptions<DomainDrivenProjectDbContext> options)
            : base(options)
        {
        }
    }
}
