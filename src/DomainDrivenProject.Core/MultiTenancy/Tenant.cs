using Abp.MultiTenancy;
using DomainDrivenProject.Authorization.Users;

namespace DomainDrivenProject.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
