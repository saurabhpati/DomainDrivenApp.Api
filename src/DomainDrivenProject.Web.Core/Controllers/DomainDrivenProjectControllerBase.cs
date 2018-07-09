using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DomainDrivenProject.Controllers
{
    public abstract class DomainDrivenProjectControllerBase: AbpController
    {
        protected DomainDrivenProjectControllerBase()
        {
            LocalizationSourceName = DomainDrivenProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
